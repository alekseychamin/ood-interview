# Parking Lot System

This is a C# implementation of a parking lot system that manages vehicle parking, spot allocation, and fare calculation.

## Prerequisites


- .NET SDK 10.0 (C# 14)
- xUnit (restored automatically by `dotnet restore`)

## Project Structure

```
parkinglot/
├── fare/           # Fare calculation related classes
├── spot/           # Parking spot management classes
├── vehicle/        # Vehicle related classes
├── ParkingLot.cs # Main parking lot class
└── ParkingLotTest.cs # Test class
```

## Running the Tests

```bash
# From repository root
dotnet test parking_lot/ParkingLot.csproj
```

## Test Description

The `ParkingLotTest` class contains a test method `TestVehicleJourney()` that verifies:
- Vehicle entry into the parking lot
- Ticket generation
- Finding parked vehicle
- Vehicle exit
- Spot availability after vehicle leaves
