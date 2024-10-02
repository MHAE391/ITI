using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignments.Areas.DayTwo.Models
{
    public class CourseResult
    {
        [Key]
        public int Id { get; set; }
        public double Degree { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        [ForeignKey(nameof(Trainee))]
        public int TraineeId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Trainee Trainee { get; set; }

    }
}
