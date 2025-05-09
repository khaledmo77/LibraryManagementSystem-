using LiberaryManagmentSystem.Validations;
using System.ComponentModel.DataAnnotations;

namespace LiberaryManagmentSystem.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name Is Required")]
        [FullNameValidation]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress(ErrorMessage ="Invalid Email Format")]
        public string Email { get; set; } = string.Empty;
        public string? Website { get; set; }
        [MaxLength(300)]
        public string? Bio { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
