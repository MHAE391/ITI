using NuGet.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Assignments.Areas.DayTwo.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string MangerName { get; set; }

        public virtual IEnumerable<Instructor> Instructors { get; set; }
        
        public virtual IEnumerable<Trainee> Traines { get; set; }
        
        public virtual IEnumerable<Course> Courses { get; set; }
    }
}
