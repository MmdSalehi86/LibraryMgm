using LibraryMgm.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryMgm.DataAccess.EF
{
    public class TranslatorRepoEF : ITranslatorCrud
    {
        LibMgmDataContext dbContext;

        public TranslatorRepoEF()
        {
            dbContext = new LibMgmDataContext();
        }

        public bool CheckExists(string firstName, string lastName, int? id = null)
        {
            var result = dbContext.Translators
                            .Where(t => t.FirstName.Equals(firstName) && t.LastName.Equals(lastName));
            if (id.HasValue)
                result = result.Where(t => t.Id != id.Value);
            return result.Any();
        }

        public void Delete(int id)
        {
            var trn = dbContext.Translators.Where(t => t.Id == id).Single();
            dbContext.Translators.Remove(trn);
            dbContext.SaveChanges();
        }

        public void Insert(InsertTranslatorModel model)
        {
            dbContext.Translators.Add(new Translator
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Location = model.Location,
            });
            dbContext.SaveChanges();
        }

        public List<TranslatorVM> Select()
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

        public void Update(Translator model)
        {
            var trn = dbContext.Translators.Where(t => t.Id == model.Id).Single();
            trn.FirstName = model.FirstName;
            trn.LastName = model.LastName;
            trn.Location = model.Location;
            dbContext.SaveChanges();
        }
    }
}
