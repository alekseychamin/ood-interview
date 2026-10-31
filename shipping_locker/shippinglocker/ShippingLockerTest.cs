namespace ShippingLocker;

// xUnit test ported from JUnit 5

public class ShippingLockerTest {
    [Fact]
    public void TestLockerManager() {
        Console.WriteLine("\n=== Testing Shipping Locker System ===");
        
        Console.WriteLine("\n--- Initializing Locker Manager ---");
        LockerManager lockerManager = CreateLockerManager();
        Console.WriteLine("✓ Locker manager initialized with test site and accounts");

        Console.WriteLine("\n--- Retrieving Test Account ---");
        Account testAccount = lockerManager.GetAccount("testAccount");
        Console.WriteLine("✓ Retrieved account: 'testAccount' (Owner: " + testAccount.OwnerName + ")");

        Console.WriteLine("\n--- Creating Shipping Package ---");
        IShippingPackage pkg = new BasicShippingPackage("orderId", testAccount, 
            10.00m, 10.00m, 10.00m);
        Console.WriteLine("✓ Created shipping package:");
        Console.WriteLine("  - Order ID: orderId");
        Console.WriteLine("  - Dimensions: 10.00 × 10.00 × 10.00 inches");
        Console.WriteLine("  - Account: testAccount");

        Console.WriteLine("\n--- Assigning Package to Locker ---");
        DateTime today = DateTime.Now;
        DateTime twoDaysAgo = today.AddDays(-2);
        Console.WriteLine("✓ Package delivery date: " + twoDaysAgo);
        Locker assignedLocker = lockerManager.AssignPackage(pkg, twoDaysAgo);
        Console.WriteLine("✓ Package assigned to locker successfully");
        Assert.Equal(LockerSize.Small, assignedLocker.Size);
        Assert.Equal(ShippingStatus.InLocker, pkg.Status);
        Assert.False(assignedLocker.IsAvailable);
        Console.WriteLine("✓ Package assignment verified:");
        Console.WriteLine("  - Assigned locker size: SMALL");
        Console.WriteLine("  - Package status: IN_LOCKER");
        Console.WriteLine("  - Locker is now occupied");

        Console.WriteLine("\n--- Generating Access Code ---");
        string access = assignedLocker.AccessCode;
        Console.WriteLine("✓ Access code generated for package pickup");

        Console.WriteLine("\n--- Processing Package Pickup ---");
        Locker foundLocker = lockerManager.PickUpPackage(access);
        Console.WriteLine("✓ Package picked up using access code");
        Assert.True(foundLocker.IsAvailable);
        Assert.Equal(foundLocker, assignedLocker);
        Assert.Equal(ShippingStatus.Retrieved, pkg.Status);
        Console.WriteLine("✓ Package pickup verified:");
        Console.WriteLine("  - Locker is now available");
        Console.WriteLine("  - Package status: RETRIEVED");
        Console.WriteLine("  - Correct locker accessed");

        Console.WriteLine("\n--- Verifying Account Charges ---");
        Assert.True(10m == testAccount.UsageCharges);
        Console.WriteLine("✓ Account charges verified: $" + testAccount.UsageCharges);
        Console.WriteLine("=== Shipping Locker Test Completed Successfully ===\n");
    }

    private static LockerManager CreateLockerManager() {
        Console.WriteLine("  - Creating locker site with 10 lockers of each size (SMALL, MEDIUM, LARGE)");
        Dictionary<LockerSize, int> lockerSizeToCountMap =
                new() {
                    [LockerSize.Small] = 10,
                    [LockerSize.Medium] = 10,
                    [LockerSize.Large] = 10,
                };
        Site testSite = new Site(lockerSizeToCountMap);

        Console.WriteLine("  - Creating test account with locker policy (0-10 lockers allowed)");
        AccountLockerPolicy policy = new AccountLockerPolicy(0, 10);
        Account testAccount = new Account("testAccount", "testOwnerName", policy);

        Console.WriteLine("  - Setting up account management system");
        Dictionary<string, Account> accountMap = new() { ["testAccount"] = testAccount };

        return new LockerManager(
                testSite,
                accountMap,
                new ConsoleNotification()
        );
    }

    // Java passes a lambda for the functional interface; C# interfaces need an implementing class
    private class ConsoleNotification : INotification {
        public void SendNotification(string message, Account user) {
            // print out the email to manually verify during the interview
            Console.WriteLine("Notification to " + user.OwnerName + ": " + message);
        }
    }
}
