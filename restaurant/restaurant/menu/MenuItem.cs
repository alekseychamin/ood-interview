namespace RestaurantSystem;

// Represents a single item available on the restaurant menu
public class MenuItem {
    private readonly string name;
    private readonly string description;
    private readonly decimal price;
    private readonly Category category;

    public MenuItem(string name, string description, decimal price, Category category) {
        this.name = name;
        this.description = description;
        this.price = price;
        this.category = category;
    }

    public string Name => name;

    public string Description => description;

    public decimal Price => price;

    // Named ItemCategory because C# does not allow a member with the same name as the nested enum
    public Category ItemCategory => category;

    // Enumeration of possible menu item categories
    public enum Category {
        Main,
        Appetizer,
        Dessert
    }
}
