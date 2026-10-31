# Object-Oriented Design Examples — C# / .NET 10

Companion code for *Object-Oriented Design Interview* (ByteByteGo), ported from the
original Java (branch `main`) to **C# 14 / .NET 10**.

## Quick start

```bash
git clone -b dotnet10 https://github.com/alekseychamin/ood-interview.git
cd ood-interview

dotnet build OodInterview.slnx          # build everything
dotnet test  OodInterview.slnx          # run all tests
dotnet test  parking_lot/ParkingLot.csproj   # one project
```

Requirements: **.NET SDK 10.0** (`dotnet --version` ≥ 10.0.100).

## Projects

| System | Project | Namespace |
|---|---|---|
| ATM | `atm/Atm.csproj` | `Atm` |
| Blackjack | `blackjack/BlackJack.csproj` | `BlackJack` |
| Elevator | `elevator_system/Elevator.csproj` | `Elevator` |
| Unix file search | `file_search/FileSearch.csproj` | `FileSearchSystem` |
| Grocery store | `grocery_store/GroceryStore.csproj` | `GroceryStore` |
| Movie tickets | `movie_ticket/MovieTicket.csproj` | `MovieTicket` |
| Parking lot | `parking_lot/ParkingLot.csproj` | `ParkingLotSystem` |
| Restaurant | `restaurant/Restaurant.csproj` | `RestaurantSystem` |
| Shipping locker | `shipping_locker/ShippingLocker.csproj` | `ShippingLocker` |
| Tic-tac-toe | `tic_tac_toe/TicTacToe.csproj` | `TicTacToe` |
| Vending machine | `vending_machine/VendingMachine.csproj` | `VendingMachineSystem` |

The folder layout matches the Java version, so a `.cs` file sits where its `.java`
counterpart was. Each project contains the code and its xUnit tests.
`*_deep_dive` folders hold the "deep dive" snippets from the book; like in the
Java version, some of them are fragments and they are excluded from compilation.

## Java → C# conventions used

| Java | C# |
|---|---|
| `getX()` / `isX()` getters | properties `X` / `IsX` |
| `camelCase()` methods | `PascalCase()` methods |
| interface `FareStrategy` | interface `IFareStrategy` (`BankInterface` → `IBank`) |
| `ENUM_CONSTANT` | `EnumConstant` |
| enum with fields (`Rank`, `LockerSize`) | plain enum + C# 14 extension properties |
| `BigDecimal` | `decimal` |
| `LocalDateTime` / `Duration` | `DateTime` / `TimeSpan` |
| `Map` / `HashMap` / `TreeMap` | `Dictionary` / `SortedDictionary` |
| `Set` / `List` / `Deque` | `HashSet` / `List` / `Stack` |
| Streams | LINQ |
| `Optional<T>` | nullable reference (`null` = empty) |
| `synchronized` | `lock` |
| package-private | `internal` |
| JUnit 5 | xUnit |

Namespaces get a `System` suffix where the Java package name equals a class name
(`ParkingLotSystem.ParkingLot`, `RestaurantSystem.Restaurant`, ...), because C#
does not allow a type with the same name as its enclosing namespace to be used comfortably.

## CI

`.github/workflows/dotnet.yml` builds the solution and runs all tests on every push to `dotnet10`.
