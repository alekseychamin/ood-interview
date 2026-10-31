# Restaurant Management System

This project is a simple Restaurant Management System implemented in C# (.NET 10). It supports table reservations, walk-ins, menu management, and order processing.

## Prerequisites

- .NET SDK 10.0 (C# 14)
- xUnit (restored automatically by `dotnet restore`)

## Project Structure
- `restaurant/` - Main source code (namespaces for menu, reservation, table, etc.)
- `run_tests.sh` - Script to compile and run the tests
- `README.md` - This file

## Running the Tests

```bash
# From repository root
dotnet test restaurant/Restaurant.csproj
```

## Notes
- The main business logic is in the `restaurant/` directory, organized by feature (menu, reservation, table, etc.).
- The project is built with the .NET SDK (`dotnet test`).
- You can add your own tests to `restaurant/RestaurantTest.cs` or create new test files and run them similarly.
