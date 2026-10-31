# Grocery Store System

A C#-based grocery store system that manages inventory, processes orders, and applies discounts.

## Prerequisites


- .NET SDK 10.0 (C# 14)
- xUnit (restored automatically by `dotnet restore`)

## Project Structure

```
grocery/
├── discount/
│   ├── criteria/
│   └── strategy/
├── GroceryStoreSystem.cs
├── GroceryStoreSystemTest.cs
└── ... (other C# files)
```

## Running the Tests

```bash
# From repository root
dotnet test grocery_store/GroceryStore.csproj
```

## Test Results

The test suite includes two main tests:

1. `TestEndToEnd()`: Tests the complete flow of the grocery store system
   - Adding items to catalog
   - Updating inventory
   - Applying discounts
   - Processing orders
   - Generating receipts

2. `TestCatalogueManagement()`: Tests catalog management functionality
   - Adding items
   - Updating item details
   - Removing items

## Project Features

- Catalog management
- Inventory tracking
- Order processing
- Discount application
- Receipt generation

## Class Structure

The main classes in the system are:

- `GroceryStoreSystem`: Main system class that coordinates all operations
- `Catalog`: Manages the store's product catalog
- `Inventory`: Tracks product stock levels
- `Checkout`: Handles the checkout process
- `Order`: Represents a customer order
- `DiscountCampaign`: Manages discount rules and calculations

## Notes

- The system uses BigDecimal for all monetary calculations to ensure precision
- Discounts can be applied based on various criteria (e.g., category-based)
- The system supports multiple discount strategies (e.g., percentage-based)
