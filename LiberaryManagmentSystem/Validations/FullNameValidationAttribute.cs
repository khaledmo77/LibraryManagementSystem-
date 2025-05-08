using System.ComponentModel.DataAnnotations;

namespace LiberaryManagmentSystem.Validations
{
    public class FullNameValidationAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var FullName = value as string;
            if (string.IsNullOrWhiteSpace(FullName)) 
      
                return new ValidationResult("Full name is required.");
            var Parts = FullName.Trim().Split(' ',StringSplitOptions.RemoveEmptyEntries);
           if (Parts.Length != 4)
                return new ValidationResult("Full name must consist of exactly 4 words.");
           if (Parts.Any(Parts=>Parts.Length<2))
                return new ValidationResult("Each part of the name must be at least 2 characters.");
            return ValidationResult.Success;
        }
    }
}
