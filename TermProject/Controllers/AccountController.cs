using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TermProject.Models;
using Microsoft.AspNetCore.Identity;

// This code is based on the book with minor changes
namespace TermProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByEmailAsync(details.Email);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result =
                        await _signInManager.PasswordSignInAsync(user, details.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }

                ModelState.AddModelError(nameof(LoginViewModel.Email),
                    "Invalid email or password and I ain't telling you which!");
            }

            return View(details);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied() => View();

        public ViewResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserViewModel createUserViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    FirstName = createUserViewModel.FirstName,
                    LastName = createUserViewModel.LastName,
                    UserName = createUserViewModel.Email,
                    Email = createUserViewModel.Email
                };
                IdentityResult result = await _userManager.CreateAsync(user, createUserViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View("Register", createUserViewModel);
        }
    }
}
