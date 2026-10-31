namespace RestaurantSystem.DeepDive;

// Command that handles cancellation of order items (food orders)
public class CancelCommand : IOrderCommand {
    private readonly OrderItem orderItem;

    // Constructor that takes the order item to be canceled
    public CancelCommand(OrderItem orderItem) {
        this.orderItem = orderItem;
    }

    public void Execute() {
        orderItem.Cancel();
    }
}
