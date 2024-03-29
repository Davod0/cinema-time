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

Implementera endpoint för reservation 
interface
EFrepository klass
Service klass

API
- [*] Lista alla reservationer
- [*] Lista alla reservationer för en viss visning
VG
- [*] Skapa en ny reservation


system regler 

    - [*] Det skall inte gå att reservera platser på en visning om det inte finns tillräckligt många platser kvar 
    VG

_________________________________________________________
 min extra funkationer 
- [*] Radera reseravtioner 


*/