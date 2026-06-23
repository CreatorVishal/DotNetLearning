using GymManagementApi.Models;

namespace GymManagementApi.Services
{
    public interface ITrainerService
    {
        Task<List<Trainer>> GetAllTrainersAsync();
    }

}
