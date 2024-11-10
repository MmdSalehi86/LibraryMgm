using LibraryMgm.DataAccess.ADO;
using LibraryMgm.Model.BookModel;
using LibraryMgm.Model.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using LibraryMgm.Model.Conversion;

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
            return ExcReaderFunc("SELECT_BOOK").ToListViewModel<BookVM>();
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


        public bool CheckExists(string name)
        {
            return ExcScalarFunc<bool>("dbo.CHECK_EXISTS_BOOK",
                new SqlParameter("@Name", name));
        }
    }
}
