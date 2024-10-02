using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Assignments.Areas.DayTwo.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image {  get; set; }

        public string Address   { get; set; }

        public double Salary { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
