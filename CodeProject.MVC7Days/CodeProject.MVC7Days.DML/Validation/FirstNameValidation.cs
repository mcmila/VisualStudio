using System.ComponentModel.DataAnnotations;

namespace CodeProject.MVC7Days.Models.Validation
{
    public class FirstNameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) // Checking for Empty Value
            {
                return new ValidationResult("Please Provide First Name");
            }
            else
            {
                if (!value.ToString().Contains("@"))
                {
                    return new ValidationResult("First Name should contain @");
                }
            }
            return ValidationResult.Success;
        }
    }
}