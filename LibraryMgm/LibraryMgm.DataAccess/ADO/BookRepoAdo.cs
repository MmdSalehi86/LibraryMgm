using LibraryMgm.Model.BookModel;
using LibraryMgm.Model.Conversion;
using LibraryMgm.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LibraryMgm.DataAccess.ADO
{
    public class BookRepoAdo : DbSqlCommands, IBookCrud
    {
        public bool CheckExists(string name, int? id)
        {
            return ExcScalarFunc<bool>("dbo.CHECK_EXISTS_BOOK",
                new SqlParameter("@Name", name),
                new SqlParameter("@Id", id.HasValue ? (object)id.Value : DBNull.Value));
        }

        public void Delete(int id)
        {
            ExcNonQuerySql("DELETE FROM Book WHERE Id=@Id",
                new SqlParameter("Id", id));
        }

        public void Insert(InsertBookModel model)
        {
            ExcNonQueryProc("INSERT_BOOK",
                Conversion.ModelToSqlParams(model).ToArray());
        }

        public List<BookVM> Select()
        {
            var reader = ExcReaderProc("SELECT_BOOK");
            var list = reader.ToListViewModel<BookVM>();
            reader.Close();
            return list;
        }

        public void Update(Model.Entities.Book model)
        {
            var param = Conversion.ModelToSqlParams(model);
            for (int i = 0; i < param.Count; i++)
            {
                if (param[i].ParameterName == $"@{nameof(Translator)}")
                {
                    param.RemoveAt(i);
                    break;
                }
            }
            ExcNonQueryProc("UPDATE_BOOK",
                param.ToArray());
        }
    }
}
