
using Microsoft.AspNetCore.Mvc;
using StudentManagementApi.Models;

namespace StudentManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController:ControllerBase
    {

        public List<Course> courses = new()
        {
            new Course()
            {
                Id=1,
                CourseName="BCA",
                Duration=3

            },
            new Course()
            {
                Id=2,
                CourseName="MCA",
                Duration=2

            },
            new Course()
            {
                Id=3,
                CourseName="MBA",
                Duration=2

            },


        };
        [HttpGet("{id}")]
        public Course  GetCourseById(int id)
        {
            return (courses.FirstOrDefault(x => x.Id == id));
        }
        [HttpPost]
        public string AddCourse(Course course)
        {
            courses.Add(course);

            return "Course Added Successfully";
        }
        [HttpGet]
        public List<Course> GetCourses()
        {
            return courses;
        }

    }
}
