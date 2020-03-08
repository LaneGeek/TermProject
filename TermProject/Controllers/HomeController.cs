using Microsoft.AspNetCore.Mvc;

namespace TermProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult About() => View();
    }
}
