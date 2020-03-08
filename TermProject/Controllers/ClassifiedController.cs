using Microsoft.AspNetCore.Mvc;

namespace TermProject.Controllers
{
    public class ClassifiedController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Search() => View();

        public IActionResult Add() => View();
    }
}
