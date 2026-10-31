# Elevator System

This is an implementation of an elevator control system that manages elevator operations in a building. The system handles elevator requests, movement, and dispatching using different strategies.

## Project Structure

```
elevator/
├── components/
│   ├── Direction.cs         # Enum for elevator direction (Up, Down, Idle)
│   ├── ElevatorCar.cs      # Core elevator functionality
│   ├── ElevatorStatus.cs   # Status representation of elevator
│   └── HallwayButtonPanel.cs # Handles elevator call buttons
├── dispatch/
│   ├── IDispatchingStrategy.cs        # Interface for elevator selection strategies
│   ├── ElevatorDispatch.cs           # Handles elevator dispatching
│   ├── FirstComeFirstServeStrategy.cs # Simple dispatching strategy
│   └── ShortestSeekTimeFirstStrategy.cs # Optimized dispatching strategy
├── ElevatorSystem.cs       # Main elevator system controller
└── ElevatorSystemTest.cs   # Test cases for the elevator system
```

## Prerequisites


- .NET SDK 10.0 (C# 14)
- xUnit (restored automatically by `dotnet restore`)

## Running the Tests

```bash
# From repository root
dotnet test elevator_system/Elevator.csproj
```

## System Features

1. **Basic Elevator Operations**
   - Move up and down
   - Stop at requested floors
   - Track current floor and direction
   - Handle floor requests

2. **Dispatching Strategies**
   - First Come First Serve: Assigns requests to elevators in order
   - Shortest Seek Time First: Optimizes elevator selection based on distance

3. **Status Monitoring**
   - Current floor tracking
   - Direction status (Up, Down, Idle)
   - Destination queue management

## Example Usage

```csharp
// Create an elevator car starting at floor 1
ElevatorCar car = new ElevatorCar(1);

// Create an elevator system with a dispatching strategy
ElevatorSystem elevatorSystem = new ElevatorSystem(
    [car],
    new FirstComeFirstServeStrategy()
);

// Request an elevator from floor 3 going up
elevatorSystem.RequestElevator(3, Direction.Up);

// Select a destination floor from inside the elevator
elevatorSystem.SelectFloor(car, 8);
```

## Testing

The system includes comprehensive tests in `ElevatorSystemTest.cs` that verify:
- Elevator movement
- Direction changes
- Floor request handling
- Destination management
- Dispatching logic
