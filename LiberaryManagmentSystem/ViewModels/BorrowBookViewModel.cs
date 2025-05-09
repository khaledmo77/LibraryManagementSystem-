using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LiberaryManagmentSystem.ViewModels
{
    public class BorrowBookViewModel
    {
        [Required]
        public int BookId { get; set; }

        public DateTime BorrowedDate { get; set; } = DateTime.Now;

        public IEnumerable<SelectListItem>? Books { get; set; }
    }
}
