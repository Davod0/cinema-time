namespace Cinema.Core;

public class Reservation
{
    public int Id { get; set; }
    public int CinemaViewingId { get; set; }
    public int Quantity { get; set; }
    public string ReservationCode { get; set; }
    public string Email { get; set; }
}
