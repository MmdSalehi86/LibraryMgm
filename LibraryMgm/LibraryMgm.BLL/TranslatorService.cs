using LibraryMgm.Model.BookModel;
using LibraryMgm.Model.Entities;

namespace LibraryMgm.BLL
{
    public class TranslatorService
    {
        public OperationResult Insert(InsertTranslatorModel book)
        {
            return new OperationResult();
        }

        public OperationResult Update(Translator book)
        {
            return new OperationResult();
        }

        public OperationResult Delete(int id)
        {
            return new OperationResult();
        }

        public OperationResult<TranslatorVM> Select()
        {
            return new OperationResult<TranslatorVM>();
        }
    }
}
