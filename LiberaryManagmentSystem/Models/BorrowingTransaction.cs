﻿using LiberaryManagmentSystem.Validations;
using System.ComponentModel.DataAnnotations;

namespace LiberaryManagmentSystem.Models
{
    public class BorrowingTransaction
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }
        [Required(ErrorMessage ="you should choose a book")]
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
        [Required(ErrorMessage ="Enter the date of borrowing")]
        public DateTime BorrowedDate { get; set; }
        [ReturningDateAfterBorrowingDateValidation(ErrorMessage = "Returned date cannot be earlier than the borrowed date.")]
        public DateTime? ReturnedDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
