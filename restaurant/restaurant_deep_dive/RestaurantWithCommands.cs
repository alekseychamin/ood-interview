namespace RestaurantSystem.DeepDive;

/**
 * Enhanced Restaurant class that uses the Command Pattern for order management.
 * This implementation provides better encapsulation and flexibility for handling orders.
 */
public class RestaurantWithCommands {
    private readonly string name;
    private readonly Menu menu;
    private readonly Layout layout;
    private readonly ReservationManager reservationManager;
    private readonly OrderManager orderManager;

    /**
     * Creates a new restaurant with the given name, menu, and table layout.
     *
     * @param name  The name of the restaurant
     * @param menu  The menu of the restaurant
     * @param layout The table layout of the restaurant
     */
    public RestaurantWithCommands(string name, Menu menu, Layout layout) {
        this.name = name;
        this.menu = menu;
        this.layout = layout;
        this.reservationManager = new ReservationManager(layout);
        this.orderManager = new OrderManager();
    }

    /**
     * Finds available time slots for a reservation within the given time range.
     *
     * @param rangeStart The start of the time range
     * @param rangeEnd   The end of the time range
     * @param partySize  The size of the party
     * @return An array of available time slots
     */
    public DateTime[] FindAvailableTimeSlots(DateTime rangeStart, DateTime rangeEnd, int partySize) {
        return reservationManager.FindAvailableTimeSlots(rangeStart, rangeEnd, partySize);
    }

    /**
     * Creates a scheduled reservation for a party.
     *
     * @param partyName The name of the party
     * @param partySize The size of the party
     * @param time      The desired reservation time
     * @return The created reservation
     */
    public Reservation CreateScheduledReservation(string partyName, int partySize, DateTime time) {
        return reservationManager.CreateReservation(partyName, partySize, time);
    }

    /**
     * Removes an existing reservation.
     *
     * @param partyName       The name of the party
     * @param partySize       The size of the party
     * @param reservationTime The time of the reservation
     */
    public void RemoveReservation(string partyName, int partySize, DateTime reservationTime) {
        reservationManager.RemoveReservation(partyName, partySize, reservationTime);
    }

    /**
     * Creates a walk-in reservation for a party.
     *
     * @param partyName The name of the party
     * @param partySize The size of the party
     * @return The created reservation
     */
    public Reservation CreateWalkInReservation(string partyName, int partySize) {
        return reservationManager.CreateReservation(partyName, partySize, DateTime.Now);
    }

    /**
     * Places an order for an item at a table and sends it to the kitchen.
     * Uses the Command Pattern to handle the order process.
     *
     * @param table The table placing the order
     * @param item  The menu item being ordered
     */
    public void OrderItem(Table table, MenuItem item) {
        table.AddOrder(item);
        // Get the last added order item
        List<OrderItem> orderItems = table.OrderedItems[item];
        if (orderItems != null && orderItems.Count > 0) {
            OrderItem lastOrder = orderItems[orderItems.Count - 1];
            IOrderCommand sendToKitchen = new SendToKitchenCommand(lastOrder);
            orderManager.AddCommand(sendToKitchen);
            orderManager.ExecuteCommands();
        }
    }

    /**
     * Cancels an order for an item at a table.
     * Uses the Command Pattern to handle the cancellation process.
     *
     * @param table The table canceling the order
     * @param item  The menu item being canceled
     */
    public void CancelItem(Table table, MenuItem item) {
        List<OrderItem> orderItems = table.OrderedItems[item];
        if (orderItems != null && orderItems.Count > 0) {
            OrderItem lastOrder = orderItems[orderItems.Count - 1];
            IOrderCommand cancelOrder = new CancelCommand(lastOrder);
            orderManager.AddCommand(cancelOrder);
            orderManager.ExecuteCommands();
            table.RemoveOrder(item);
        }
    }

    /**
     * Delivers an item to the customer at a table.
     * Uses the Command Pattern to handle the delivery process.
     *
     * @param table The table receiving the delivery
     * @param item  The menu item being delivered
     */
    public void DeliverItem(Table table, MenuItem item) {
        List<OrderItem> orderItems = table.OrderedItems[item];
        if (orderItems != null && orderItems.Count > 0) {
            OrderItem lastOrder = orderItems[orderItems.Count - 1];
            IOrderCommand deliverOrder = new DeliverCommand(lastOrder);
            orderManager.AddCommand(deliverOrder);
            orderManager.ExecuteCommands();
        }
    }

    /**
     * Calculates the total bill amount for a table.
     *
     * @param table The table to calculate the bill for
     * @return The total bill amount
     */
    public decimal CalculateTableBill(Table table) {
        return table.CalculateBillAmount();
    }

    // Getters
    public string Name => name;

    public Menu Menu => menu;

    public Layout Layout => layout;

    public ReservationManager ReservationManager => reservationManager;

    public OrderManager OrderManager => orderManager;
}
