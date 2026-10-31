# Amazon Locker System

This project is an object-oriented design and implementation of an Amazon Locker system in C# (.NET 10). It includes core classes for lockers, packages, accounts, and a xUnit test suite.

## Prerequisites


- .NET SDK 10.0 (C# 14)
- xUnit (restored automatically by `dotnet restore`)

## Project Structure

```
shippinglocker/
  account/         # Account-related classes
  locker/          # Locker-related classes
  pkg/             # Package-related classes
  ShippingLockerTest.cs   # xUnit test class
  Site.cs
  INotification.cs
  EmailNotification.cs
```

## Running the Tests

```bash
# From repository root
dotnet test shipping_locker/ShippingLocker.csproj
```

## Notes

- Built and tested with the .NET SDK (`dotnet test`).
- New test files are picked up automatically by `dotnet test`.
- The test output will be shown in the terminal.
