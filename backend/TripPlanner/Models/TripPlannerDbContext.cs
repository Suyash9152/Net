using Microsoft.EntityFrameworkCore;
using TripPlanner.Models;
using TripPlanner.Models.TripPlanner.Models;


public partial class TripPlannerDbContext : DbContext
{
    public TripPlannerDbContext()
    {
    }

    public TripPlannerDbContext(DbContextOptions<TripPlannerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Login> Login { get; set; } = null!;
    public virtual DbSet<Signup> Signup { get; set; } = null!;

   
    public DbSet<TravelPlan> TravelPlans { get; set; }
    public DbSet<ContactMessage> ContactMessages { get; set; }

    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("myCon");
        }
    }

   
}
