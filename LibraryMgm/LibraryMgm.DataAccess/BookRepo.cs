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
            //TODO: need to Entity to SqlParameter
            ExcNonQueryProc("INSERT_BOOK",
                null);
        }

        public List<TranslatorVM> Select()
        {
            return ExcReaderFunc("SELECT_BOOK").ToListViewModel<TranslatorVM>();
        }

        public void Update(Translator translator)
        {
            //TODO: need to Entity to SqlParameter
            ExcNonQueryProc("UPDATE_BOOK", null
                );
        }

        public void Delete(int id)
        {
            ExcNonQuerySql("DELETE FROM Book WHERE Id=@Id",
                new SqlParameter("Id", id));
        }
    }
}
