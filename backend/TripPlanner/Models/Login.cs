using System.ComponentModel.DataAnnotations;

namespace TripPlanner.Models
{
    public class Login
    {
        [Key]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
