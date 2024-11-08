using LibraryMgm.DataAccess.ADO;
using LibraryMgm.Model.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using LibraryMgm.Model.Conversion;

namespace LibraryMgm.DataAccess
{
    public class TranslatorRepo : DbSqlCommands
    {
        public TranslatorRepo()
        {
        }

        public void Insert(InsertTranslatorModel model)
        {
            //TODO: need to Entity to SqlParameter
            ExcNonQueryProc("INSERT_TRANSLATOR",
                null);
        }

        public List<TranslatorVM> Select()
        {
            ExcReaderFunc("SELECT_TRANSLATOR").ToViewModel();
        }

        public void Update(Translator translator)
        {
            //TODO: need to Entity to SqlParameter
            ExcNonQueryProc("UPDATE_TRANSLATOR", null
                );
        }

        public void Delete(int id)
        {
            ExcNonQuerySql("DELETE FROM Translator WHERE Id=@Id",
                new SqlParameter("Id", id));
        }
    }
}
