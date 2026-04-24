using System.ComponentModel.DataAnnotations;

namespace CarpoolingApp.Models
{
    public class Trip
    {
        public int Id { get; set; }

        [Required]
        public string StartLocation { get; set; } = "";

        [Required]
        public string EndLocation { get; set; } = "";

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        // Total seats offered by the driver
        [Required]
        public int AvailableSeats { get; set; }

        // Driver of the trip
        public string DriverId { get; set; } = "";
        public ApplicationUser Driver { get; set; } = null!;

        // Bookings for this trip
        public List<Booking> Bookings { get; set; } = new();
    }
}
