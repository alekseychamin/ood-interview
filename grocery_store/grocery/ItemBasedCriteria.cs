namespace GroceryStore;

public class ItemBasedCriteria : IDiscountCriteria {
    private readonly string itemId;

    public ItemBasedCriteria(string itemId) {
        this.itemId = itemId;
    }

    public bool IsApplicable(Item item) {
        return item.Barcode.Equals(itemId);
    }
}
