
using Microsoft.AspNetCore.Mvc;
using StudentManagementApi.Models;
using StudentManagementApi.Services;

namespace StudentManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult GetCourses()
        {
            var courses = _courseService.GetAll();

            return Ok(courses);


            //public List<Course> courses = new()
            //{
            //    new Course()
            //    {
            //        Id=1,
            //        CourseName="BCA",
            //        Duration=3

            //    },
            //    new Course()
            //    {
            //        Id=2,
            //        CourseName="MCA",
            //        Duration=2

            //    },
            //    new Course()
            //    {
            //        Id=3,
            //        CourseName="MBA",
            //        Duration=2

            //    },


            //};
            //[HttpGet("{id}")]
            //public IActionResult GetCourseById(int id)
            //{
            //    if (id <= 0)
            //    {
            //        return BadRequest("Invalid Id");
            //    }

            //    var course = courses.FirstOrDefault(x => x.Id == id);

            //    if (course == null)
            //    {
            //        return NotFound("Course Not Found");
            //    }

            //    return Ok(course);
            //    //return Ok(course);
            //    //return NotFound();
            //    //return BadRequest();
            //    //return NoContent();
            //    //return Created();
            //    //return Unauthorized();
            //    //return Forbid();
            //}

            //[HttpPost]
            //public string AddCourse(Course course)
            //{
            //    courses.Add(course);

            //    return "Course Added Successfully";
            //}
            //[HttpGet]
            //public List<Course> GetCourses()
            //{
            //    return courses;
            //}

        }
    }
}
