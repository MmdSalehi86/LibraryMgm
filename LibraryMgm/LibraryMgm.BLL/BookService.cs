using LibraryMgm.DataAccess;
using LibraryMgm.Model.BookModel;
using LibraryMgm.Model.Entities;
using System.Reflection;

namespace LibraryMgm.BLL
{
    public class BookService
    {
        BookRepo bookRepo;

        public BookService()
        {
            bookRepo = new BookRepo();
        }

        public OperationResult Insert(InsertBookModel model)
        {
            var opResult = new OperationResult();
            if (!model.IsValid)
            {
                opResult.IsValid = false;
                opResult.ErrorMessage = model.ErrorMessage;
            }
            else
            {
                try
                {
                    bookRepo.Insert(model);
                }
                catch
                {
                    opResult.ExcSucc = false;
                    opResult.ErrorMessage = "خطا در افزودن کتاب";
                }
            }
            return opResult;
        }

        public OperationResult Update(Book model)
        {
            var opResult = new OperationResult();
            if (!model.IsValid)
            {
                opResult.IsValid = false;
                opResult.ErrorMessage = model.ErrorMessage;
            }
            else
            {
                try
                {
                    bookRepo.Update(model);
                }
                catch
                {
                    opResult.ExcSucc = false;
                    opResult.ErrorMessage = "خطا در ویرایش کتاب";
                }
            }
            return opResult;
        }

        public OperationResult Delete(int id)
        {
            return new OperationResult();
        }

        public OperationResult<BookVM> Select()
        {
            return new OperationResult<BookVM>();
        }
    }
}
