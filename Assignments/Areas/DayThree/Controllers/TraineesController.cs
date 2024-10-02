using Assignments.Areas.DayThree.Data;
using Assignments.Areas.DayTwo.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;

namespace Assignments.Areas.DayThree.Controllers
{
    [Area("DayThree")]
    public class TraineesController(DayTwoDbContext context) : Controller
    {
        public IActionResult Index()
        {
            var Trainees = context.Trainees.Select( x => new TraineeViewModel { Id = x.Id , Department = x.Department.Name ,  Name = x.Name }).ToList();
            return View(Trainees);
        }

        public IActionResult Details(int id) 
        {
            var result = context.Trainees.FirstOrDefault(x => x.Id == id);
            if (result == null) { return NotFound(); }

            var trainee = 
            new TraineeDetailsViewModel
            {
                Id = result.Id,
                Department = result.Department.Name,
                Name = result.Name,
                Address = result.Address,
                Grade = result.Grade,
                Image = result.Image,
                Courses = result.CourseResults.Select(c => new CourseResultViewModel
                {
                    Course = c.Course.Name,
                    StudentResult = c.Degree,
                    Color = c.Degree < c.Course.MinDegree ? Color.Red.Name : Color.Green.Name,
                }).ToList()
            };
            return View(trainee);
        }
    }
}
