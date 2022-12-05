using Microsoft.AspNetCore.Mvc;

namespace MenKosClient.Controllers
{
    public class PanjiController : Controller
    {
  

        public IActionResult Transaction()
        {
            return View();
        }

     
        public IActionResult PaymentDeadline()
        {
            return View();
        }


        public IActionResult PaymentDeadline(int occupantId)
        {
            return View("");
        }

    }
}
