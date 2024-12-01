using LibraryMgm.Model.Conversion;
using LibraryMgm.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LibraryMgm.DataAccess.ADO
{
    public class TranslatorRepoAdo : DbSqlCommands, ITranslatorCrud
    {
        public bool CheckExists(string firstName, string lastName, int? id = null)
        {
            return ExcScalarFunc<bool>("dbo.CHECK_EXISTS_TRANSLATOR",
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@Id", id.HasValue ? (object)id.Value : DBNull.Value));
        }

        public void Delete(int id)
        {
            ExcNonQuerySql("DELETE_TRANSLATOR",
                new SqlParameter("Id", id));
        }

        public void Insert(InsertTranslatorModel model)
        {
            ExcNonQueryProc("INSERT_TRANSLATOR",
                Conversion.ModelToSqlParams(model).ToArray());
        }

        public List<TranslatorVM> Select()
        {
            var reader = ExcReaderProc("SELECT_TRANSLATOR");
            var list = reader.ToListViewModel<TranslatorVM>();
            reader.Close();
            return list;
        }

        public void Update(Translator model)
        {
            ExcNonQueryProc("UPDATE_TRANSLATOR",
                Conversion.ModelToSqlParams(model).ToArray());
        }
    }
}
