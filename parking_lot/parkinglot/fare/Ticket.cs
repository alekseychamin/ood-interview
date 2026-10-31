namespace ParkingLotSystem;

public class Ticket {
    private readonly string ticketId;         // Unique ticket identifier
    private readonly IVehicle vehicle;         // The vehicle associated with the ticket
    private readonly IParkingSpot parkingSpot; // The parking spot where the vehicle is parked
    private readonly DateTime entryTime; // The time the vehicle entered the parking lot
    private DateTime? exitTime;  // The time the vehicle exited the parking lot (null if vehicle is still parked)

    // Constructor to initialize a new ticket
    public Ticket(string ticketId, IVehicle vehicle, IParkingSpot parkingSpot, DateTime entryTime) {
        this.ticketId = ticketId;
        this.vehicle = vehicle;
        this.parkingSpot = parkingSpot;
        this.entryTime = entryTime;
        this.exitTime = null;  // Initially, exitTime is null because the vehicle is still parked
    }

    // Getters and Setters
    public string TicketId => ticketId;

    public IVehicle Vehicle => vehicle;

    public IParkingSpot ParkingSpot => parkingSpot;

    public DateTime EntryTime => entryTime;

    public DateTime? ExitTime => exitTime;

    public void SetExitTime(DateTime exitTime) {
        this.exitTime = exitTime;
    }

    public decimal CalculateParkingDuration() {
        return (decimal)(
                ((exitTime ?? DateTime.Now) - entryTime)
                        .TotalMinutes);
    }
}
