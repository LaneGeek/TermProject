using Microsoft.AspNetCore.Mvc;
using TermProject.Models;

namespace TermProject.Controllers
{
    public class ClassifiedController : Controller
    {
        private readonly IRepository _repository;

        // Dependency injection
        public ClassifiedController(IRepository repository) => _repository = repository;

        public IActionResult Index() => View(_repository.Classifieds);

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(Classified classified)
        {
            if (ModelState.IsValid)
            {
                // Add to the repository
                _repository.AddClassified(classified);

                return View("Index", _repository.Classifieds);
            }
            // Otherwise validation error
            return View();
        }
    }
}
