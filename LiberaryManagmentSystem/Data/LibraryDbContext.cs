using LiberaryManagmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LiberaryManagmentSystem.Data
{
    public class LibraryDbContext: DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }
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
                .HasIndex(a=>a.FullName)
                .IsUnique();
            modelBuilder.Entity<Author>()
                .HasData(
                new Author { Id = 1, FullName = "Khaled Mohamed Mohamed Ahmed", Email = "khaled@yahoo.com" },
                new Author { Id = 2, FullName = "Mohamed Mohamed Mohamed Ahmed", Email = "Mohamed@yahoo.com" }
                );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Mystery Book", Genre = Genre.Mystery, AuthorId = 1 },
                new Book { Id = 2, Title = "Sci-Fi Journey", Genre = Genre.SciFi, AuthorId = 2 }
            );


        }

    }
}
