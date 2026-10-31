namespace GroceryStore;

public class Catalog {
    // Map of barcodes to their corresponding items
    private readonly Dictionary<string, Item> items = new();

    // Updates or adds an item to the catalog
    public void UpdateItem(Item item) {
        items[item.Barcode] = item;
    }

    // Removes an item from the catalog by its barcode
    public void RemoveItem(string barcode) {
        items.Remove(barcode);
    }

    // Retrieves an item from the catalog by its barcode
    public Item GetItem(string barcode) {
        return items.GetValueOrDefault(barcode);
    }
}
