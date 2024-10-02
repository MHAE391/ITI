using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Assignments.Areas.DayFour.Models
{
    public class AddInstructorViewModel
    {
        [Required, Length(4 ,100)]
        public string Name { get; set; }

        [Required,Range(1 ,6)]
        public  int Image { get; set; }
        [Required,Length(5, 100)]
        public string Address { get; set; }
        [Required, Range(2000 , 20000)]
        public double Salary { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }

        public IEnumerable<SelectListItem> Courses { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Departments { get; set; } = Enumerable.Empty<SelectListItem>();

    }

}
