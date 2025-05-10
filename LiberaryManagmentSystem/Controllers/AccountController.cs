using LiberaryManagmentSystem.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    // Registration actions
    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "Email is already taken.");
                return View(model);
            }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FullName = model.FullName };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync("User"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("User"));
                }

                await _userManager.AddToRoleAsync(user, "User");

                // Add claims
                await _userManager.AddClaimAsync(user, new Claim("FullName", user.FullName));

                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Book");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(model);
    }


    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public IActionResult AdminDashboard()
    {
        return View("AdminDashboard");
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var roles = await _userManager.GetRolesAsync(user);

          
                var claims = new List<Claim>
                  {
                new Claim("UserID", user.Id.ToString())
                   };
                claims.Add(new Claim("FullName", user.FullName));
                var identity = new ClaimsIdentity(claims, "login");
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);
                if (roles.Contains("Admin"))
                    return RedirectToAction("AdminDashboard", "Account");
                else
                    return RedirectToAction("AccessDenied", "Account");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
        }
        return View(model);
    }



    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }


    private async Task CreateRolesIfNeeded()
    {
        var roles = new[] { "User", "Admin" };
        foreach (var role in roles)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }


    public async Task<IActionResult> EnsureRolesExist()
    {
        await CreateRolesIfNeeded();
        return RedirectToAction("Index", "Home");
    }
}
