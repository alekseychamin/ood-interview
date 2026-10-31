namespace ParkingLotSystem;

// xUnit test ported from JUnit 5

public class ParkingLotTest {
    [Fact]
    public void TestVehicleJourney() {
        Console.WriteLine("\n=== Testing Parking Lot System: Complete Vehicle Journey ===");
        
        Console.WriteLine("\n--- Setting Up Parking Spots ---");
        Dictionary<VehicleSize, List<IParkingSpot>> availableSpots = new();
        availableSpots[VehicleSize.Medium] = new();
        availableSpots.GetValueOrDefault(VehicleSize.Medium).Add(new RegularSpot(1));
        availableSpots.GetValueOrDefault(VehicleSize.Medium).Add(new RegularSpot(2));
        Console.WriteLine("✓ Created 2 regular parking spots for medium-sized vehicles");
        Console.WriteLine("  - Spot 1: Regular parking spot");
        Console.WriteLine("  - Spot 2: Regular parking spot");

        Console.WriteLine("\n--- Initializing Parking Manager ---");
        ParkingManager parkingManager = new ParkingManager(availableSpots);
        Console.WriteLine("✓ Parking manager initialized with available spots");

        Console.WriteLine("\n--- Setting Up Fare Calculation System ---");
        List<IFareStrategy> strategies = [new BaseFareStrategy(), new PeakHoursFareStrategy()];
        FareCalculator fareCalculator = new FareCalculator(strategies);
        Console.WriteLine("✓ Fare calculator initialized with multiple strategies:");
        Console.WriteLine("  - Base fare strategy");
        Console.WriteLine("  - Peak hours fare strategy");

        ParkingLot parkingLot = new ParkingLot(parkingManager, fareCalculator);
        
        Console.WriteLine("\n--- Creating Test Vehicle ---");
        IVehicle car = new Car("ABC123");
        Console.WriteLine("✓ Created car with license plate: ABC123");
        Console.WriteLine("  - Vehicle type: Car (MEDIUM size)");

        Console.WriteLine("\n--- Vehicle Entering Parking Lot ---");
        // Vehicle enters the parking lot
        Ticket ticket = parkingLot.EnterVehicle(car);
        Console.WriteLine("✓ Ticket generated for vehicle ABC123");
        Console.WriteLine("✓ Parking spot assigned: " + ticket.ParkingSpot.SpotNumber);
        Assert.NotNull(ticket); // "Ticket should not be null"
        Assert.Equal(car, ticket.Vehicle); // "Vehicle should match the one that entered"
        Assert.NotNull(ticket.ParkingSpot); // "Parking spot should not be null"
        Console.WriteLine("✓ Ticket validation passed:");
        Console.WriteLine("  - Ticket is not null");
        Console.WriteLine("  - Vehicle matches the one that entered");
        Console.WriteLine("  - Parking spot assigned successfully");

        // Find the vehicle in the parking lot
        IParkingSpot foundSpot = parkingManager.FindVehicleSpot(car);
        Assert.NotNull(foundSpot); // "Vehicle should be found in the parking lot"
        Assert.Equal(ticket.ParkingSpot, foundSpot); // "Found spot should match the ticket's spot"
        
        Console.WriteLine("\n--- Vehicle Leaving Parking Lot ---");
        // Vehicle leaves the parking lot
        parkingLot.LeaveVehicle(ticket);
        Assert.NotNull(ticket.ExitTime); // "Exit time should be set"
        Assert.True(foundSpot.IsAvailable, "Parking spot should be available after vehicle leaves");
        Console.WriteLine("✓ Vehicle exit verification passed:");
        Console.WriteLine("  - Exit time recorded on ticket");
        Console.WriteLine("  - Parking spot is now available for other vehicles");
        Console.WriteLine("=== Parking Lot Vehicle Journey Test Completed Successfully ===\n");
    }
}
