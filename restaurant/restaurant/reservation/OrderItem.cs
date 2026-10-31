namespace RestaurantSystem;

// Represents a food item ordered by a customer with its current status in the order process
public class OrderItem {
    private readonly MenuItem item;
    private Status status = Status.Pending;

    public OrderItem(MenuItem item) {
        this.item = item;
    }

    public MenuItem Item => item;
    
    // Updates the status to indicate the item has been sent to the kitchen
    public void SendToKitchen() {
        if (status == Status.Pending) status = Status.SentToKitchen;
    }

    // Updates the status to indicate the item has been delivered to the customer
    public void DeliverToCustomer() {
        if (status == Status.SentToKitchen) status = Status.Delivered;
    }

    // Updates the status to indicate the item has been canceled
    public void Cancel() {
        if (status == Status.Pending || status == Status.SentToKitchen) {
            status = Status.Canceled;
            // item has been canceled.
        }
    }

    public Status Status => status;
}
