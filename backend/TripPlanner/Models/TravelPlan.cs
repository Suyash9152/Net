using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TripPlanner.Models
{
    namespace TripPlanner.Models
    {
        public class TravelPlan
        {
            public int Id { get; set; }  // Add a primary key field
            public int UserId { get; set; }
            public string Source { get; set; }
            public string Destination { get; set; }
            public int People { get; set; }
            public int Days { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public decimal Budget { get; set; }
            public string Distance { get; set; }
            public string ModeOfTransport { get; set; }
            public string SubCategory { get; set; }
            public string Accommodation { get; set; }
            public string SubAccommodation { get; set; }
        }
    }

}
