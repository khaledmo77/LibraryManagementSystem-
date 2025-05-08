using LiberaryManagmentSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace LiberaryManagmentSystem.Validations
{
    public class ReturningDateAfterBorrowingDateValidationAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var Transaction = (BorrowingTransaction)validationContext.ObjectInstance;
            if (Transaction.ReturnedDate.HasValue && Transaction.ReturnedDate.Value < Transaction.BorrowedDate)
            {
                return new ValidationResult("Returned date cannot be earlier than the borrowed date.");
            }
            return ValidationResult.Success;
        }
    }
}
