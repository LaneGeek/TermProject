using System.ComponentModel.DataAnnotations;

namespace TermProject.Models
{
    public class SuccessSecret
    {
        public int Id { get; set; }

        // The properties below need input validation
        [Required(ErrorMessage = "Please describe the success.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must be between 2 and 20 characters long!")]
        public string Success { get; set; }

        [Required(ErrorMessage = "Please share the secret to the success.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Must be between 2 and 30 characters long!")]
        public string Secret { get; set; }
    }
}
