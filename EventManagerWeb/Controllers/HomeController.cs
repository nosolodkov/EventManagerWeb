using Microsoft.AspNetCore.Mvc;

namespace EventManagerWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
