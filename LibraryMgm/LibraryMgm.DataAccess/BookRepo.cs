using LibraryMgm.DataAccess.ADO;
using LibraryMgm.Model.BookModel;
using LibraryMgm.Model.Entities;
using LibraryMgm.Model.Conversion;
using LibraryMgm.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace LibraryMgm.DataAccess
{
    public class BookRepo : DbSqlCommands
    {
        LibMgmDataContext dbContext = null;

        public BookRepo()
        {
            if (DbConfiguration.ConnectionMethod == ConnectionMethods.EF)
                dbContext = new LibMgmDataContext();
        }

        public void Insert(InsertBookModel model)
        {
            if (dbContext == null)
            {
                var v = Conversion.ModelToSqlParams(model);
                ExcNonQueryProc("INSERT_BOOK",
                    Conversion.ModelToSqlParams(model));
            }
            else
                InsertEF(model);
        }
        public void InsertEF(InsertBookModel model)
        {
            Translator translator = dbContext.Translators.Where(t => t.Id == model.TranslatorId).Single();

            Book book = new Book()
            {
                Name = model.Name,
                Publisher = model.Publisher,
                Year = model.Year,
                Translator = translator
                //TranslatorId = model.TranslatorId
            };
            dbContext.Books.Add(book);
            try
            {
                dbContext.SaveChanges();
            }
            catch { }

            foreach (var item in dbContext.GetValidationErrors())
            {
                foreach (var item1 in item.ValidationErrors)
                {
                    Console.WriteLine(item1.ErrorMessage);
                }
            }
        }


        public List<BookVM> Select()
        {
            if (dbContext == null)
            {
                var reader = ExcReaderProc("SELECT_BOOK");
                var list = reader.ToListViewModel<BookVM>();
                reader.Close();
                return list;
            }
            else
                return SelectEF();
        }
        public List<BookVM> SelectEF()
        {
            var t = dbContext.Books.Select(
                book => new BookVM
                {
                    Id = book.Id,
                    Name = book.Name,
                    Publisher = book.Publisher,
                    Year = book.Year,
                    //TranslatorName = $"{book.Translator.FirstName} {book.Translator.LastName}"
                    TranslatorName = book.Translator.FirstName + " " + book.Translator.LastName
                }
            ).ToList();

            return t;
        }


        public void Update(Book model)
        {
            if (dbContext == null)
            {
                var param = Conversion.ModelToSqlParams(model);
                for (int i = 0; i < param.Length; i++)
                {
                    if (param[i].ParameterName == $"@{nameof(Translator)}")
                    {
                        var name = $"@{nameof(Translator)}Id";
                        var value = ((Translator)param[i].Value).Id;
                        param[i] = new SqlParameter(name, value);
                        break;
                    }
                }
                ExcNonQueryProc("UPDATE_BOOK",
                    param);
            }
            else
                UpdateEF(model);
        }
        private void UpdateEF(Book model)
        {
            var book = dbContext.Books.Where(b => b.Id == model.Id).Single();
            book.Name = model.Name;
            book.Publisher = model.Publisher;
            book.Year = model.Year;
            book.TranslatorId = model.TranslatorId;
            dbContext.SaveChanges();
        }


        public void Delete(int id)
        {
            if (dbContext == null)
            {
                ExcNonQuerySql("DELETE FROM Book WHERE Id=@Id",
                    new SqlParameter("Id", id));
            }
            else
                DeleteEF(id);
        }
        private void DeleteEF(int id)
        {
            var book = dbContext.Books.Where(b => b.Id == id).Single();
            dbContext.Books.Remove(book);
            dbContext.SaveChanges();
        }

        public bool CheckExists(string name, int? id = null)
        {
            if (dbContext == null)
            {
                return ExcScalarFunc<bool>("dbo.CHECK_EXISTS_BOOK",
                new SqlParameter("@Name", name),
                new SqlParameter("@Id", id.HasValue ? (object)id.Value : DBNull.Value));
            }
            else
                return CheckExistsEF(name, id);
        }
        public bool CheckExistsEF(string name, int? id = null)
        {
            var result = dbContext.Books
                .Where(b => b.Name.Equals(name));
            if (id.HasValue)
                result.Where(b => b.Id != id.Value);
            return result.Any();
        }
    }
}
