using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GymManagementSystem.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
