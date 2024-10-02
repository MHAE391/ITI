using Assignments.Areas.DayOne.Models;
using Assignments.Areas.DayTwo.Data;
using Microsoft.AspNetCore.Mvc;

namespace Assignments.Areas.DayTwo.Controllers
{
    [Area("DayTwo")]
    public class InstructorsController(DayTwoDbContext dbContext) : Controller
    {
        public IActionResult Index()
        {
            var instructors = dbContext.Instructors.ToList();
            return View(instructors);
        }

        public IActionResult Details(int id) 
        { 
            var instactor = dbContext.Instructors.FirstOrDefault(x => x.Id == id);
            if (instactor == null) { return NotFound(); }
            return View(instactor);
        }
    }
}
