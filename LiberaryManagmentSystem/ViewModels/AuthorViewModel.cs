using System.ComponentModel.DataAnnotations;

namespace LiberaryManagmentSystem.ViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        [RegularExpression(@"^(\w{2,}\s){3}\w{2,}$", ErrorMessage = "Full name must contain exactly four words with at least 2 characters each.")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string? Website { get; set; }

        [MaxLength(300)]
        public string? Bio { get; set; }
    }
}
