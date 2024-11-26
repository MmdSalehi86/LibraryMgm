using LibraryMgm.Model.Validations;
using System.ComponentModel.DataAnnotations;

namespace LibraryMgm.Model.Entities
{
    public sealed class InsertTranslatorModel : BaseValidation
    {
        [Required(ErrorMessage = "وارد کردن نام مترجم اجباری است")]
        [MaxLength(32, ErrorMessage = "نام ناید از 32 کاراکتر بیشتر باشد")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "وارد کردن نام خانوادگی مترجم اجباری است")]
        [MaxLength(32, ErrorMessage = "نام خانوادگی ناید از 32 کاراکتر بیشتر باشد")]
        public string LastName { get; set; }

        [MaxLength(128, ErrorMessage = "نام زندگی نباید بیشتر از 128 کاراکتر باشد")]
        public string Location { get; set; }
    }
}
