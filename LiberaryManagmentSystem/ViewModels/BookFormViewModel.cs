using LiberaryManagmentSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LiberaryManagmentSystem.ViewModels
{
    public class BookFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string Title { get; set; }=string.Empty;

        [Required]
        public Genre Genre { get; set; }

        [MaxLength(300)]
        public string? Description { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public IEnumerable<SelectListItem>? Authors { get; set; }
    }
}
