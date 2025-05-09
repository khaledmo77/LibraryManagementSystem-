using LiberaryManagmentSystem.Models;

namespace LiberaryManagmentSystem.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;

        public string? Description { get; set; }
        public Author Author { get; set; } = null!;
        public bool IsBorrowed
        {
            get; set;
        }
    }
}
