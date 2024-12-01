using LibraryMgm.Model.Entities;
using System.Collections.Generic;

namespace LibraryMgm.DataAccess
{
    public interface ITranslatorCrud
    {
        void Insert(InsertTranslatorModel model);
        List<TranslatorVM> Select();
        void Update(Translator model);
        void Delete(int id);
        bool CheckExists(string firstName, string lastName, int? id = null);
    }
}
