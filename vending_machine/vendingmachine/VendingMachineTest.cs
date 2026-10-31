namespace VendingMachineSystem;

// xUnit test ported from JUnit 5

public class VendingMachineTest {
    [Fact]
    public void TestEndToEndVending(){
        Console.WriteLine("\n=== Testing Vending Machine System: End-to-End Operations ===");
        
        Console.WriteLine("\n--- Initializing Vending Machine ---");
        VendingMachine machine = new VendingMachine();
        Console.WriteLine("✓ Vending machine initialized");

        Console.WriteLine("\n--- Setting Up Products and Inventory ---");
        Product itemA = new Product("a", "Product A", 1.0m);
        Product itemB = new Product("b", "Product B", 1.5m);
        Product itemC = new Product("c", "Product C", 1.25m);
        machine.SetRack(
                new Dictionary<string, Rack> {
                        ["A1"] = new Rack("A1", itemA, 10),
                        ["A2"] = new Rack("A2", itemB, 5),
                        ["A3"] = new Rack("A3", itemC, 15),
                });
        Console.WriteLine("✓ Products loaded into vending machine:");
        Console.WriteLine("  - A1: Product A ($1.00) - 10 units available");
        Console.WriteLine("  - A2: Product B ($1.50) - 5 units available");
        Console.WriteLine("  - A3: Product C ($1.25) - 15 units available");

        Console.WriteLine("\n--- First Purchase Transaction ---");
        machine.InsertMoney(20.00m);
        Console.WriteLine("✓ Inserted $20.00 into machine");
        machine.ChooseProduct("A2");
        Console.WriteLine("✓ Selected Product B (A2) - Price: $1.50");
        Transaction transaction = machine.ConfirmTransaction();
        Assert.Equal(itemB, transaction.Product);
        Assert.Equal(18.50m, transaction.TotalAmount);
        Console.WriteLine("✓ Transaction completed successfully:");
        Console.WriteLine("  - Product dispensed: Product B");
        Console.WriteLine("  - Change returned: $18.50");

        Console.WriteLine("\n--- Second Purchase Transaction ---");
        machine.InsertMoney(6.00m);
        Console.WriteLine("✓ Inserted $6.00 into machine");
        machine.ChooseProduct("A2");
        Console.WriteLine("✓ Selected Product B (A2) - Price: $1.50");
        transaction = machine.ConfirmTransaction();
        Assert.Equal(itemB, transaction.Product);
        Assert.Equal(4.50m, transaction.TotalAmount);
        Console.WriteLine("✓ Transaction completed successfully:");
        Console.WriteLine("  - Product dispensed: Product B");
        Console.WriteLine("  - Change returned: $4.50");

        Console.WriteLine("\n--- Third Purchase Attempt (Should Fail) ---");
        machine.InsertMoney(1.00m);
        Console.WriteLine("✓ Inserted $1.00 into machine");
        machine.ChooseProduct("A2");
        Console.WriteLine("✓ Selected Product B (A2) - Price: $1.50");
        Console.WriteLine("✓ Attempting to purchase with insufficient funds...");
        InvalidTransactionException exception = Assert.Throws<InvalidTransactionException>( () => {
            machine.ConfirmTransaction();
        });
        Assert.Equal("Insufficient fund", exception.Message);
        Console.WriteLine("✓ Transaction correctly rejected:");
        Console.WriteLine("  - Error: Insufficient fund");
        Console.WriteLine("  - Expected behavior: Cannot purchase $1.50 item with $1.00");

        Console.WriteLine("\n--- Canceling Failed Transaction ---");
        machine.CancelTransaction();
        Console.WriteLine("✓ Transaction canceled, money returned to customer");

        Console.WriteLine("\n--- Verifying Transaction History ---");
        List<Transaction> history = machine.TransactionHistory;
        Assert.Equal(2, history.Count);
        Assert.Equal(itemB, history[0].Product);
        Assert.Equal(itemB, history[1].Product);
        Console.WriteLine("✓ Transaction history verified:");
        Console.WriteLine("  - Total successful transactions: " + history.Count);
        Console.WriteLine("  - Both transactions were for Product B");

        Console.WriteLine("\n--- Verifying Inventory Levels ---");
        InventoryManager inventory = machine.InventoryManager;
        Assert.Equal(3, inventory.GetRack("A2").ProductCount);
        Console.WriteLine("✓ Inventory levels verified:");
        Console.WriteLine("  - Product B (A2) remaining: " + inventory.GetRack("A2").ProductCount + " units");
        Console.WriteLine("  - Started with 5 units, sold 2 units, remaining 3 units");
        Console.WriteLine("=== Vending Machine Test Completed Successfully ===\n");
    }
}
