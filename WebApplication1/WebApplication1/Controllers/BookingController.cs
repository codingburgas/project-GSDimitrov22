using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CarpoolingApp.Data;
using CarpoolingApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarpoolingApp.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create(int tripId)
        {
            var trip = await _context.Trips
                .Include(t => t.Bookings)
                .FirstOrDefaultAsync(t => t.Id == tripId);

            if (trip == null)
                return NotFound();

            int booked = trip.Bookings.Sum(b => b.SeatsBooked);
            ViewBag.RemainingSeats = trip.AvailableSeats - booked;

            return View(new Booking { TripId = tripId });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Booking model)
        {
            var trip = await _context.Trips
                .Include(t => t.Bookings)
                .FirstOrDefaultAsync(t => t.Id == model.TripId);

            if (trip == null)
                return NotFound();

            int remaining = trip.AvailableSeats - trip.Bookings.Sum(b => b.SeatsBooked);

            if (model.SeatsBooked > remaining)
            {
                ModelState.AddModelError("", "Not enough seats available.");
                return View(model);
            }

            model.PassengerId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            _context.Bookings.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Trip");
        }
    }
}
