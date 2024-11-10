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
            ExcNonQueryProc("INSERT_BOOK",
                Conversion.ModelToSqlParams(model));
        }

        public List<BookVM> Select()
        {
            return ExcReaderProc("SELECT_BOOK").ToListViewModel<BookVM>();
        }

        public void Update(Book model)
        {
            ExcNonQueryProc("UPDATE_BOOK",
                Conversion.ModelToSqlParams(model));
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
