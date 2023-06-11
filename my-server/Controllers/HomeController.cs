using Microsoft.AspNetCore.Mvc;

namespace my_server.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
