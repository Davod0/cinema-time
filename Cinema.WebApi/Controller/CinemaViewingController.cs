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
            try
            {
                return Created("/movie", $"{cv}");
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        return BadRequest();
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllCinemaViewingsAsync()
    {
        if (await _service.GetAllCinemaViewingsAsync() != null)
        {
            try
            {
                return Ok(await _service.GetAllCinemaViewingsAsync());
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCinemaViewingAsync(int id)
    {
        if (await _service.DeleteCinemaViewingAsync(id) != null)
        {
            return Ok();
        }
        return BadRequest();
    }
}