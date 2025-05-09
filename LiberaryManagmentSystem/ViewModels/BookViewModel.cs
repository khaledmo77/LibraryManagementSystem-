namespace LiberaryManagmentSystem.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string AuthorName { get; set; } = string.Empty;

        public bool IsBorrowed
        {
            get; set;
        }
    }
}
