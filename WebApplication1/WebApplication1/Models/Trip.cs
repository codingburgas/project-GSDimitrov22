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

        [Required]
        public int AvailableSeats { get; set; }

        public string DriverId { get; set; } = "";
        public ApplicationUser Driver { get; set; } = null!;

        public List<Booking> Bookings { get; set; } = new();
    }
}
