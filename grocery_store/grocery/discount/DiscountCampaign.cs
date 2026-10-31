namespace GroceryStore;

public class DiscountCampaign {
    // Unique identifier for the discount campaign
    private readonly string discountId;
    // Name of the discount campaign
    private readonly string name;
    // Criteria that determines if the discount applies to an item
    private readonly IDiscountCriteria criteria;
    // Strategy for calculating the discounted price
    private readonly IDiscountCalculationStrategy calculationStrategy;

    // Creates a new discount campaign with the specified details
    public DiscountCampaign(string discountId,
                            string name,
                            IDiscountCriteria criteria,
                            IDiscountCalculationStrategy calculationStrategy) {
        this.discountId = discountId;
        this.name = name;
        this.criteria = criteria;
        this.calculationStrategy = calculationStrategy;
    }

    // Checks if this discount applies to the given item
    public bool IsApplicable(Item item) {
        return criteria.IsApplicable(item);
    }

    // Calculates the discounted price for the given order item
    public decimal CalculateDiscount(OrderItem item) {
        return calculationStrategy.CalculateDiscountedPrice(item.CalculatePrice());
    }

    // Returns the name of the discount campaign
    public string Name => name;

    public string DiscountId => discountId;
}
