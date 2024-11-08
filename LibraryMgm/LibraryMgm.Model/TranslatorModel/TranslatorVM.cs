using LibraryMgm.Model.Validations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryMgm.Model.Entities
{
    public class TranslatorVM : BaseValidation
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get {  return $"{FirstName} {LastName}"; } }

        public string Location { get; set; }
    }
}
