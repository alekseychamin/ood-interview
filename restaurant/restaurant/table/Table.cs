namespace RestaurantSystem;

// Represents a table in the restaurant with its properties and current state
public class Table {
    // immutable properties
    private readonly int tableId;
    private readonly int capacity;

    // current state
    private readonly Dictionary<DateTime, Reservation> reservations = new();
    private readonly Dictionary<MenuItem, List<OrderItem>> orderedItems = new();

    public Table(int tableId, int capacity) {
        this.tableId = tableId;
        this.capacity = capacity;
    }

    // Calculates the total bill amount for all ordered items at this table
    public decimal CalculateBillAmount() {
        return orderedItems.Values.SelectMany(items => items)
                .Select(orderItem => orderItem.Item)
                .Sum(menuItem => menuItem.Price);
    }
    
    // Adds multiple orders of the same menu item to the table
    public void AddOrder(MenuItem item, int quantity) {
        for (int i = 0; i < quantity; i++) {
            AddOrder(item);
        }
    }

    // Adds a single menu item to the table's order
    public void AddOrder(MenuItem item) {
        List<OrderItem> orderItems = orderedItems.GetValueOrDefault(item);
        if (orderItems == null) {
            orderItems = new();
            orderedItems[item] = orderItems;
            orderItems.Add(new OrderItem(item));
        } else {
            orderItems.Add(new OrderItem(item));
        }
    }

    // Removes a menu item from the table's order
    public void RemoveOrder(MenuItem item) {
        List<OrderItem> orderItems = orderedItems.GetValueOrDefault(item);
        if (orderItems != null) {
            orderItems.RemoveAt(0);
            if (orderItems.Count == 0) {
                orderedItems.Remove(item);
            }
        }
    }

    // Checks if the table is available at a specific time
    public bool IsAvailableAt(DateTime reservationTime) {
        return !reservations.ContainsKey(reservationTime);
    }

    // Adds a reservation to this table
    public void AddReservation(Reservation reservation) {
        reservations[reservation.Time] = reservation;
    }

    // Removes a reservation from this table for a specific time
    public void RemoveReservation(DateTime reservationTime) {
        reservations.Remove(reservationTime);
    }

    public int Capacity => capacity;

    public int TableId => tableId;

    // Returns the current number of guests seated at this table
    public int CurrentPartySize
    {
        get
        {
            return reservations.Values.Sum(reservation => reservation.PartySize);
        }
    }

    // Returns the map of ordered items
    public Dictionary<MenuItem, List<OrderItem>> OrderedItems => orderedItems;
    
    public override string ToString() {
        return "Table #" + TableId + " (Capacity: " + Capacity + ")";
    }
}
