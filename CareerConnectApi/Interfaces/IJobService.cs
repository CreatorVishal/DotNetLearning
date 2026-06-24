using CareerConnectApi.Models;

namespace CareerConnectApi.Interfaces
{
    public interface IJobService
    {
        List<Job> GetAllJobs();
        Job? GetJobById(int id);
        void AddJob(Job job);
        void AddJobs(List<Job> jobs);
        void UpdateJob(Job job);
        void DeleteJob(int id);
        
    }
}