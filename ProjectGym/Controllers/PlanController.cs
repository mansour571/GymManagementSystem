using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGym.Data.Contexts;

namespace ProjectGym.Controllers
{
    public class PlanController : Controller
    {
        public GymDbContext Context = new GymDbContext();

        public async Task<IActionResult> Index()
        {
            var Plans = await Context.Plans.ToListAsync();

            return View(Plans);
        }

        public async Task<IActionResult> Details(int id)
        {
            var plans = await Context.Plans.FirstOrDefaultAsync(p => p.Id == id);

            if (plans == null)
            {
                return RedirectToAction(nameof(Index)); // return 302, Location: /Plan/Index
            }

            if(plans.Id <= 0) {
                return NotFound();
            }

            return View(plans);
        }
    }
}
