using System.ComponentModel.DataAnnotations;

namespace CarpoolingApp.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public int TripId { get; set; }
        public Trip Trip { get; set; } = null!;

        [Required]
        public string PassengerId { get; set; } = "";
        public ApplicationUser Passenger { get; set; } = null!;

        [Required]
        public int SeatsBooked { get; set; }
    }
}
