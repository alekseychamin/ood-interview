namespace GroceryStore.DeepDive;

// Decorator that adds a percentage discount to an existing strategy
public class PercentageDiscountDecorator : IDiscountCalculationStrategy {
    // The strategy being decorated
    private readonly IDiscountCalculationStrategy strategy;
    // The additional percentage to be discounted
    private readonly decimal additionalPercentage;

    // Creates a new percentage discount decorator with the specified strategy and additional percentage
    public PercentageDiscountDecorator(IDiscountCalculationStrategy strategy, decimal additionalPercentage) {
        this.strategy = strategy;
        this.additionalPercentage = additionalPercentage;
    }

    // Calculates the discounted price by applying both the base strategy and the additional percentage
    public decimal CalculateDiscountedPrice(decimal originalPrice) {
        decimal baseDiscountedPrice = strategy.CalculateDiscountedPrice(originalPrice);
        return (baseDiscountedPrice * (1m - (additionalPercentage / 100m)));
    }
}
