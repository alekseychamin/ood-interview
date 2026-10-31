namespace GroceryStore.DeepDive;

// Decorator that adds a fixed amount discount to an existing strategy
public class FixedDiscountDecorator : IDiscountCalculationStrategy {
    // The strategy being decorated
    private readonly IDiscountCalculationStrategy strategy;
    // The fixed amount to be added to the discount
    private readonly decimal fixedAmount;

    // Creates a new fixed discount decorator with the specified strategy and fixed amount
    public FixedDiscountDecorator(IDiscountCalculationStrategy strategy, decimal fixedAmount) {
        this.strategy = strategy;
        this.fixedAmount = fixedAmount;
    }

    // Calculates the discounted price by applying both the base strategy and the fixed amount
    public decimal CalculateDiscountedPrice(decimal originalPrice) {
        return (strategy.CalculateDiscountedPrice(originalPrice) - fixedAmount);
    }
}
