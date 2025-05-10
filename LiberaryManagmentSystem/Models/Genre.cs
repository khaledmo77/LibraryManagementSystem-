using System.ComponentModel.DataAnnotations;

namespace LiberaryManagmentSystem.Models
{
    public enum Genre
    {
        [Display(Name = "Unknown")] Unknown = 0,
        [Display(Name = "Adventure")] Adventure = 1,
        [Display(Name = "Mystery")] Mystery = 2,
        [Display(Name = "Thriller")] Thriller = 3,
        [Display(Name = "Romance")] Romance = 4,
        [Display(Name = "Science Fiction")] SciFi = 5,
        [Display(Name = "Fantasy")] Fantasy = 6,
        [Display(Name = "Biography")] Biography = 7,
        [Display(Name = "History")] History = 8,
        [Display(Name = "Self Help")] SelfHelp = 9,
        [Display(Name = "Children's Books")] Children = 10,
        [Display(Name = "Young Adult")] YoungAdult = 11,
        [Display(Name = "Poetry")] Poetry = 12,
        [Display(Name = "Drama")] Drama = 13,
        [Display(Name = "Non-Fiction")] NonFiction = 14,
        [Display(Name = "Historical")] Historical = 15,
        [Display(Name = "Horror")] Horror = 16,
    }
}
