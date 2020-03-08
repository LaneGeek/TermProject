using Microsoft.AspNetCore.Mvc;

namespace TermProject.Controllers
{
    public class RestaurantReviewController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Search() => View();

        public IActionResult Add() => View();
    }
}
