namespace RestaurantSystem;

// Manages all reservations for the restaurant and handles table assignment
public class ReservationManager {
    private readonly Layout layout;
    private readonly HashSet<Reservation> reservations = new();

    // Constructor that takes the restaurant's table layout
    public ReservationManager(Layout layout) {
        this.layout = layout;
    }

    // Finds potential time slots for a reservation within the given time range and party size
    public DateTime[] FindAvailableTimeSlots(DateTime rangeStart, DateTime rangeEnd, int partySize) {
        // checking every hour in the time range
        DateTime current = rangeStart;
        List<DateTime> possibleReservations = new();
        while (current <= rangeEnd) {
            Table availableTable = layout.FindAvailableTable(partySize, current);
            if (availableTable != null) {
                possibleReservations.Add(current);
            }
            current = current.AddHours(1);
        }
        return possibleReservations.ToArray();
    }

    // Creates a reservation for a specific time, party size and name
    public Reservation CreateReservation(string partyName, int partySize, DateTime desiredTime) {
        desiredTime = desiredTime.TruncatedToHours();
        Table table = layout.FindAvailableTable(partySize, desiredTime);
        Reservation reservation = new Reservation(partyName, partySize, desiredTime, table);
        table.AddReservation(reservation);
        reservations.Add(reservation);
        return reservation;
    }

    // Removes an existing reservation
    public void RemoveReservation(string partyName, int partySize, DateTime reservationTime) {
        // Find matching reservation before removing it
        foreach (Reservation reservation in new List<Reservation>(reservations)) {
            if (reservation.Time.Equals(reservationTime) &&
                    reservation.PartySize == partySize &&
                    reservation.PartyName.Equals(partyName)) {
                // Clear the reservation from the table first
                Table table = reservation.AssignedTable;
                table.RemoveReservation(reservationTime);
                // Then remove from the reservation collection
                reservations.Remove(reservation);
                return;
            }
        }
    }

    // Returns all current reservations
    public HashSet<Reservation> Reservations => new(reservations);
}
