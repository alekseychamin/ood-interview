namespace GroceryStore;

// xUnit test ported from JUnit 5

public class GroceryStoreSystemTest {

    [Fact]
    public void TestEndToEnd() {
        Console.WriteLine("\n=== Testing Grocery Store System End-to-End ===");
        
        Console.WriteLine("\n--- Initializing Grocery Store System ---");
        // initialize grocery store
        GroceryStoreSystem groceryStoreSystem = new GroceryStoreSystem();
        Console.WriteLine("✓ Grocery store system initialized");

        Console.WriteLine("\n--- Setting Up Product Catalog ---");
        // set up catalog, inventory, and example discount
        groceryStoreSystem.AddOrUpdateItem(new Item("Apple", "123", "Fruit", 0.5m));
        groceryStoreSystem.AddOrUpdateItem(new Item("Banana", "124", "Fruit", 1.0m));
        groceryStoreSystem.AddOrUpdateItem(new Item("Gum", "125", "Candy", 4.0m));
        Console.WriteLine("✓ Added Apple (barcode: 123, category: Fruit, price: $0.50)");
        Console.WriteLine("✓ Added Banana (barcode: 124, category: Fruit, price: $1.00)");
        Console.WriteLine("✓ Added Gum (barcode: 125, category: Candy, price: $4.00)");

        Console.WriteLine("\n--- Setting Up Inventory ---");
        groceryStoreSystem.UpdateInventory("123", 100);
        groceryStoreSystem.UpdateInventory("124", 100);
        groceryStoreSystem.UpdateInventory("125", 100);
        Console.WriteLine("✓ Set inventory: 100 Apples, 100 Bananas, 100 Gum packs");

        Console.WriteLine("\n--- Creating Discount Campaign ---");
        groceryStoreSystem.AddDiscountCampaign(
                new DiscountCampaign("1", "Fruit Half Price",
                        new CategoryBasedCriteria("Fruit"),
                        new PercentageBasedStrategy(50m)));
        Console.WriteLine("✓ Created discount campaign: 'Fruit Half Price'");
        Console.WriteLine("  - Applies to all items in 'Fruit' category");
        Console.WriteLine("  - 50% discount on all fruit items");

        Console.WriteLine("\n--- Starting Checkout Session ---");
        // start a new order
        Checkout checkOutSession = groceryStoreSystem.Checkout;
        Console.WriteLine("✓ New checkout session created");

        Console.WriteLine("\n--- Adding Items to Order ---");
        checkOutSession.AddItemToOrder(groceryStoreSystem.GetItemByBarcode("123"), 20);
        checkOutSession.AddItemToOrder(groceryStoreSystem.GetItemByBarcode("124"), 10);
        checkOutSession.AddItemToOrder(groceryStoreSystem.GetItemByBarcode("125"), 5);
        Console.WriteLine("✓ Added 20 Apples to order (original price: $10.00, with 50% discount: $5.00)");
        Console.WriteLine("✓ Added 10 Bananas to order (original price: $10.00, with 50% discount: $5.00)");
        Console.WriteLine("✓ Added 5 Gum packs to order (no discount: $20.00)");

        Console.WriteLine("\n--- Calculating Order Total ---");
        // verify total
        decimal total = checkOutSession.OrderTotal;
        Console.WriteLine("✓ Order total calculated: $" + total);
        Console.WriteLine("  - Fruit items (with 50% discount): $10.00");
        Console.WriteLine("  - Candy items (no discount): $20.00");
        Console.WriteLine("  - Total: $30.00");
        Assert.Equal(30.0m, total);

        Console.WriteLine("\n--- Processing Payment ---");
        // verify change
        decimal change = checkOutSession.ProcessPayment(100m);
        Console.WriteLine("✓ Customer paid: $100.00");
        Console.WriteLine("✓ Change calculated: $" + change);
        Console.WriteLine("  - Amount paid: $100.00");
        Console.WriteLine("  - Order total: $30.00");
        Console.WriteLine("  - Change due: $70.00");
        Assert.Equal(70.0m, change);

        Console.WriteLine("\n--- Generating Receipt ---");
        Receipt receipt = checkOutSession.Receipt;
        Console.WriteLine("✓ Receipt generated successfully");
        Console.WriteLine("=== Receipt Details ===");
        Console.WriteLine(receipt.PrintReceipt());
        Console.WriteLine("=== End-to-End Test Completed Successfully ===\n");
    }

    // Test managing the catalogue
    [Fact]
    public void TestCatalogueManagement() {
        Console.WriteLine("\n=== Testing Catalog Management System ===");
        
        Console.WriteLine("\n--- Initializing Grocery Store System ---");
        GroceryStoreSystem groceryStoreSystem = new GroceryStoreSystem();
        Console.WriteLine("✓ Grocery store system initialized");

        Console.WriteLine("\n--- Adding Items to Catalog ---");
        groceryStoreSystem.AddOrUpdateItem(new Item("Apple", "123", "Fruit", 0.5m));
        groceryStoreSystem.AddOrUpdateItem(new Item("Banana", "124", "Fruit", 1.0m));
        groceryStoreSystem.AddOrUpdateItem(new Item("Gum", "125", "Candy", 4.0m));
        Console.WriteLine("✓ Added Apple (barcode: 123, category: Fruit, price: $0.50)");
        Console.WriteLine("✓ Added Banana (barcode: 124, category: Fruit, price: $1.00)");
        Console.WriteLine("✓ Added Gum (barcode: 125, category: Candy, price: $4.00)");

        Console.WriteLine("\n--- Verifying Item Retrieval by Barcode ---");
        Assert.Equal("Apple", groceryStoreSystem.GetItemByBarcode("123").Name);
        Assert.Equal("Banana", groceryStoreSystem.GetItemByBarcode("124").Name);
        Assert.Equal("Gum", groceryStoreSystem.GetItemByBarcode("125").Name);
        Console.WriteLine("✓ Successfully retrieved Apple by barcode 123");
        Console.WriteLine("✓ Successfully retrieved Banana by barcode 124");
        Console.WriteLine("✓ Successfully retrieved Gum by barcode 125");

        Console.WriteLine("\n--- Testing Item Update (Price and Category Change) ---");
        // test change a barcode item price and category
        groceryStoreSystem.AddOrUpdateItem(
                new Item("Bread", "123", "Pantry", 0.6m));
        Console.WriteLine("✓ Updated item with barcode 123:");
        Console.WriteLine("  - Name changed from 'Apple' to 'Bread'");
        Console.WriteLine("  - Category changed from 'Fruit' to 'Pantry'");
        Console.WriteLine("  - Price changed from $0.50 to $0.60");
        Assert.Equal(0.6m, groceryStoreSystem.GetItemByBarcode("123").Price);
        Assert.Equal("Pantry", groceryStoreSystem.GetItemByBarcode("123").Category);
        Console.WriteLine("✓ Item update verified successfully");

        Console.WriteLine("\n--- Testing Item Removal ---");
        // test remove item
        groceryStoreSystem.RemoveItem("123");
        Console.WriteLine("✓ Removed item with barcode 123 from catalog");
        Assert.Null(groceryStoreSystem.GetItemByBarcode("123"));
        Console.WriteLine("✓ Item removal verified: barcode 123 no longer exists in catalog");
        Console.WriteLine("=== Catalog Management Test Completed Successfully ===\n");
    }
}
