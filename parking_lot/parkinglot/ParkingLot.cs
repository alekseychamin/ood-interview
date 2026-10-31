namespace ParkingLotSystem;

public class ParkingLot {
    private readonly ParkingManager parkingManager; // Manages parking spots and vehicle assignments
    private readonly FareCalculator fareCalculator; // Calculates fare for parking sessions

    public ParkingLot(ParkingManager parkingManager, FareCalculator fareCalculator) {
        this.parkingManager = parkingManager;
        this.fareCalculator = fareCalculator;
    }

    // Method to handle vehicle entry into the parking lot
    public Ticket EnterVehicle(IVehicle vehicle) {
        // Delegate parking logic to ParkingManager
        IParkingSpot spot = parkingManager.ParkVehicle(vehicle);
        
        if (spot != null) {
            // Create ticket with entry time
            Ticket ticket = new Ticket(GenerateTicketId(), vehicle, spot, DateTime.Now);
            return ticket;
        } else {
            return null;  // No spot available
        }
    }

    // Method to handle vehicle exit from the parking lot using the parkinglot.fare.Ticket object
    public void LeaveVehicle(Ticket ticket) {
        if (ticket != null && ticket.ExitTime == null) {  // Ensure the ticket is valid and the vehicle hasn't already left
            // Set exit time
            ticket.SetExitTime(DateTime.Now);
            
            // Delegate unparking logic to ParkingManager
            parkingManager.UnparkVehicle(ticket.Vehicle);

            // Calculate the fare
            decimal fare = fareCalculator.CalculateFare(ticket);
        } else {
            // Invalid ticket or vehicle already exited. 
        }
    }

    // Helper method to generate a unique ticket ID
    private string GenerateTicketId() {
        return "TICKET-" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}
