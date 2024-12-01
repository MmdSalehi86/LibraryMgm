using LibraryMgm.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using MMDb = LibraryMgm.DataAccess.MemoryDb.LibMgmMMDb;

namespace LibraryMgm.DataAccess.MemoryDb
{
    internal class TranslatorRepoMM : ITranslatorCrud
    {
        public bool CheckExists(string firstName, string lastName, int? id = null)
        {
            var result = MMDb.Translators
                .Where(t => t.FirstName.Equals(firstName) && t.LastName.Equals(lastName));
            if (id.HasValue)
                result.Where(t => t.Id != id.Value);
            return result.Any();
        }

        public void Delete(int id)
        {
            MMDb.Translators.Remove(MMDb.Translators.Where(t => t.Id == id).Single());
            for (int i = 0; i < MMDb.Books.Count; i++)
                if (MMDb.Books[i].TranslatorId == id)
                    MMDb.Books.RemoveAt(i--);
            MMDb.HasChange = true;
        }

        public void Insert(InsertTranslatorModel model)
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
            var trn = MMDb.Translators.Where(t => t.Id == model.Id).Single();
            trn.FirstName = model.FirstName;
            trn.LastName = model.LastName;
            trn.Location = model.Location;
            MMDb.HasChange = true;
        }
    }
}
