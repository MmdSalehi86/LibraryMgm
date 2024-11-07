using LibraryMgm.Model.Entities;
using LibraryMgm.Model.Validations;
using System.ComponentModel.DataAnnotations;

namespace LibraryMgm.Model.BookModel
{
    public class InsertBookModel : BaseValidation
    {
        [Required(ErrorMessage = "نام کتاب نباید خالی باشد")]
        [MaxLength(128, ErrorMessage = "نام باید حداکثر 128 کاراکتر باشد")]
        public string Name { get; set; }

        [Required(ErrorMessage = "سال چاپ اجباری است")]
        public int Year { get; set; }

        [Required(ErrorMessage = "وارد کردن ناشر اجباری است")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "انتخاب مترجم اجباری است")]
        public Translator Translator { get; set; }
    }
}
