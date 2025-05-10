namespace LiberaryManagmentSystem.ViewModels
{
    public class BorrowingViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }= string.Empty;

        public string BookTitle { get; set; } = string.Empty;

        public string AuthorName { get; set; } = string.Empty;

        public DateTime BorrowedDate { get; set; }

        public DateTime? ReturnedDate { get; set; }

        public string Status => ReturnedDate == null ? "Borrowed" : "Returned";
        public DateTime DueDate { get; set; }

    }
}
