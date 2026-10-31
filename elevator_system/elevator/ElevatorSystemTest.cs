namespace Elevator;

// xUnit test ported from JUnit 5

public class ElevatorSystemTest {

    // create a test for the elevator system for a case where one order elevator and then
    // select a floor to go to
    [Fact]
    public void TestElevatorFeature() {
        Console.WriteLine("\n=== Testing Elevator System Features ===");
        
        // set up
        ElevatorCar car = new ElevatorCar(1);
        ElevatorSystem elevatorSystem = new ElevatorSystem([car], new FirstComeFirstServeStrategy());
        Console.WriteLine("✓ Elevator system initialized with 1 elevator car starting at floor 1");
        Console.WriteLine("✓ Using First-Come-First-Serve dispatching strategy");

        // test that the elevator is idle
        Console.WriteLine("\n--- Initial State Check ---");
        List<ElevatorStatus> elevators = elevatorSystem.AllElevatorStatuses;
        Assert.Equal(1, elevators[0].CurrentFloor);
        Assert.Equal(Direction.Idle, elevators[0].CurrentDirection);
        Console.WriteLine("✓ Elevator is at floor 1 and in IDLE state (ready for requests)");

        // test action to hail the elevator from floor 3
        Console.WriteLine("\n--- Requesting Elevator from Floor 3 (Going UP) ---");
        elevatorSystem.RequestElevator(3, Direction.Up);
        Console.WriteLine("✓ Elevator requested from floor 3 going UP");

        // test that the elevator is moving
        elevators = elevatorSystem.AllElevatorStatuses;
        Assert.Equal(1, elevators[0].CurrentFloor);
        Assert.Equal(Direction.Up, elevators[0].CurrentDirection);
        Assert.False(car.IsAtDestination);
        Console.WriteLine("✓ Elevator direction changed to UP (preparing to move)");
        
        //test the elevator car's queue is to go to floor 3
        Console.WriteLine("\n--- Elevator Movement: Step 1 ---");
        car.MoveOneStep();
        elevators = elevatorSystem.AllElevatorStatuses;
        Assert.Equal(2, elevators[0].CurrentFloor);
        Assert.Equal(Direction.Up, elevators[0].CurrentDirection);
        Assert.False(car.IsAtDestination);
        Console.WriteLine("✓ Elevator moved from floor 1 → floor 2");
        Console.WriteLine("✓ Still moving UP toward destination (floor 3)");

        Console.WriteLine("\n--- Elevator Movement: Step 2 ---");
        car.MoveOneStep();
        elevators = elevatorSystem.AllElevatorStatuses;
        Assert.Equal(3, elevators[0].CurrentFloor);
        Assert.Equal(Direction.Up, elevators[0].CurrentDirection);
        Assert.True(car.IsAtDestination);
        Console.WriteLine("✓ Elevator moved from floor 2 → floor 3");
        Console.WriteLine("✓ Reached destination floor 3");

        Console.WriteLine("\n--- Arriving at Destination ---");
        car.MoveOneStep();
        elevators = elevatorSystem.AllElevatorStatuses;
        Assert.Equal(3, elevators[0].CurrentFloor);
        Assert.Equal(Direction.Idle, elevators[0].CurrentDirection);
        Assert.False(car.IsAtDestination);
        Console.WriteLine("✓ Elevator stopped at floor 3");
        Console.WriteLine("✓ Direction changed back to IDLE (ready for next request)");

        // now test the moveUntilNextFloor method, hail the elevator in both floor 8 and floor 6
        Console.WriteLine("\n--- Multiple Floor Requests ---");
        elevatorSystem.RequestElevator(8, Direction.Down);
        elevatorSystem.RequestElevator(6, Direction.Down);
        Console.WriteLine("✓ New requests: Floor 8 (DOWN) and Floor 6 (DOWN)");
        Console.WriteLine("✓ Elevator will handle requests in order (First-Come-First-Serve)");

        // test that the elevator is moving to floor 8
        Console.WriteLine("\n--- Moving to Floor 8 (First Request) ---");
        car.MoveUntilNextFloor();
        elevators = elevatorSystem.AllElevatorStatuses;
        Assert.Equal(8, elevators[0].CurrentFloor);
        Assert.Equal(Direction.Up, elevators[0].CurrentDirection);
        Assert.True(car.IsAtDestination);
        Console.WriteLine("✓ Elevator moved directly to floor 8 (first request)");
        Console.WriteLine("✓ Direction is UP (moving upward to reach floor 8)");

        // test that the elevator is moving to floor 6
        Console.WriteLine("\n--- Moving to Floor 6 (Second Request) ---");
        car.NextDestination();
        car.MoveUntilNextFloor();
        elevators = elevatorSystem.AllElevatorStatuses;
        Assert.Equal(6, elevators[0].CurrentFloor);
        Assert.Equal(Direction.Down, elevators[0].CurrentDirection);
        Assert.True(car.IsAtDestination);
        Console.WriteLine("✓ Elevator moved from floor 8 → floor 6 (second request)");
        Console.WriteLine("✓ Direction is DOWN (moving downward from floor 8 to floor 6)");
        Console.WriteLine("✓ All requests completed successfully");
        Console.WriteLine("=== Elevator System Test Completed Successfully ===\n");
    }
}
