using Microsoft.AspNetCore.Mvc;

namespace TP_Final_APIs.Controllers
{
    public class AutenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
