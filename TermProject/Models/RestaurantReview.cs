using System.ComponentModel.DataAnnotations;

namespace TermProject.Models
{
    public class RestaurantReview
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the restaurant's name please.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must be between 2 and 20 characters long!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the city please.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must be between 2 and 20 characters long!")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter the country please.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must be between 2 and 20 characters long!")]
        public string Country { get; set; }

        [Range(1, 5, ErrorMessage = "Please choose stars to rate.")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Please enter some comments please.")]
        public string Comment { get; set; }
    }
}
