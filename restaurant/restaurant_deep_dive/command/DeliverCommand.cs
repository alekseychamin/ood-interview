namespace RestaurantSystem.DeepDive;

// Command that handles delivery of order items (food orders) to customers
public class DeliverCommand : IOrderCommand {
    private readonly OrderItem orderItem;

    // Constructor that takes the order item to be delivered
    public DeliverCommand(OrderItem orderItem) {
        this.orderItem = orderItem;
    }

    public void Execute() {
        orderItem.DeliverToCustomer();
    }
}
