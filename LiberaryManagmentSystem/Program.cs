using LiberaryManagmentSystem.AutoMapper;
using LiberaryManagmentSystem.Data;
using LiberaryManagmentSystem.Repositories.Implementations;
using LiberaryManagmentSystem.Repositories.Interfaces;
using LiberaryManagmentSystem.Services.Implementation;
using LiberaryManagmentSystem.Services.Interfaces;
using LiberaryManagmentSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

public class Program
{
    public static async Task Main(string[] args) 
    {
        var builder = WebApplication.CreateBuilder(args);

        // Dependency Injection
        builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
        builder.Services.AddScoped<IBookRepository, BookRepository>();
        builder.Services.AddScoped<IBorrowingTransactionRepository, BorrowingTransactionRepository>();
        builder.Services.AddScoped<IAuthorService, AuthorService>();
        builder.Services.AddScoped<IBookService, BookService>();
        builder.Services.AddScoped<IBorrowingTransactionService, BorrowingTransactionService>();
        builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

        // Views and JSON options
        builder.Services.AddControllersWithViews()
              .AddJsonOptions(options =>
              {
                  options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
              });

        // InMemory DB
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("LibraryDb"));

        // Identity
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        var app = builder.Build();

        // Ensure DB Created
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.EnsureCreated();

            // Seed roles & admin user
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles = { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var adminEmail = "admin@khaled.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser { UserName = adminEmail, Email = adminEmail, FullName = "Admin User" };
                var result = await userManager.CreateAsync(adminUser, "Admin@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                    await userManager.AddClaimAsync(adminUser, new Claim("FullName", adminUser.FullName));
                }
            }
        }

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles(); 

        app.UseRouting();
        app.UseAuthentication(); 
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Book}/{action=Index}/{id?}");

        app.Run();
    }
}
