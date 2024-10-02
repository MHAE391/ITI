using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignments.Areas.DayTwo.Models
{
    public class Trainee
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image {  get; set; }

        public string Address { get; set; }

        public int Grade { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual IEnumerable<CourseResult> CourseResults { get; set; }

    }
}
