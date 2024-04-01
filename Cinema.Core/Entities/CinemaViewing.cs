namespace Cinema.Core;

public class CinemaViewing
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public Movie? Movie { get; set; }
    public int SalonId { get; set; }
    public DateTime TimeAndDate { get; set; }
    public int Price { get; set; }
    public int PlaceQuantity { get; set; }
    public string Premiere { get; set; }
}

