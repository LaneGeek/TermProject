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

        public async Task<IActionResult> Index() => View(await _userManager.GetUserAsync(User));

        public IActionResult About() => View();
    }
}
