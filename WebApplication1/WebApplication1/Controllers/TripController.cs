using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CarpoolingApp.Data;
using CarpoolingApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarpoolingApp.Controllers
{
    public class TripController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TripController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lists trips with optional filters
        [AllowAnonymous]
        public async Task<IActionResult> Index(DateTime? date, string? destination)
        {
            var trips = _context.Trips
                .Include(t => t.Driver)
                .AsQueryable();

            if (date.HasValue)
                trips = trips.Where(t => t.Date == date.Value.Date);

            if (!string.IsNullOrWhiteSpace(destination))
                trips = trips.Where(t => t.EndLocation.Contains(destination));

            return View(await trips.ToListAsync());
        }

        // Shows create form
        [Authorize]
        public IActionResult Create() => View();

        // Creates a new trip
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Trip model)
        {
            // 🔥 DEBUG: Print ModelState errors
            if (!ModelState.IsValid)
            {
                Console.WriteLine("MODELSTATE INVALID:");
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        Console.WriteLine($"{entry.Key}: {error.ErrorMessage}");
                    }
                }

                return View(model);
            }

            // Set logged-in user as driver
            model.DriverId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            _context.Trips.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // Shows trip details
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var trip = await _context.Trips
                .Include(t => t.Driver)
                .Include(t => t.Bookings)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (trip == null)
                return NotFound();

            // Calculate remaining seats
            int booked = trip.Bookings.Sum(b => b.SeatsBooked);
            ViewBag.RemainingSeats = trip.AvailableSeats - booked;

            return View(trip);
        }
    }
}
