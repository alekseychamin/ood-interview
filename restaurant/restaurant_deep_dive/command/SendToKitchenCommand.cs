namespace RestaurantSystem.DeepDive;

// Command that handles sending order items (food orders) to the kitchen
public class SendToKitchenCommand : IOrderCommand {
    private readonly OrderItem orderItem;

    // Constructor that takes the order item to be sent to the kitchen
    public SendToKitchenCommand(OrderItem orderItem) {
        this.orderItem = orderItem;
    }

    public void Execute() {
        orderItem.SendToKitchen();
    }
}
