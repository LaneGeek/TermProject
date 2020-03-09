using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TermProject.Models;

namespace TermProject.Controllers
{
    public class RestaurantReviewController : Controller
    {
        private readonly IRepository _repository;

        // Dependency injection
        public RestaurantReviewController(IRepository repository) => _repository = repository;

        public IActionResult Index() => View(_repository.RestaurantReviews);

        public IActionResult Search() => View();

        [HttpPost]
        public IActionResult Search(int rating) => View("Index", _repository.RestaurantReviews.Where(x => x.Rating == rating));

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(RestaurantReview restaurantReview)
        {
            if (ModelState.IsValid)
            {
                // Add to the repository
                _repository.AddRestaurantReview(restaurantReview);

                return View("Index", _repository.RestaurantReviews);
            }
            // Otherwise validation error
            return View();
        }
    }
}
