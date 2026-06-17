using StudentManagementApi.Models;
namespace StudentManagementApi.Services
{
    public class CourseService
    {
        private List<Course> courses = new()
        {
            new Course()
            {
                Id = 1,
                CourseName = "BCA",
                Duration = 3
            },
            new Course()
            {
                Id = 2,
                CourseName = "MCA",
                Duration = 2
            },
              new Course()
            {
                Id=3,
                CourseName="MBA",
                Duration=2

            }

        };
        public List<Course> GetAll()
        {
            return courses;
        }
    }
}
