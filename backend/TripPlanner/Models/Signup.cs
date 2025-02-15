

    using System.ComponentModel.DataAnnotations;

    namespace TripPlanner.Models
    {
        public class Signup
        {
            public int Id { get; set; }

            [Required]
            public string FullName { get; set; }

            [Required, EmailAddress]
            public string Email { get; set; }

            [Required]
            public string Password { get; set; } // 🔴 Storing plain text passwords is not secure, but following your request.

            [Required]
            public string PhoneNumber { get; set; }

            [Required]
            public string Country { get; set; }
        }
    }


