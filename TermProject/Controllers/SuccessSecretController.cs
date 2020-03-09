using Microsoft.AspNetCore.Mvc;
using TermProject.Models;

namespace TermProject.Controllers
{
    public class SuccessSecretController : Controller
    {
        private readonly IRepository _repository;

        // Dependency injection
        public SuccessSecretController(IRepository repository) => _repository = repository;

        public IActionResult Index() => View(_repository.SuccessSecrets);

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(SuccessSecret successSecret)
        {
            if (ModelState.IsValid)
            {
                // Add to the repository
                _repository.AddSuccessSecret(successSecret);

                return View("Index", _repository.SuccessSecrets);
            }
            // Otherwise validation error
            return View();
        }
    }
}
