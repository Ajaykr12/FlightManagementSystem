using Microsoft.AspNetCore.Mvc;
namespace FlightManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
