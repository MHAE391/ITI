namespace Assignments.Areas.DayThree.Data
{
    public class TraineeDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Department { get; set; }

        public int Grade { get; set; }

        public string Address { get; set; }
        public string Image { get; set; }

        public IEnumerable<CourseResultViewModel> Courses { get; set; }
    }

    public class CourseResultViewModel
    {
        public string Course { get; set; }
        public double StudentResult { get; set; }
        public string Color { get; set; }
    }
}

