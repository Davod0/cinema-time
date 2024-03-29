namespace Cinema.WebApi;
using Cinema.Core;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("CinemaViewing")]
public class CinemaViewingController : ControllerBase
{
    private readonly CinemaViewingService _service;
    public CinemaViewingController(CinemaViewingService cinemaViewingService)
    {
        _service = cinemaViewingService;
    }

    [HttpPost("")]
    public async Task<IActionResult> PostCinemaViewingAsync(CinemaViewing cv)
    {
        if (await _service.AddCinemaViewingAsync(cv) != null)
        {
            return Created("/movie", $"{cv}");
        }
        return BadRequest();
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllCinemaViewingsAsync()
    {
        var cinemaViewings = await _service.GetAllCinemaViewingsAsync();
        if (cinemaViewings != null)
        {
            return Ok(cinemaViewings);
        }
        return StatusCode(500);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCinemaViewingAsync(int id)
    {
        var deletedCv = await _service.DeleteCinemaViewingAsync(id);
        if (deletedCv != null)
        {
            return Ok(deletedCv);
        }
        return StatusCode(500);
    }

    [HttpGet("uppcoming")]
    public async Task<IActionResult> GetAllUpcomingCinemaViewingsAsync()
    {
        List<CinemaViewing> upcomingCinemaViewings = await _service.GetAllUpcomingCinemaViewingsAsync();

        if (upcomingCinemaViewings != null)
        {
            return Ok(upcomingCinemaViewings);
        }
        return NotFound();
    }
}