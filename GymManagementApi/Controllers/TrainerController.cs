using GymManagementApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrainerController : ControllerBase
{
    private readonly ITrainerService _service;

    public TrainerController(ITrainerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var trainers =
            await _service.GetAllTrainersAsync();

        return Ok(trainers);
    }
}