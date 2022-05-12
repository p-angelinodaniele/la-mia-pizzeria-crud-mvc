using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Utils.Validation
{
    public class MoreThanFiveWords : ValidationAttribute
    {
        protected override ValidationResult IsValid(
           object value, ValidationContext validationContext)
        {
            string fieldValue = (string)value;

            if (fieldValue == null || fieldValue.Trim().Split(" ").Length-1 !=4)
            {
                return new ValidationResult("Il campo deve contenere almeno cinque parole");
            }

            return ValidationResult.Success;
        }
    }
}