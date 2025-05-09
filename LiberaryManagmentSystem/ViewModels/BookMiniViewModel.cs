using LiberaryManagmentSystem.Models;

namespace LiberaryManagmentSystem.ViewModels
{
    public class BookMiniViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public Genre Genre { get; set; }
        public string? Description { get; set; }

    }
}
