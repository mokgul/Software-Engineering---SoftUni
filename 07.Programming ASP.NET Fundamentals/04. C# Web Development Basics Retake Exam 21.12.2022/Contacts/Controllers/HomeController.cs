using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if(User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Contacts");
            }
            return View();
        }
    }
}