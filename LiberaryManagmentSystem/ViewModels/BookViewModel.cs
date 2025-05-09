﻿namespace LiberaryManagmentSystem.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public string? Description { get; set; }

        public string AuthorName { get; set; }

        public bool IsBorrowed
        {
            get; set;
        }
    }
}
