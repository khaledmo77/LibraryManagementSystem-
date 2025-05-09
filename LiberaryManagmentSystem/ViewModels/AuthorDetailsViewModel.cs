namespace LiberaryManagmentSystem.ViewModels
{
    public class AuthorDetailsViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }=string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? Website { get; set; }

        public string? Bio { get; set; }

        public List<BookMiniViewModel> Books { get; set; } = new();
    }
}
