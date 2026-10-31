namespace GroceryStore;

// Strategy that applies a percentage-based discount
public class PercentageBasedStrategy : IDiscountCalculationStrategy {
    // The percentage to be discounted (e.g., 50 for 50%)
    private readonly decimal percentage;

    // Creates a new percentage-based strategy with the specified percentage
    public PercentageBasedStrategy(decimal percentage) {
        this.percentage = percentage;
    }

    // Calculates the discounted price by applying the percentage discount
    public decimal CalculateDiscountedPrice(decimal originalPrice) {
        return (originalPrice * (1m - (percentage / 100m)));
    }
}
