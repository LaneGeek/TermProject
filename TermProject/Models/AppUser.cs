using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TermProject.Models
{
    public class AppUser : IdentityUser
    {
        [Required(ErrorMessage = "Please enter your first name please.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First Name must be between 2 and 20 characters long!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name please.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Last Name must be between 2 and 30 characters long!")]
        public string LastName { get; set; }
    }
}
