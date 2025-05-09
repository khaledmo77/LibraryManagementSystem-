namespace LiberaryManagmentSystem.ViewModels
{
    public class BorrowingViewModel
    {
        public int Id { get; set; }

        public string BookTitle { get; set; }

        public string AuthorName { get; set; }

        public DateTime BorrowedDate { get; set; }

        public DateTime? ReturnedDate { get; set; }

        public string Status => ReturnedDate == null ? "Borrowed" : "Returned";
    }
}
