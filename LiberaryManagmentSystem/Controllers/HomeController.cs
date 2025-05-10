using LiberaryManagmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Index Action - Display login options
    public IActionResult Index()
    {
        return View();
    }

    // Redirect to appropriate login page based on the user's role choice
    [HttpPost]
    public IActionResult LoginAs(string role)
    {
        if (role == "Admin")
        {
            return RedirectToAction("Login", "Account", new { role = "Admin" });
        }
        else if (role == "User")
        {
            return RedirectToAction("Login", "Account", new { role = "User" });
        }
        else
        {
            // Handle invalid role selection
            return RedirectToAction("Index");
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
