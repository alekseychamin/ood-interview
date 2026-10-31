namespace GroceryStore;

public class GroceryStoreSystem {
    // Product catalog containing all available items
    private readonly Catalog catalog;
    // Inventory tracking system
    private readonly Inventory inventory;
    // List of active discount campaigns
    private List<DiscountCampaign> activeDiscounts = new();
    // Checkout system for processing orders
    private readonly Checkout checkout;

    // Creates a new grocery store system with default components
    public GroceryStoreSystem(){
        this.catalog = new Catalog();
        this.inventory = new Inventory();
        this.checkout = new Checkout(activeDiscounts);
    }

    // Creates a new grocery store system with custom components
    public GroceryStoreSystem(Catalog catalog, Inventory inventory, List<DiscountCampaign> activeDiscounts) {
        this.catalog = catalog;
        this.inventory = inventory;
        this.activeDiscounts = activeDiscounts;
        this.checkout = new Checkout(activeDiscounts);
    }

    // Adds or updates an item in the catalog
    public void AddOrUpdateItem(Item item) {
        catalog.UpdateItem(item);
    }

    // Updates the inventory count for an item
    public void UpdateInventory(string barcode, int count) {
        inventory.AddStock(barcode, count);
    }

    // Adds a new discount campaign to the system
    public void AddDiscountCampaign(DiscountCampaign discount) {
        activeDiscounts.Add(discount);
    }

    // Returns the checkout system
    public Checkout Checkout => checkout;

    // Retrieves an item from the catalog by its barcode
    public Item GetItemByBarcode(string barcode) {
        return catalog.GetItem(barcode);
    }

    // Removes an item from the catalog
    public void RemoveItem(string barcode) {
        catalog.RemoveItem(barcode);
    }
}
