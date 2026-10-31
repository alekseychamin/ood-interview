namespace GroceryStore;

public class Item {
    // Name of the item
    private readonly string name;
    // Unique barcode identifier
    private readonly string barcode;
    // Category of the item (e.g., Fruit, Candy)
    private readonly string category;
    // Price of the item
    private readonly decimal price;

    // Creates a new item with the specified details
    public Item(string name, string barcode, string category, decimal price) {
        this.name = name;
        this.barcode = barcode;
        this.category = category;
        this.price = price;
    }

    // Returns the name of the item
    public string Name => name;

    // Returns the barcode of the item
    public string Barcode => barcode;

    // Returns the category of the item
    public string Category => category;

    // Returns the price of the item
    public decimal Price => price;
}
