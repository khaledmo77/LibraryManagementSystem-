using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LiberaryManagmentSystem.Models;

namespace LiberaryManagmentSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowingTransaction> BorrowingTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>()
                .HasIndex(a => a.Email)
                .IsUnique();
            modelBuilder.Entity<Author>()
                .HasIndex(a => a.FullName)
                .IsUnique();

            modelBuilder.Entity<Author>().HasData(
       new Author { Id = 1, FullName = "Khaled Mohamed Mohamed Ahmed", Email = "khaled@yahoo.com" },
       new Author { Id = 2, FullName = "Mohamed Mohamed Mohamed Ahmed", Email = "Mohamed@yahoo.com" },
       new Author { Id = 3, FullName = "Sara Ahmed Youssef", Email = "sara@gmail.com" },
       new Author { Id = 4, FullName = "Ali Hassan", Email = "ali.hassan@gmail.com" },
       new Author { Id = 5, FullName = "Layla Mahmoud", Email = "layla@yahoo.com" },
       new Author { Id = 6, FullName = "Tariq Nabil", Email = "tariq.nabil@gmail.com" },
       new Author { Id = 7, FullName = "Huda Ibrahim", Email = "huda.ibrahim@hotmail.com" },
       new Author { Id = 8, FullName = "Yousef Adel", Email = "yousef.adel@gmail.com" },
       new Author { Id = 9, FullName = "Fatma Said", Email = "fatma.said@yahoo.com" },
       new Author { Id = 10, FullName = "Nour El-Din", Email = "nour.eldin@gmail.com" }
   );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Mystery Book", Genre = Genre.Mystery, AuthorId = 1 },
                new Book { Id = 2, Title = "Sci-Fi Journey", Genre = Genre.SciFi, AuthorId = 2 },
                new Book { Id = 3, Title = "The Desert Rose", Genre = Genre.Romance, AuthorId = 3 },
                new Book { Id = 4, Title = "Echoes of War", Genre = Genre.Historical, AuthorId = 4 },
                new Book { Id = 5, Title = "Galaxy Chronicles", Genre = Genre.SciFi, AuthorId = 5 },
                new Book { Id = 6, Title = "The Final Clue", Genre = Genre.Mystery, AuthorId = 6 },
                new Book { Id = 7, Title = "Whispers in the Dark", Genre = Genre.Horror, AuthorId = 7 },
                new Book { Id = 8, Title = "Algorithms for Life", Genre = Genre.NonFiction, AuthorId = 8 },
                new Book { Id = 9, Title = "The Eternal Bond", Genre = Genre.Romance, AuthorId = 9 },
                new Book { Id = 10, Title = "Beyond the Stars", Genre = Genre.SciFi, AuthorId = 10 },
                new Book { Id = 11, Title = "Cairo Secrets", Genre = Genre.Mystery, AuthorId = 1 },
                new Book { Id = 12, Title = "Nile Nightmares", Genre = Genre.Horror, AuthorId = 2 },
                new Book { Id = 13, Title = "Love in Alexandria", Genre = Genre.Romance, AuthorId = 3 },
                new Book { Id = 14, Title = "Redemption Path", Genre = Genre.Drama, AuthorId = 4 },
                new Book { Id = 15, Title = "Secrets of AI", Genre = Genre.NonFiction, AuthorId = 5 }
            );
        }
    }
}
