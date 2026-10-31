namespace RestaurantSystem;

// xUnit test ported from JUnit 5

public class RestaurantTest {
    /*
    * Test the restaurant reservation system by creating a reservation and checking if the reservation is correct.
    */
    [Fact]
    public void TestRestaurantReservation() {
        Console.WriteLine("\n=== Testing Restaurant Reservation System ===");
        
        Console.WriteLine("\n--- Setting Up Restaurant Menu ---");
        Menu menu = new Menu();
        menu.AddItem(
                new MenuItem("Burger", "a burger", 10.0m, MenuItem.Category.Main));
        Console.WriteLine("✓ Added menu item: Burger ($10.00) - Main course");

        Console.WriteLine("\n--- Creating Restaurant Layout ---");
        Layout layout = new Layout([4, 4, 6, 6, 10]);
        Console.WriteLine("✓ Created table layout with 5 tables:");
        Console.WriteLine("  - Table 1: 4 seats");
        Console.WriteLine("  - Table 2: 4 seats");
        Console.WriteLine("  - Table 3: 6 seats");
        Console.WriteLine("  - Table 4: 6 seats");
        Console.WriteLine("  - Table 5: 10 seats");

        Console.WriteLine("\n--- Initializing Restaurant ---");
        Restaurant testRestaurant = new Restaurant("BurgerShack", menu, layout);
        Console.WriteLine("✓ Restaurant 'BurgerShack' initialized with menu and layout");

        Console.WriteLine("\n--- Finding Available Time Slots ---");
        DateTime reservationTime = DateTime.Now.AddDays(1).TruncatedToHours();
        DateTime[] possibleReservation =
                testRestaurant.FindAvailableTimeSlots(reservationTime, reservationTime.AddHours(4), 6);
        Console.WriteLine("✓ Searching for available 6-seat tables between " + 
                reservationTime.ToString("yyyy-MM-dd HH:mm") + 
                " and " + reservationTime.AddHours(4).ToString("yyyy-MM-dd HH:mm"));
        Assert.Equal(5, possibleReservation.Length);
        Console.WriteLine("✓ Found " + possibleReservation.Length + " available time slots");
        
        DateTime selectedTime = possibleReservation[2];
        Assert.Equal(selectedTime, reservationTime.AddHours(2));
        Console.WriteLine("✓ Selected reservation time: " + selectedTime.ToString("yyyy-MM-dd HH:mm"));

        Console.WriteLine("\n--- Creating Scheduled Reservation ---");
        Reservation reservation = testRestaurant.CreateScheduledReservation("TestParty", 6, selectedTime);
        Console.WriteLine("✓ Created reservation for 'TestParty' (6 people) at " + selectedTime.ToString("yyyy-MM-dd HH:mm"));
        Assert.Equal("TestParty", reservation.PartyName);
        Assert.Equal(6, reservation.PartySize);
        Assert.Equal(selectedTime, reservation.Time);
        Assert.Equal(6, reservation.AssignedTable.Capacity);
        Console.WriteLine("✓ Reservation details verified:");
        Console.WriteLine("  - Party name: " + reservation.PartyName);
        Console.WriteLine("  - Party size: " + reservation.PartySize + " people");
        Console.WriteLine("  - Reserved time: " + reservation.Time.ToString("yyyy-MM-dd HH:mm"));
        Console.WriteLine("  - Assigned table capacity: " + reservation.AssignedTable.Capacity + " seats");

        Console.WriteLine("\n--- Verifying Table Booking ---");
        // check if the table is actually booked
        Assert.False(reservation.AssignedTable.IsAvailableAt(selectedTime));
        Assert.True(testRestaurant.ReservationManager.Reservations.Contains(reservation));
        Console.WriteLine("✓ Table booking verification passed:");
        Console.WriteLine("  - Table is no longer available at reserved time");
        Console.WriteLine("  - Reservation is properly stored in reservation manager");
        Console.WriteLine("=== Restaurant Reservation Test Completed Successfully ===\n");
    }

    /*
    * Test the restaurant walk-in system by creating a walk-in and checking if the walk-in can be accepted.
     */
    [Fact]
    public void TestRestaurantWalkIn() {
        Console.WriteLine("\n=== Testing Restaurant Walk-In System ===");
        
        Console.WriteLine("\n--- Setting Up Restaurant Menu ---");
        Menu menu = new Menu();
        menu.AddItem(
                new MenuItem("Burger", "a burger", 10.0m, MenuItem.Category.Main));
        Console.WriteLine("✓ Added menu item: Burger ($10.00) - Main course");

        Console.WriteLine("\n--- Creating Restaurant Layout ---");
        Layout layout = new Layout([4, 4, 6, 6, 10]);
        Console.WriteLine("✓ Created table layout with 5 tables (4, 4, 6, 6, 10 seats)");

        Console.WriteLine("\n--- Initializing Restaurant ---");
        Restaurant testRestaurant = new Restaurant("BurgerShack", menu, layout);
        Console.WriteLine("✓ Restaurant 'BurgerShack' initialized");

        Console.WriteLine("\n--- Processing Walk-In Reservation ---");
        Reservation walkIn = testRestaurant.CreateWalkInReservation("WalkIn", 4);
        Console.WriteLine("✓ Created walk-in reservation for 'WalkIn' party (4 people)");
        Table table = walkIn.AssignedTable;
        Assert.Equal(4, table.Capacity);
        Assert.Equal(4, table.CurrentPartySize);
        Console.WriteLine("✓ Walk-in assignment verified:");
        Console.WriteLine("  - Assigned table capacity: " + table.Capacity + " seats");
        Console.WriteLine("  - Current party size: " + table.CurrentPartySize + " people");

        Console.WriteLine("\n--- Processing Order ---");
        table.AddOrder(menu.GetItem("Burger"), 4);
        Console.WriteLine("✓ Added order: 4 Burgers ($10.00 each)");
        Assert.Equal(40.0m, table.CalculateBillAmount());
        Console.WriteLine("✓ Bill calculation verified: $" + table.CalculateBillAmount());
        Console.WriteLine("  - 4 Burgers × $10.00 = $40.00");
        Console.WriteLine("=== Restaurant Walk-In Test Completed Successfully ===\n");
    }
}
