namespace GroceryStore;

public class Checkout {
    // Current order being processed
    private Order currentOrder;
    // List of active discount campaigns
    private readonly List<DiscountCampaign> activeDiscounts;

    // Creates a new checkout with the given active discounts
    public Checkout(List<DiscountCampaign> activeDiscounts) {
        this.activeDiscounts = activeDiscounts;
        StartNewOrder();
    }

    // Starts a new order
    public void StartNewOrder() {
        this.currentOrder = new Order();
    }

    // Processes the payment and returns the change
    public decimal ProcessPayment(decimal paymentAmount) {
        currentOrder.SetPayment(paymentAmount);
        return currentOrder.CalculateChange();
    }

    // Adds an item to the current order and applies applicable discounts
    public void AddItemToOrder(Item item, int quantity) {
        OrderItem orderItem = new OrderItem(item, quantity);
        currentOrder.AddItem(orderItem);

        foreach (DiscountCampaign newDiscount in activeDiscounts) {
            if (newDiscount.IsApplicable(item)) {
                // if there are multiple newDiscount that apply to item, apply the higher one
                if (currentOrder.AppliedDiscounts.ContainsKey(orderItem)) {
                    DiscountCampaign existingDiscount = currentOrder.AppliedDiscounts[orderItem];
                    if (orderItem.CalculatePriceWithDiscount(newDiscount)
                            .CompareTo(orderItem.CalculatePriceWithDiscount(existingDiscount)) > 0) {
                        currentOrder.ApplyDiscount(orderItem, newDiscount);
                    }
                } else {
                    currentOrder.ApplyDiscount(orderItem, newDiscount);
                }
            }
        }
    }

    // Generates a receipt for the current order
    public Receipt Receipt => new Receipt(currentOrder);

    // Calculates the total amount for the current order
    public decimal OrderTotal => currentOrder.CalculateTotal();
}
