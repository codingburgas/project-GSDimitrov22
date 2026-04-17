using Microsoft.AspNetCore.Mvc;

namespace CarpoolingApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
