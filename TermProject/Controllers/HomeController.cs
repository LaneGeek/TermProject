using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TermProject.Models;

namespace TermProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        
        public HomeController(UserManager<AppUser> userManager) => _userManager = userManager;

        public async Task<IActionResult> Index()
        {
            // Let's get the user's name and find out if an admin
            var user = await _userManager.GetUserAsync(User);
            bool userIsAdmin;
            if (user != null)
                userIsAdmin = await _userManager.IsInRoleAsync(user, "Admins");
            else
                userIsAdmin = false;

            // We need to send two items to the view so we wrap them in a tuple
            return View(new Tuple<AppUser, bool>(user, userIsAdmin));
        }

        public IActionResult About() => View();
    }
}
