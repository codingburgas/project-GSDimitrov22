using Microsoft.AspNetCore.Mvc;

namespace CarpoolingApp.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
