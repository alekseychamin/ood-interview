namespace GroceryStore;

public class Inventory {
    // Map of barcodes to their stock quantities
    private readonly Dictionary<string, int> stock = new();

    // Adds or updates stock quantity for an item
    public void AddStock(string barcode, int count) {
        stock[barcode] = stock.GetValueOrDefault(barcode, 0) + count;
    }

    // Reduces stock quantity for an item
    public void ReduceStock(string barcode, int count) {
        stock[barcode] = stock.GetValueOrDefault(barcode, 0) - count;
    }

    // Gets the current stock quantity for an item
    public int GetStock(string barcode) {
        return stock.GetValueOrDefault(barcode, 0);
    }
}
