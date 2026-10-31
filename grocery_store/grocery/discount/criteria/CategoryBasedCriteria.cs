namespace GroceryStore;

// Criteria that applies discounts based on item category
public class CategoryBasedCriteria : IDiscountCriteria {
    // The category to check against
    private readonly string category;

    // Creates a new category-based criteria with the specified category
    public CategoryBasedCriteria(string category) {
        this.category = category;
    }

    // Checks if the item belongs to the specified category
    public bool IsApplicable(Item item) {
        return item.Category.Equals(category);
    }
}
