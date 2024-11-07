using LibraryMgm.Model.Validations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryMgm.Model.Entities
{
    public class BookLoan : BaseValidation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "نام مشتری اجباری است")]
        public string CustomerName { get; set; }

        [MobileValidation(true)]
        public string CustomerMobile { get; set; }

        [BookListValidation]
        public List<Book> Books { get; set; }
    }
}
