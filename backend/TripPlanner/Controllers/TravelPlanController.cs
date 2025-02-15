using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripPlanner.Models;
using System.Threading.Tasks;
using TripPlanner.Models.TripPlanner.Models;

namespace TripPlanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelPlanController : ControllerBase
    {
        private readonly TripPlannerDbContext _context;

        public TravelPlanController(TripPlannerDbContext context)
        {
            _context = context;
        }

        // POST: api/TravelPlan
        [HttpPost]
        public async Task<IActionResult> CreateTravelPlan([FromBody] TravelPlan travelPlan)
        {
            if (travelPlan == null)
            {
                return BadRequest("Invalid travel plan data.");
            }

            try
            {
                _context.TravelPlans.Add(travelPlan);  // Add the new travel plan to the DbSet
                await _context.SaveChangesAsync();  // Save the changes to the database
                return CreatedAtAction(nameof(GetTravelPlanById), new { id = travelPlan.Id }, travelPlan);  // Return a response with status code 201
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/TravelPlan/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTravelPlanById(int id)
        {
            var travelPlan = await _context.TravelPlans.FindAsync(id);
            if (travelPlan == null)
            {
                return NotFound();
            }
            return Ok(travelPlan);
        }
    }
}
