using LibraryMgm.Model.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryMgm.Model.Entities
{
    public class Book : BaseValidation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "نام کتاب نباید خالی باشد")]
        [MaxLength(128, ErrorMessage = "نام باید حداکثر 128 کاراکتر باشد")]
        public string Name { get; set; }

        [RegularExpression(@"^\d*[1-9]\d*$", ErrorMessage = "سال چاپ اجباری است")]
        public int Year { get; set; }

        [Required(ErrorMessage = "وارد کردن ناشر اجباری است")]
        [MaxLength(128, ErrorMessage = "نام ناشر نباید بیشتر از 128 کاراکتر باشد")]
        public string Publisher { get; set; }

        //[Required()]
        [RegularExpression(@"^\d*[1-9]\d*$", ErrorMessage = "انتخاب مترجم اجباری است")]
        public int TranslatorId { get; set; }

        [ForeignKey("TranslatorId")]
        public Translator Translator { get; set; }
    }
}
