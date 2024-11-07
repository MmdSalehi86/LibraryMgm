using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryMgm.Model.Validations
{
    public class BaseValidation
    {
        List<ValidationResult> results;
        public bool IsValid
        {
            get
            {
                var context = new ValidationContext(this);
                results = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(this, context, results, true);
                return isValid;
            }
        }
        public string ErrorMessage
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in results)
                    sb.AppendLine(item.ErrorMessage);
                return sb.ToString();
            }
        }
    }
}
