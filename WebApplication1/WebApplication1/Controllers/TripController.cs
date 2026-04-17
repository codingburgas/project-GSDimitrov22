using Microsoft.AspNetCore.Mvc;

namespace CarpoolingApp.Controllers
{
    public class TripController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
