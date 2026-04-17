using Microsoft.AspNetCore.Mvc;

namespace CarpoolingApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
