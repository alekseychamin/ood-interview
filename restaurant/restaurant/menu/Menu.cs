namespace RestaurantSystem;

public class Menu {
    private readonly Dictionary<string, MenuItem> menuItems = new();

    // Adds a new item to the menu
    public void AddItem(MenuItem item) {
        menuItems[item.Name] = item;
    }

    public MenuItem GetItem(string name) {
        return menuItems.GetValueOrDefault(name);
    }

    public Dictionary<string, MenuItem> MenuItems => new(menuItems);
}
