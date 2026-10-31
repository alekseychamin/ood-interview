# ATM System

A C#-based ATM (Automated Teller Machine) system that simulates basic banking operations like deposits, withdrawals, and PIN validation.

## Project Structure

```
atm/
├── ATMMachine.cs         # Main ATM machine class
├── ATMTest.cs            # Test suite for ATM functionality
├── bank/                   # Banking system components
│   ├── Account.cs
│   ├── Bank.cs
│   ├── IBank.cs
│   ├── ITransaction.cs
│   └── enums/
│       ├── AccountType.cs
│       └── TransactionType.cs
├── hardware/              # Hardware component interfaces and simulations
│   ├── input/
│   │   ├── ICardProcessor.cs
│   │   ├── IDepositBox.cs
│   │   ├── IKeypad.cs
│   │   └── simulated implementations
│   └── output/
│       ├── ICashDispenser.cs
│       ├── IDisplay.cs
│       └── simulated implementations
└── states/               # State pattern implementation
    ├── ATMState.cs
    ├── IdleState.cs
    ├── PinEntryState.cs
    └── other state classes
```

## Prerequisites


- .NET SDK 10.0 (C# 14)
- xUnit (restored automatically by `dotnet restore`)

## Running the Tests

```bash
# From repository root
dotnet test atm/Atm.csproj
```

## Test Cases

The test suite includes the following test cases:

1. `TestEndToEndDeposit()`: Tests a complete deposit transaction
2. `TestMultipleDeposits()`: Tests multiple deposit transactions
3. `TestMultipleWithdrawals()`: Tests multiple withdrawal transactions
4. `TestInvalidCardInsertion()`: Tests handling of invalid card insertion
5. `TestInvalidPinEntry()`: Tests handling of invalid PIN entry
6. `TestWithdrawWithoutSufficientFunds()`: Tests withdrawal with insufficient funds
7. `TestEjectCardDuringTransaction()`: Tests card ejection during a transaction

## Notes

- The project uses simulated hardware components for testing
- All monetary values are handled using BigDecimal for precision
- PINs are stored as MD5 hashes for security
- The system supports both checking and savings accounts
