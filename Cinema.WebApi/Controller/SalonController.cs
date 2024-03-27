namespace Cinema.WebApi;

using Microsoft.AspNetCore.Mvc;
using Cinema.Core;

[ApiController]
[Route("salon")]
public class SalonController : ControllerBase
{
    private readonly ISalonService _service;
    public SalonController(ISalonService salonService)
    {
        _service = salonService;
    }

    [HttpPost("")]
    public async Task<IActionResult> PostSalon(Salon s)
    {
        if (await _service.AddSalonAsync(s) != null)
        {
            try
            {
                return Created("/salon", $"{s}");
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        return BadRequest();
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllSalonsAsync()
    {
        if (await _service.GetAllSalonsAsync() != null)
        {
            try
            {
                return Ok(await _service.GetAllSalonsAsync());
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSalonAsync(int id)
    {
        if (await _service.DeleteSalonAsync(id) != null)
        {
            return Ok();
        }
        return BadRequest();
    }

}

