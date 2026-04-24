using System.ComponentModel.DataAnnotations;

namespace CarpoolingApp.Models
{
    public class Booking
    {
        public int Id { get; set; }

        // Related trip
        [Required]
        public int TripId { get; set; }
        public Trip Trip { get; set; } = null!;

        // User who made the booking
        [Required]
        public string PassengerId { get; set; } = "";
        public ApplicationUser Passenger { get; set; } = null!;

        // Number of seats booked
        [Required]
        public int SeatsBooked { get; set; }
    }
}