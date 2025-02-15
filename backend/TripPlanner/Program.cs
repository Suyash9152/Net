using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using TripPlanner.Models;
using Microsoft.AspNetCore.SignalR;



var builder = WebApplication.CreateBuilder(args);

// Add Health checks (Optional for health monitoring)
builder.Services.AddHealthChecks();

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddSignalR();  // Register SignalR 

// Register the DbContext with SQL Server
builder.Services.AddDbContext<TripPlannerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("myCon")));

//// Enable CORS - Allow connections from the frontend React app
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy => policy
            .AllowAnyOrigin()  // ✅ Allow requests from ANY frontend (Temporary Fix)
                               //.WithOrigins("http://localhost:3001", "https://yourfrontend.com") // Replace with actual frontend URLs for security
            .AllowAnyMethod()
            .AllowAnyHeader()); // If using cookies or authentication
});


// Register Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Fix: Correct Port Handling (No modifying app.Urls)
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.UseUrls($"http://*:{port}"); // Bind to the correct port

var app = builder.Build();

// Use CORS policy


// ✅ Enable Swagger in BOTH Development & Production modes
if (app.Environment.IsDevelopment() || builder.Configuration.GetValue<bool>("Swagger:Enabled"))
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TripPlanner API V1");
        c.RoutePrefix = string.Empty;
    });
}

// Map routes and endpoints
app.MapGet("/", () => Results.Ok("Welcome to RideShare API"));
app.MapGet("/health", () => Results.Ok("Healthy"));

// Enable Health checks at /health endpoint
app.UseHealthChecks("/health");
app.UseCors("AllowAllOrigins");
// Enable Authorization if using Auth
app.UseAuthorization();


// Map API controllers
app.MapControllers();

// Start the application
app.Run();