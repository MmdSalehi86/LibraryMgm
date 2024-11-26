using LibraryMgm.DataAccess.ADO;
using LibraryMgm.Model;
using LibraryMgm.Model.BookModel;
using LibraryMgm.Model.Conversion;
using LibraryMgm.Model.Entities;
using MMDb = LibraryMgm.DataAccess.MemoryDb.LibMgmMMDb;
using DbConfig = LibraryMgm.Model.DbConfiguration;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Diagnostics.Eventing.Reader;

namespace LibraryMgm.DataAccess
{
    public class BookRepo : DbSqlCommands
    {
        LibMgmDataContext dbContext = null;

        public BookRepo()
        {
            if (DbConfig.ConnectionMethod == ConnectionMethods.EF)
                dbContext = new LibMgmDataContext();
        }

        public void Insert(InsertBookModel model)
        {
            if (dbContext == null)
            {
                if (DbConfig.ConnectionMethod == ConnectionMethods.MemoryDb)
                    InsertMM(model);
                else
                    ExcNonQueryProc("INSERT_BOOK",
                        Conversion.ModelToSqlParams(model));
            }
            else
                InsertEF(model);
        }

        private void InsertMM(InsertBookModel model)
        {
            Book book = new Book()
            {
                Name = model.Name,
                Publisher = model.Publisher,
                Year = model.Year,
                TranslatorId = model.TranslatorId
            };
            MMDb.Books.Add(book);
            MMDb.HasChange = true;
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
                if (DbConfig.ConnectionMethod == ConnectionMethods.MemoryDb)
                    return SelectMM();
                else
                {
                    var reader = ExcReaderProc("SELECT_BOOK");
                    var list = reader.ToListViewModel<BookVM>();
                    reader.Close();
                    return list;
                }
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
        public List<BookVM> SelectMM()
        {
            return MMDb.Books.Select(book => new BookVM
            {
                Id = book.Id,
                Name = book.Name,
                Publisher = book.Publisher,
                Year = book.Year,
                TranslatorName = book.Translator.FirstName + " " + book.Translator.LastName
            }).ToList();
        }


        public void Update(Book model)
        {
            if (dbContext == null)
            {
                if (DbConfig.ConnectionMethod == ConnectionMethods.MemoryDb)
                    UpdateMM(model);
                else
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
        private void UpdateMM(Book model)
        {
            var book = MMDb.Books.Where(b => b.Id == model.Id).Single();
            book.Name = model.Name;
            book.Publisher = model.Publisher;
            book.Year = model.Year;
            book.TranslatorId = model.TranslatorId;
            MMDb.HasChange = true;
        }


        public void Delete(int id)
        {
            if (dbContext == null)
            {
                if (DbConfig.ConnectionMethod == ConnectionMethods.MemoryDb)
                    DeleteMM(id);
                else
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
        private void DeleteMM(int id)
        {
            MMDb.Books.RemoveAt(id);
            MMDb.HasChange = true;
        }

        public bool CheckExists(string name, int? id = null)
        {
            if (dbContext == null)
            {
                if (DbConfig.ConnectionMethod == ConnectionMethods.MemoryDb)
                    return CheckExistsMM(name, id);
                else
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
        public bool CheckExistsMM(string name, int? id = null)
        {
            var result = MMDb.Books
                .Where(b => b.Name.Equals(name));
            if (id.HasValue)
                result.Where(b => b.Id != id.Value);
            return result.Any();
        }
    }
}
