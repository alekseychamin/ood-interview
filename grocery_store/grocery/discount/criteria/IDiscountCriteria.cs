namespace GroceryStore;

// Interface for discount criteria that determine if a discount applies to an item
public interface IDiscountCriteria {
    // Checks if the discount criteria applies to the given item
    bool IsApplicable(Item item);
}
