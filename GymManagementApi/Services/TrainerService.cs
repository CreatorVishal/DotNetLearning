using GymManagementApi.Data;
using GymManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagementApi.Services
{

    public class TrainerService : ITrainerService
    {
        private readonly AppDbContext _context;

        public TrainerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Trainer>> GetAllTrainersAsync()
        {
            return await _context.Trainers.ToListAsync();
        }
    }
}