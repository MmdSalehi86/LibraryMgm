using LibraryMgm.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryMgm.Model.Validations
{
    public class BookListValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var bookList = (List<Book>)value;

            if (bookList.Count == 0)
            {
                ErrorMessage = "حداقل یک کتاب انتخاب کنید";
                return false;
            }
            else
                return true;
        }
    }
}