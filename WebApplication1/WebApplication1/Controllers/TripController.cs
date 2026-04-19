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

        [AllowAnonymous]
        public async Task<IActionResult> Index(DateTime? date, string? destination)
        {
            var trips = _context.Trips.Include(t => t.Driver).AsQueryable();

            if (date.HasValue)
                trips = trips.Where(t => t.Date == date.Value.Date);

            if (!string.IsNullOrWhiteSpace(destination))
                trips = trips.Where(t => t.EndLocation.Contains(destination));

            return View(await trips.ToListAsync());
        }

        [Authorize]
        public IActionResult Create() => View();

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Trip model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.DriverId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            _context.Trips.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var trip = await _context.Trips
                .Include(t => t.Driver)
                .Include(t => t.Bookings)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (trip == null)
                return NotFound();

            int booked = trip.Bookings.Sum(b => b.SeatsBooked);
            ViewBag.RemainingSeats = trip.AvailableSeats - booked;

            return View(trip);
        }
    }
}
