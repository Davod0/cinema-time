namespace Cinema.WebApi;
using Microsoft.AspNetCore.Mvc;
using Cinema.Core;
using Microsoft.AspNetCore.Http.HttpResults;

[ApiController]
[Route("reservation")]
public class ReservationController : ControllerBase
{
    private readonly ReservationService _service;
    public ReservationController(ReservationService reservationService)
    {
        _service = reservationService;
    }

    [HttpPost("")]
    public async Task<IActionResult> PostReservationsAsync(Reservation r)
    {
        _service.GenerateReservationCode(r);

        if (!string.IsNullOrEmpty(r.ReservationCode))
        {
            try
            {
                var addedReservation = await _service.AddReservationAsync(r);
                if (addedReservation != null)
                {
                    return Created("/reservation", $"{addedReservation}");
                }
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        return BadRequest();
    }


    [HttpGet("")]
    public async Task<IActionResult> GetAllReservationsAsync()
    {
        List<Reservation> list = await _service.GetAllReservationsAsync();
        if (list != null)
        {
            return Ok(list);
        }
        return NotFound();
    }

    [HttpGet("CinemaViewing/{id}")]
    public async Task<IActionResult> GetReservationsForCinemaViewingAsync(int id)
    {
        try
        {
            List<Reservation> list = await _service.GetReservationsForCinemaViewingAsync(id);
            if (list != null)
            {
                return Ok(list);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReservationAsync(int id)
    {
        if (id != null)
        {
            try
            {
                Reservation deleteR = await _service.DeleteReservationAsync(id);
                {
                    if (deleteR != null)
                    {
                        return Created("/reservation", deleteR);
                    }
                }
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Här kan man istället för att returnera StatusCode till användare logga den till en admin page
                return StatusCode(500, ex.Message);
            }
        }
        return BadRequest("Reservation Id can not be null");
    }

}

