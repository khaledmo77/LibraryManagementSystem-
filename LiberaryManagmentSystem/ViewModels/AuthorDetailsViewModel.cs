namespace LiberaryManagmentSystem.ViewModels
{
    public class AuthorDetailsViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string? Website { get; set; }

        public string? Bio { get; set; }

        public List<BookMiniViewModel> Books { get; set; } = new();
    }
}
