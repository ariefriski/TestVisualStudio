using Microsoft.AspNetCore.Mvc;

namespace MenKosFrontEnd.Controllers
{
    public class LandingPage : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RentDetail()
        {
            return View();
        }
    }
}
