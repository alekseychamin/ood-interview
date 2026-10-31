namespace GroceryStore;

// Strategy that applies a fixed amount discount
public class AmountBasedStrategy : IDiscountCalculationStrategy {
    // The fixed amount to be discounted
    private readonly decimal discountAmount;

    // Creates a new amount-based strategy with the specified discount amount
    public AmountBasedStrategy(decimal discountAmount) {
        this.discountAmount = discountAmount;
    }

    // Calculates the discounted price by subtracting the fixed amount
    public decimal CalculateDiscountedPrice(decimal originalPrice) {
        return Math.Max((originalPrice - discountAmount), 0m);
    }
}
