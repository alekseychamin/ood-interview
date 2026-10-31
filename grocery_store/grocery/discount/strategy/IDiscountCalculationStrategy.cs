namespace GroceryStore;

// Interface for discount calculation strategies
public interface IDiscountCalculationStrategy {
    // Calculates the discounted price based on the original price
    decimal CalculateDiscountedPrice(decimal originalPrice);
}
