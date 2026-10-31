namespace GroceryStore;

public class Order {
    // Unique identifier for the order
    private readonly string orderId;
    // List of items in the order
    private readonly List<OrderItem> items = new();
    // Map of items to their applied discounts
    private readonly Dictionary<OrderItem, DiscountCampaign> appliedDiscounts = new();
    // Amount paid by the customer
    private decimal paymentAmount = 0m;

    // Creates a new order with a random UUID
    public Order() {
        this.orderId = Guid.NewGuid().ToString();
    }

    // Adds an item to the order
    public void AddItem(OrderItem item) {
        items.Add(item);
    }

    // Calculates the subtotal of all items without discounts
    public decimal CalculateSubtotal() {
        return items.Sum(item => item.CalculatePrice());
    }

    // Calculates the total price including all applied discounts
    public decimal CalculateTotal() {
        return items.Sum(item => {
                    DiscountCampaign discount = appliedDiscounts.GetValueOrDefault(item);
                    return discount != null ? item.CalculatePriceWithDiscount(discount) : item.CalculatePrice();
                });
    }

    // Applies a discount to a specific item in the order
    public void ApplyDiscount(OrderItem item, DiscountCampaign discount) {
        appliedDiscounts[item] = discount;
    }

    // Returns an unmodifiable list of items in the order
    public List<OrderItem> Items => new(items);

    // Sets the payment amount for the order
    public void SetPayment(decimal paymentAmount) {
        this.paymentAmount = paymentAmount;
    }

    // Returns the payment amount
    public decimal PaymentAmount => paymentAmount;

    // Calculates the change to be returned to the customer
    public decimal CalculateChange() {
        return (paymentAmount - CalculateTotal());
    }

    // Returns the map of applied discounts
    public Dictionary<OrderItem, DiscountCampaign> AppliedDiscounts => appliedDiscounts;

    // Returns the order ID
    public string OrderId => orderId;
}
