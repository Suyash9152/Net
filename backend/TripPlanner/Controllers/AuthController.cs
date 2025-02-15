using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripPlanner.Models;

namespace TripPlanner.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TripPlannerDbContext _context;

        public AuthController(TripPlannerDbContext context)
        {
            _context = context;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Register([FromBody] Signup user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Check if user already exists
            var existingUser = await _context.Signup.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (existingUser != null)
                return Conflict("Email already exists.");

            _context.Signup.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login loginRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid request data");

            // Find user by email and password
            var user = await _context.Signup
                .FirstOrDefaultAsync(u => u.Email == loginRequest.Email && u.Password == loginRequest.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            // ✅ Return User Details Instead of Token
            return Ok(new
            {
                userId = user.Id,
                email = user.Email,
            });
        }
    }
}
