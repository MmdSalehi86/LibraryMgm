using System.ComponentModel.DataAnnotations;

namespace LibraryMgm.Model.Validations
{
    internal class MobileValidationAttribute : ValidationAttribute
    {
        bool isRequired;
        public MobileValidationAttribute(bool isRequired)
        {
            this.isRequired = isRequired;
        }

        public override bool IsValid(object value)
        {
            string mobile = value.ToString();

            if (string.IsNullOrEmpty(mobile))
            {
                if (isRequired)
                {
                    ErrorMessage = "شماره موبایل اجباری است";
                    return false;
                }
                else
                    return true;
            }
            if (mobile.Length != 11 || !mobile.StartsWith("09"))
            {
                ErrorMessage = "شماره موبایل نامعتبر است";
                return false;
            }
            return true;
        }
    }
}
