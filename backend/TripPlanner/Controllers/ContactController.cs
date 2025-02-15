using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TripPlanner.Models;

namespace TripPlanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly TripPlannerDbContext _context;

        public ContactController(TripPlannerDbContext context)
        {
            _context = context;
        }

        // 🟢 POST: api/Contact
        [HttpPost]
        public async Task<IActionResult> PostContactMessage([FromBody] ContactMessage contactMessage)
        {
            if (contactMessage == null)
                return BadRequest(new { error = "Invalid request data." });

            try
            {
                contactMessage.Id = 0; // Ensures EF Core does not use the provided ID
                _context.ContactMessages.Add(contactMessage);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Message received successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal Server Error", details = ex.Message });
            }
        }

        // 🟢 GET: api/Contact (Optional - To fetch all messages)
        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var messages = await _context.ContactMessages.ToListAsync();
            return Ok(messages);
        }
    }
}
