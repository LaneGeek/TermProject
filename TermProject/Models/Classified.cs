using System.ComponentModel.DataAnnotations;

namespace TermProject.Models
{
    public class Classified
    {
        public int Id { get; set; }

        // The properties below need input validation
        [Required(ErrorMessage = "Please enter the item.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must be between 2 and 20 characters long!")]
        public string Item { get; set; }

        [Required(ErrorMessage = "Please enter the description.")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Must be between 2 and 40 characters long!")]
        public string Text { get; set; }
    }
}
