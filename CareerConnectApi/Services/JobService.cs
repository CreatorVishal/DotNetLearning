using CareerConnectApi.Data;
using CareerConnectApi.Interfaces;
using CareerConnectApi.Models;

namespace CareerConnectApi.Services
{
    public class JobService : IJobService
    {
        private readonly AppDbContext _context;

        public JobService(AppDbContext context)
        {
            _context = context;
        }
            
        public List<Job> GetAllJobs()
        {
            return _context.Jobs.ToList();
        }
        public void AddJob(Job job)
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();
        }
        public void AddJobs(List<Job> jobs)
        {
            _context.Jobs.AddRange(jobs);
            _context.SaveChanges();
        }
        public Job? GetJobById(int id)
        {
            return _context.Jobs.FirstOrDefault(x => x.Id == id);
        }
        public void UpdateJob(Job job)
        {
            var existingJob = _context.Jobs.Find(job.Id);
            if (existingJob == null)
            {
                return;
            }
            existingJob.Title = job.Title;
            existingJob.Company = job.Company;
            existingJob.Salary = job.Salary;
            _context.SaveChanges();
        }
        public void DeleteJob(int id)
        {
            var existingJob = _context.Jobs.Find(id);
            if (existingJob == null)
            {
                return;
            }
            _context.Jobs.Remove(existingJob);
            _context.SaveChanges();

        }
    }
}