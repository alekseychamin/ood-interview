namespace GroceryStore;

public class OrderItem {
    // The item being ordered
    private readonly Item item;
    // Quantity of the item
    private readonly int quantity;

    // Creates a new order item with the specified item and quantity
    public OrderItem(Item item, int quantity) {
        this.item = item;
        this.quantity = quantity;
    }

    // Calculates the total price for this order item without any discount
    public decimal CalculatePrice() {
        return (item.Price * (decimal)(quantity));
    }

    public Item Item => item;

    public int Quantity => quantity;

    // Calculates the total price for this order item with the given discount
    public decimal CalculatePriceWithDiscount(DiscountCampaign newDiscount) {
        return newDiscount.CalculateDiscount(this);
    }
}
