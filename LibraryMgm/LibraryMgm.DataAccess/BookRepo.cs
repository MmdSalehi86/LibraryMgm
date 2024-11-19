using LibraryMgm.DataAccess.ADO;
using LibraryMgm.Model.BookModel;
using LibraryMgm.Model.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using LibraryMgm.Model.Conversion;
using System;

namespace LibraryMgm.DataAccess
{
    public class BookRepo : DbSqlCommands
    {
        public BookRepo()
        {
        }

        public void Insert(InsertBookModel model)
        {
            var v = Conversion.ModelToSqlParams(model);
            ExcNonQueryProc("INSERT_BOOK",
                Conversion.ModelToSqlParams(model));

        }

        public List<BookVM> Select()
        {
            var reader = ExcReaderProc("SELECT_BOOK");
            var list = reader.ToListViewModel<BookVM>();
            reader.Close();
            return list;
        }

        public void Update(Book model)
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

        public void Delete(int id)
        {
            ExcNonQuerySql("DELETE FROM Book WHERE Id=@Id",
                new SqlParameter("Id", id));
        }


        public bool CheckExists(string name, int? id = null)
        {
            return ExcScalarFunc<bool>("dbo.CHECK_EXISTS_BOOK",
                new SqlParameter("@Name", name),
                new SqlParameter("@Id", id.HasValue ? (object)id.Value : DBNull.Value));
        }
    }
}
