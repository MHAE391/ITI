using Assignments.Areas.DayTwo.Models;
using Microsoft.EntityFrameworkCore;
using Assignments.Areas.DayThree.Data;

namespace Assignments.Areas.DayTwo.Data
{
    public class DayTwoDbContext (DbContextOptions<DayTwoDbContext> options) : DbContext(options)
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<CourseResult> CourseResults { get; set; }
        public DbSet<Assignments.Areas.DayThree.Data.TraineeViewModel> TraineeViewModel { get; set; } = default!;
    }
}
