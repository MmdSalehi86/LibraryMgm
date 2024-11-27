using LibraryMgm.DataAccess.ADO;
using LibraryMgm.DataAccess.EF;
using LibraryMgm.Model;
using LibraryMgm.Model.Conversion;
using LibraryMgm.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DbConfig = LibraryMgm.Model.DbConfiguration;
using MMDb = LibraryMgm.DataAccess.MemoryDb.LibMgmMMDb;

namespace LibraryMgm.DataAccess
{
    public class TranslatorRepo : DbSqlCommands
    {
        LibMgmDataContext dbContext = null;

        public TranslatorRepo()
        {
            if (DbConfiguration.ConnectionMethod == ConnectionMethods.EF)
                dbContext = new LibMgmDataContext();
        }

        public void Insert(InsertTranslatorModel model)
        {
            if (dbContext == null)
            {
                if (DbConfig.ConnectionMethod == ConnectionMethods.MemoryDb)
                    InsertMM(model);
                else
                {
                    ExcNonQueryProc("INSERT_TRANSLATOR",
                        Conversion.ModelToSqlParams(model).ToArray());
                }
            }
            else
                InsertEF(model);
        }
        public void InsertEF(InsertTranslatorModel model)
        {
            dbContext.Translators.Add(new Translator
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Location = model.Location,
            });
            dbContext.SaveChanges();
        }
        private void InsertMM(InsertTranslatorModel model)
        {
            int id = 1;
            var count = MMDb.Translators.Count;
            if (count != 0)
                id = MMDb.Translators[count - 1].Id + 1;

            MMDb.Translators.Add(new Translator
            {
                Id = id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Location = model.Location,
            });
            MMDb.HasChange = true;
        }

        public List<TranslatorVM> Select()
        {
            if (dbContext == null)
            {
                if (DbConfig.ConnectionMethod == ConnectionMethods.MemoryDb)
                    return SelectMM();
                else
                {
                    var reader = ExcReaderProc("SELECT_TRANSLATOR");
                    var list = reader.ToListViewModel<TranslatorVM>();
                    reader.Close();
                    return list;
                }
            }
            return SelectEF();
        }
        public List<TranslatorVM> SelectEF()
        {
            return dbContext.Translators.Select(
                t => new TranslatorVM
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    Location = t.Location,
                }).ToList();
        }
        public List<TranslatorVM> SelectMM()
        {
            return MMDb.Translators.Select(
                t => new TranslatorVM
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    Location = t.Location,
                }).ToList();
        }


        public void Update(Translator model)
        {
            if (dbContext == null)
            {
                if (DbConfig.ConnectionMethod == ConnectionMethods.MemoryDb)
                    UpdateMM(model);
                ExcNonQueryProc("UPDATE_TRANSLATOR",
                    Conversion.ModelToSqlParams(model).ToArray());
            }
            else
                UpdateEF(model);
        }
        public void UpdateEF(Translator model)
        {
            var trn = dbContext.Translators.Where(t => t.Id == model.Id).Single();
            trn.FirstName = model.FirstName;
            trn.LastName = model.LastName;
            trn.Location = model.Location;
            dbContext.SaveChanges();
        }
        public void UpdateMM(Translator model)
        {
            var trn = MMDb.Translators.Where(t => t.Id == model.Id).Single();
            trn.FirstName = model.FirstName;
            trn.LastName = model.LastName;
            trn.Location = model.Location;
            MMDb.HasChange = true;
        }

        
        public void Delete(int id)
        {
            if (dbContext == null)
            {
                if (DbConfig.ConnectionMethod == ConnectionMethods.MemoryDb)
                    DeleteMM(id);
                else
                {
                    ExcNonQuerySql("DELETE_TRANSLATOR",
                        new SqlParameter("Id", id));
                }
            }
            else
                DeleteEF(id);
        }
        private void DeleteEF(int id)
        {
            var trn = dbContext.Translators.Where(t => t.Id == id).Single();
            dbContext.Translators.Remove(trn);
            dbContext.SaveChanges();
        }
        private void DeleteMM(int id)
        {
            MMDb.Translators.Remove(
                MMDb.Translators.Where(t => t.Id == id).Single());
            for (int i = 0; i < MMDb.Books.Count; i++)
                if (MMDb.Books[i].TranslatorId == id)
                    MMDb.Books.RemoveAt(i--);
            MMDb.HasChange = true;
        }


        public bool CheckExists(string firstName, string lastName, int? id = null)
        {
            if (dbContext == null)
            {
                if (DbConfig.ConnectionMethod == ConnectionMethods.MemoryDb)
                    return CheckExistsMM(firstName, lastName, id);

                else
                {
                    return ExcScalarFunc<bool>("dbo.CHECK_EXISTS_TRANSLATOR",
                        new SqlParameter("@FirstName", firstName),
                        new SqlParameter("@LastName", lastName),
                        new SqlParameter("@Id", id.HasValue ? (object)id.Value : DBNull.Value));
                }
            }
            else
                return CheckExistsEF(firstName, lastName, id);
        }
        public bool CheckExistsEF(string firstName, string lastName, int? id = null)
        {
            var result = dbContext.Translators
                .Where(t => t.FirstName.Equals(firstName) && t.LastName.Equals(lastName));
            if (id.HasValue)
                result = result.Where(t => t.Id != id.Value);
            return result.Any();
        }
        public bool CheckExistsMM(string firstName, string lastName, int? id = null)
        {
            var result = MMDb.Translators
                .Where(t => t.FirstName.Equals(firstName) && t.LastName.Equals(lastName));
            if (id.HasValue)
                result.Where(t => t.Id != id.Value);
            return result.Any();
        }
    }
}
