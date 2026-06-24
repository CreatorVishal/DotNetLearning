using CareerConnectApi.Models;

using CareerConnectApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CareerConnectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController:ControllerBase
    {
        private readonly IJobService _jobService;
        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }
        [HttpGet]
        public IActionResult GetJobs()
        {
            var jobs = _jobService.GetAllJobs();
            return Ok(jobs);
        }
        [HttpPost]
        public IActionResult AddJob([FromBody]Job job)
        {
            _jobService.AddJob(job);
            return Ok("Job Added Successfully ");
        }
        [HttpPost("bulk")]
        public IActionResult AddJobs([FromBody]List<Job> jobs)
        {
            _jobService.AddJobs(jobs);
            return Ok("Jobs Added Successfully!");
        }
        [HttpGet("{id}")]
        public IActionResult GetJobById([FromRoute]int id)
        {
            var job = _jobService.GetJobById(id);
            if (job == null)
            {
                return NotFound("Job Not Found ");
            }
            return Ok(job);
        }
        [HttpPut]
        public IActionResult UpdateJob(Job job)
        {
            _jobService.UpdateJob(job);
            return Ok("Job Updated Successfully");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteJob(int id)
        {
            _jobService.DeleteJob(id);
            return Ok("Job Deleted Successfully");
        }
        [HttpGet("search")]
        public IActionResult SearchJobs(string title)
        {
            return Ok($"Searching : {title}");
        }
        //[HttpGet]
        //public IActionResult GetJobs()
        //{
        //    // Logic to retrieve jobs from the database
        //    return Ok("Jobs Api Working");
        //}
        //[HttpGet("latest")]
        //public IActionResult GetJobs()
        //{
        //    // Logic to retrieve jobs from the database
        //    return Ok("Jobs Api Working");
        //}
        //[HttpGet("{id}")]
        //public IActionResult GetJobsById(int id)
        //{
        //    if (id <= 0)
        //    {
        //        return BadRequest("Invalid Job Id");
        //    }
        //    if (id >= 15)
        //    {
        //        return NotFound("Job Not Found");
        //    }
        //    return Ok($"Job Id : {id}");
        //}
    }
}
