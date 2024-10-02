using Assignments.Areas.DayFour.Models;
using Assignments.Areas.DayTwo.Data;
using Assignments.Areas.DayTwo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignments.Areas.DayFour.Controllers
{
    [Area("DayFour")]
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

        [HttpGet]
        public IActionResult New()
        {
            var courses = dbContext.Courses.Select(x => new SelectListItem { Text = x.Name , Value = x.Id.ToString() }).OrderBy(x=>x.Text).ToList();
            var departments = dbContext.Departments.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).OrderBy(x => x.Text).ToList();
            return View( new AddInstructorViewModel { Courses = courses , Departments = departments});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(AddInstructorViewModel instructorModel) 
        {
            if (!ModelState.IsValid)
            {
                var courses = dbContext.Courses.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).OrderBy(x => x.Text).ToList();
                var departments = dbContext.Departments.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).OrderBy(x => x.Text).ToList();
                instructorModel.Courses = courses;
                instructorModel.Departments = departments;
                return View(instructorModel);
            }
            var instructor = new Instructor
            {
                Name  = instructorModel.Name,
                Address = instructorModel.Address,
                Image  = instructorModel.Image.ToString() ,
                CourseId = instructorModel.CourseId ,
                DepartmentId = instructorModel.DepartmentId ,
                Salary = instructorModel.Salary 
            };
            dbContext.Instructors.Add(instructor);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        { 
            var instructor = dbContext.Instructors.FirstOrDefault(x => x.Id == id);
            if(instructor is null) return NotFound();


            var courses = dbContext.Courses.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).OrderBy(x => x.Text).ToList();
            var departments = dbContext.Departments.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).OrderBy(x => x.Text).ToList();
            var oldInstructorViewModel = new EditInstructorViewModel
            {
                Id  = id,
                Courses = courses,
                Departments = departments,
                Name = instructor.Name,
                Salary = instructor.Salary,
                Image = Convert.ToInt32(instructor.Image),
                Address = instructor.Address,
                CourseId = instructor.CourseId,
                DepartmentId = instructor.DepartmentId
            };
            return View(oldInstructorViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditInstructorViewModel instructorModel)
        {
            if (!ModelState.IsValid)
            {
                var courses = dbContext.Courses.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).OrderBy(x => x.Text).ToList();
                var departments = dbContext.Departments.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).OrderBy(x => x.Text).ToList();
                instructorModel.Courses = courses;
                instructorModel.Departments = departments;
                return View(instructorModel);
            }
            var instructor = dbContext.Instructors.First(x => x.Id == instructorModel.Id);
            instructor.Name = instructorModel.Name;
            instructor.Address = instructorModel.Address;
            instructor.Image = instructorModel.Image.ToString();
            instructor.CourseId = instructorModel.CourseId;
            instructor.DepartmentId = instructorModel.DepartmentId;
            instructor.Salary = instructorModel.Salary;
            dbContext.Instructors.Update(instructor);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var instactor = dbContext.Instructors.FirstOrDefault(x => x.Id == id);
            if (instactor == null) { return NotFound(); }
            dbContext.Instructors.Remove(instactor);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
