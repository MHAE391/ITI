using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignments.Areas.DayTwo.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public double Degree { get; set; }

        public double MinDegree { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual IEnumerable<CourseResult> CourseResults { get; set; }    

        public virtual IEnumerable<Instructor> Instructors { get; set; }
    }
}
