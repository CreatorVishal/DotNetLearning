using Microsoft.AspNetCore.Mvc;
using StudentManagementApi.Models;

namespace StudentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Vishal Sharma";
        }
        [HttpGet("myname")]
        public string MyName()
        {
            return "Vishal Sharma";
        }
        //List<string> Students = new List<string>()
        //{
        //    "Vishal Sharma",
        //    "John Doe",
        //    "Jane Smith",
        //    "Michael Johnson",
        //    "Emily Davis"
        //};
        private List<Student> Students = new()
{
    new Student
    {
        Id = 1,
        Name = "Vishal Sharma",
        Age = 24
    },
    new Student
    {
        Id = 2,
        Name = "Rahul",
        Age = 22
    },
    new Student
    {
        Id = 3,
        Name = "Aman",
        Age = 23
    }
};
        [HttpGet("students")]
        public List<Student> GetStudents()
        {
            return Students;
        }

    }
}