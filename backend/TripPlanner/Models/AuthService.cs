using System.Linq;
using System.Threading.Tasks;
using TripPlanner.Models;

namespace TripPlanner.Models;


public class AuthService
{
    private readonly TripPlannerDbContext _context;

    public AuthService(TripPlannerDbContext context)
    {
        _context = context;
    }

    // ✅ Register User (Signup)
    public async Task<bool> RegisterUser(Signup user)
    {
        // Check if email already exists
        if (_context.Signup.Any(u => u.Email == user.Email))
            return false;

        _context.Signup.Add(user);
        await _context.SaveChangesAsync();
        return true;
    }

    // ✅ Authenticate User (Login)
    public string Authenticate(Login user)
    {
        // Check if the user exists in the database
        var existingUser = _context.Signup.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

        if (existingUser != null)
        {
            return "mock-jwt-token"; // Replace this with actual JWT token logic if needed in the future
        }

        return null;
    }
}
