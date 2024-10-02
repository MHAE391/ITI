using Assignments.Areas.DayOne.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignments.Areas.DayOne.Controllers
{
    [Area("DayOne")]
    public class StudentsController : Controller
    {
        private List<Student> students = new List<Student> {
            new Student { Id = 1, Name = "Ali Ahmed",  Address = "Cairo" , Image  =  "1"},
            new Student { Id = 2, Name = "Abdallah Mohamed",  Address = "Giza" , Image  =  "2"},
            new Student { Id = 3, Name = "Hamza Alaa",  Address = "ALex" , Image  =  "3"},
            new Student { Id = 4, Name = "Ibrahim Mohamed",  Address = "Cairo" , Image  =  "2"},
            new Student { Id = 5, Name = "Alaa Othman",  Address = "Menofia" , Image  =  "1"},
            new Student { Id = 6, Name = "Moraad Maged",  Address = "Assuit" , Image  =  "3" },
        };

        public IActionResult AllStudents()
        {
            return View(students);
        }
        public IActionResult StudentDetails(int id)
        {
            Student student = students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }



    }
}
