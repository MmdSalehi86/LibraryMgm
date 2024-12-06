using LibraryMgm.DataAccess;
using LibraryMgm.DataAccess.ADO;
using LibraryMgm.DataAccess.EF;
using LibraryMgm.Model.Entities;
using System.Collections.Generic;
using LibraryMgm.DataAccess.MemoryDb;

namespace LibraryMgm.BLL.Services
{
    public sealed class TranslatorService
    {
        ITranslatorCrud trnRepo;

        public TranslatorService()
        {
            if (DbConfig.ConnectionMethod == ConnectionMethods.ADO)
                trnRepo = new TranslatorRepoAdo();
            else if (DbConfig.ConnectionMethod == ConnectionMethods.EF)
                trnRepo = new TranslatorRepoEF();
            else
                trnRepo = new TranslatorRepoMM();
        }

        public OperationResult Insert(InsertTranslatorModel model)
        {
            var opResult = new OperationResult();
            if (!model.IsValid)
            {
                opResult.IsValid = false;
                opResult.Message = model.ErrorMessage;
            }
            else
            {
                var existsResult = CheckExists(model.FirstName, model.LastName);
                if (!existsResult.IsValid || !existsResult.ExcSucc) // اگر نام مترجم تکراری بود
                {
                    if (!existsResult.IsValid)
                        existsResult.ExcSucc = existsResult.IsValid;
                    return existsResult;
                }
                try
                {
                    trnRepo.Insert(model);
                    opResult.Message = "عملیات ثبت مترجم موفقیت آمیز بود";
                }
                catch
                {
                    opResult.ExcSucc = false;
                    opResult.Message = "خطا در افزودن مترجم";
                }
            }
            return opResult;
        }

        public OperationResult Update(Translator model)
        {
            var opResult = new OperationResult();
            if (!model.IsValid)
            {
                opResult.IsValid = false;
                opResult.Message = model.ErrorMessage;
            }
            else
            {
                var existsResult = CheckExists(model.FirstName, model.LastName, model.Id);
                if (!existsResult.IsValid || !existsResult.ExcSucc) // اگر نام کتاب مترجم بود
                {
                    if (!existsResult.IsValid)
                        existsResult.ExcSucc = existsResult.IsValid;
                    return existsResult;
                }
                try
                {
                    trnRepo.Update(model);
                    opResult.Message = "عملیات ویرایش مترجم موفقیت آمیز بود";
                }
                catch
                {
                    opResult.ExcSucc = false;
                    opResult.Message = "خطا در ویرایش مترجم";
                }
            }
            return opResult;
        }

        public OperationResult Delete(int id)
        {
            var opResult = new OperationResult();
            try
            {
                trnRepo.Delete(id);
                opResult.Message = "عملیات حذف مترجم موفقیت آمیز بود";
            }
            catch
            {
                opResult.ExcSucc = false;
                opResult.Message = "خطا در حذف مترجم";
            }
            return opResult;
        }

        public OperationResult<List<TranslatorVM>> Select()
        {
            var opResult = new OperationResult<List<TranslatorVM>>();
            try
            {
                opResult.Data = trnRepo.Select();
            }
            catch
            {
                opResult.ExcSucc = false;
                opResult.Message = "خطا در خواندن اطلاعات مترجمان";
            }
            return opResult;
        }


        public OperationResult CheckExists(string firstName, string lastName, int? id = null)
        {
            var opResult = new OperationResult();
            try
            {
                opResult.IsValid = !trnRepo.CheckExists(firstName, lastName, id);
                opResult.Message = "نام مترجم تکراری است";
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
