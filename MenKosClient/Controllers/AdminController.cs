using Microsoft.AspNetCore.Mvc;

namespace MenKosClient.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Transaction()
        {
            return View();
        }


        public IActionResult PaymentDeadline()
        {
            return View();
        }

        public IActionResult ComplaintList()
        {
            return View();
        }

    }
}
