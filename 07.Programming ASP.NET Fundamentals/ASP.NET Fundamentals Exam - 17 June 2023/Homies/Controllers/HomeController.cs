using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("All", "Event");
        }
    }
}