namespace RestaurantSystem;

// Main restaurant class that manages reservations, orders and tables
public class Restaurant {
    private readonly string name;
    private readonly Menu menu;
    private readonly Layout layout;
    private readonly ReservationManager reservationManager;

    public Restaurant(string name, Menu menu, Layout layout) {
        this.name = name;
        this.menu = menu;
        this.layout = layout;
        this.reservationManager = new ReservationManager(layout);
    }

    // Finds possible reservation times within a time range for a party of specified size
    public DateTime[] FindAvailableTimeSlots(DateTime rangeStart, DateTime rangeEnd, int partySize) {
        return reservationManager.FindAvailableTimeSlots(rangeStart, rangeEnd, partySize);
    }

    // Creates a reservation for a party at the specified time
    public Reservation CreateScheduledReservation(string partyName, int partySize, DateTime time) {
        return reservationManager.CreateReservation(partyName, partySize, time);
    }

    // Removes an existing reservation
    public void RemoveReservation(string partyName, int partySize, DateTime reservationTime) {
        reservationManager.RemoveReservation(partyName, partySize, reservationTime);
    }

    // Creates a reservation for a party without prior reservation
    public Reservation CreateWalkInReservation(string partyName, int partySize) {
        return reservationManager.CreateReservation(partyName, partySize, DateTime.Now);
    }

    // Adds an item to a table's order
    public void OrderItem(Table table, MenuItem item) {
        table.AddOrder(item);
    }

    // Removes an item from a table's order
    public void CancelItem(Table table, MenuItem item) {
        table.RemoveOrder(item);
    }

    // Calculates the bill amount for a table
    public decimal CalculateTableBill(Table table) {
        return table.CalculateBillAmount();
    }

    public string Name => name;

    public Menu Menu => menu;

    public Layout Layout => layout;

    // Returns the restaurant's reservation manager
    public ReservationManager ReservationManager => reservationManager;
}
