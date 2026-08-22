using Microsoft.AspNetCore.Mvc;
using ProjectGym.Models;
using System.Diagnostics;

namespace ProjectGym.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
