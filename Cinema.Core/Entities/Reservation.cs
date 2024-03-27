namespace Cinema.Core;

public class Reservation
{
    public int Id { get; set; }
    public int CinemaViewingId { get; set; }
    public int Quantity { get; set; }
    public string ReservationCode { get; set; }
    public string Email { get; set; }
}


/*

API
- [ ] Lista alla reservationer
- [ ] Lista alla reservationer för en viss visning
VG
- [ ] Skapa en ny reservation
- [ ] "Checka in" en reservationskod och sätt den som använd (Kommer att användas vid betalning)


system regler 

    - [ ] Det skall inte gå att reservera platser på en visning om det inte finns tillräckligt många platser kvar
    VG
    - [ ] Reservationer som är äldre än ett år skall automatiskt tas bort ur databasen.
*/