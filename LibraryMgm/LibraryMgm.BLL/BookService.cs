using LibraryMgm.DataAccess;
using LibraryMgm.Model.BookModel;
using LibraryMgm.Model.Entities;
using System.Collections.Generic;
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
                opResult.Message = model.ErrorMessage;
            }
            else
            {
                var existsResult = CheckExists(model.Name);
                if (!existsResult.IsValid || !existsResult.ExcSucc) // اگر نام کتاب تکراری بود
                    return existsResult;
                else
                {
                    try
                    {
                        bookRepo.Insert(model);
                        opResult.Message = "عملیات ثبت کتاب موفقیت آمیز بود";
                    }
                    catch
                    {
                        opResult.ExcSucc = false;
                        opResult.Message = "خطا در افزودن کتاب";
                    }
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
                opResult.Message = model.ErrorMessage;
            }
            else
            {
                var existsResult = CheckExists(model.Name, model.Id);
                if (!existsResult.IsValid || !existsResult.ExcSucc) // اگر نام کتاب تکراری بود
                    return existsResult;
                try
                {
                    bookRepo.Update(model);
                    opResult.Message = "عملیات ویرایش کتاب موفقیت آمیز بود";
                }
                catch
                {
                    opResult.ExcSucc = false;
                    opResult.Message = "خطا در ویرایش کتاب";
                }
            }
            return opResult;
        }

        public OperationResult Delete(int id)
        {
            var opResult = new OperationResult();
            try
            {
                bookRepo.Delete(id);
                opResult.Message = "عملیات حذف کتاب موفقیت آمیز بود";
            }
            catch
            {
                opResult.ExcSucc = false;
                opResult.Message = "خطا در حذف کتاب";
            }
            return opResult;
        }

        public OperationResult<List<BookVM>> Select()
        {
            var opResult = new OperationResult<List<BookVM>>();
            try
            {
                opResult.Data = bookRepo.Select();
            }
            catch
            {
                opResult.ExcSucc = false;
                opResult.Message = "خطا در خواندن اطلاعات کتاب ها";
            }
            return opResult;
        }


        public OperationResult CheckExists(string name, int? id = null)
        {
            var opResult = new OperationResult();
            try
            {
                var exists = bookRepo.CheckExists(name, id);
                opResult.IsValid = !exists;
                if (exists)
                    opResult.Message = "نام کتاب تکراری است";
            }
            catch
            {
                opResult.Message = "خطا هنگام بررسی اطلاعات";
                opResult.ExcSucc = false;
            }
            return opResult;
        }
    }
}
