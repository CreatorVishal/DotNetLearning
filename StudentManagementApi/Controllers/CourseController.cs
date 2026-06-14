
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
                CourseName="BCA",
                Duration=3

            },
            new Course()
            {
                CourseName="MCA",
                Duration=2

            },
            new Course()
            {
                CourseName="MBA",
                Duration=2

            },


        };
        [HttpGet("courses")]
        public List<Course> GetCourses()
        {
            return courses;
        }
       
    }
}
