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
            ExcNonQueryProc("INSERT_TRANSLATOR",
                Conversion.ModelToSqlParams(model));
        }

        public List<TranslatorVM> Select()
        {
            return ExcReaderFunc("SELECT_TRANSLATOR").ToListViewModel<TranslatorVM>();
        }

        public void Update(Translator model)
        {
            ExcNonQueryProc("UPDATE_TRANSLATOR",
                Conversion.ModelToSqlParams(model));
        }

        public void Delete(int id)
        {
            ExcNonQuerySql("DELETE_TRANSLATOR",
                new SqlParameter("Id", id));
        }

        public bool CheckExists(string firstName, string lastName)
        {
            return ExcScalarFunc<bool>("dbo.CHECK_EXISTS_TRANSLATOR",
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName));
        }
    }
}
