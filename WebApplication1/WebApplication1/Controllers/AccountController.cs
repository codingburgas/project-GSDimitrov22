using Microsoft.AspNetCore.Mvc;

namespace CarpoolingApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
