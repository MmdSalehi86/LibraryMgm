﻿using LibraryMgm.Model.Entities;
using LibraryMgm.Model.Validations;
using System.ComponentModel.DataAnnotations;

namespace LibraryMgm.Model.BookModel
{
    public sealed class InsertBookModel : BaseValidation
    {
        [Required(ErrorMessage = "نام کتاب نباید خالی باشد")]
        [MaxLength(128, ErrorMessage = "نام باید حداکثر 128 کاراکتر باشد")]
        public string Name { get; set; }

        [RegularExpression(@"^\d*[1-9]\d*$", ErrorMessage = "سال چاپ را وارد کنید")]
        public int Year { get; set; }

        [Required(ErrorMessage = "وارد کردن ناشر اجباری است")]
        [MaxLength(128, ErrorMessage = "نام ناشر نباید بیشتر از 128 کاراکتر باشد")]
        public string Publisher { get; set; }

        [RegularExpression(@"^\d*[1-9]\d*$", ErrorMessage = "انتخاب مترجم اجباری است")]
        public int TranslatorId { get; set; }
    }
}
