using LiberaryManagmentSystem.Data;
using LiberaryManagmentSystem.Repositories.Implementations;
using LiberaryManagmentSystem.Repositories.Interfaces;
using LiberaryManagmentSystem.Services;
using LiberaryManagmentSystem.Services.Implementation;
using LiberaryManagmentSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LiberaryManagmentSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IAuthorRepository,AuthorRepository>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IBorrowingTransactionRepository, BorrowingTransactionRepository>();
            builder.Services.AddScoped<IAuthorService, AuthorService>();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IBorrowingTransactionService, BorrowingTransactionService>();

            builder.Services.AddControllersWithViews()
                  .AddJsonOptions(options =>
                  {
                      // Configure the JsonSerializer to handle circular references
                      options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                  });
            builder.Services.AddDbContext<LibraryDbContext>(options =>
            {
                options.UseInMemoryDatabase("LibraryDb")
                       .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
            });

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
                dbContext.Database.EnsureCreated();  
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
