using Microsoft.AspNetCore.Mvc;

namespace TermProject.Controllers
{
    public class SuccessSecretController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Search() => View();

        public IActionResult Add() => View();
    }
}