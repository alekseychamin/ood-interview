namespace Atm;

// xUnit test ported from JUnit 5

// Test suite for ATM machine functionality including deposits, withdrawals, and error handling
public class ATMTest {
    [Fact]
    public void TestEndToEndDeposit() {
        Console.WriteLine("\n=== Testing End-to-End Deposit Flow ===");
        
        // Initialize bank
        Bank bank = new Bank();
        bank.AddAccount("123456", AccountType.Saving, "1111-2222-3333-4444", "1234");
        Console.WriteLine("✓ Bank initialized with account 123456 (PIN: 1234)");

        // Initialize simulated ATM components
        SimulatedCardProcessor cardProcessor = new SimulatedCardProcessor();
        SimulatedDepositBox depositBox = new SimulatedDepositBox();
        ConsoleDisplay display = new ConsoleDisplay();
        SimulatedKeyPad keypad = new SimulatedKeyPad();
        SimulatedCashDispenser cashDispenser = new SimulatedCashDispenser();

        ATMMachine atmMachine = new ATMMachine(bank, cardProcessor, depositBox, cashDispenser, keypad, display);
        Console.WriteLine("✓ ATM machine initialized with all components");

        // First check idle state;
        Assert.IsType<IdleState>(atmMachine.CurrentState);
        Console.WriteLine("✓ ATM is in IDLE state (ready to accept cards)");

        // Step 1: Insert card
        Console.WriteLine("\n--- Step 1: Inserting Card ---");
        cardProcessor.HandleCardInsertion("1111-2222-3333-4444", atmMachine);
        Assert.Equal("Please enter your PIN", display.DisplayedMessage);
        Console.WriteLine("✓ Card inserted successfully");
        Console.WriteLine("✓ ATM displays: '" + display.DisplayedMessage + "'");

        // Step 2: Enter PIN
        Console.WriteLine("\n--- Step 2: Entering PIN ---");
        keypad.HandlePinEntry("1234", atmMachine);
        Assert.Equal("PIN correct, select transaction type", display.DisplayedMessage);
        Console.WriteLine("✓ PIN entered: 1234");
        Console.WriteLine("✓ ATM displays: '" + display.DisplayedMessage + "'");

        // Step 3: Select deposit
        Console.WriteLine("\n--- Step 3: Selecting Deposit Transaction ---");
        keypad.HandleSelectTransaction(TransactionType.Deposit, atmMachine);
        Assert.Equal("Please deposit cash into the deposit box.", display.DisplayedMessage);
        Console.WriteLine("✓ Deposit transaction selected");
        Console.WriteLine("✓ ATM displays: '" + display.DisplayedMessage + "'");

        // Step 4: Simulate deposit
        Console.WriteLine("\n--- Step 4: Depositing Cash ---");
        depositBox.AcceptDeposit(200m, atmMachine);
        Assert.Equal("Deposit successful. Deposited amount: 200 to account: 123456", display.DisplayedMessage);
        Console.WriteLine("✓ Cash deposited: $200");
        Console.WriteLine("✓ ATM displays: '" + display.DisplayedMessage + "'");

        // Check if the ATM is in the transaction selection state
        Assert.IsType<TransactionSelectionState>(atmMachine.CurrentState);
        Console.WriteLine("✓ ATM returned to transaction selection state");

        // Step 5: Verify account
        Assert.Equal(200m, bank.GetAccountByAccountNumber("123456").Balance);
        Console.WriteLine("✓ Account balance verified: $200");
        Console.WriteLine("=== End-to-End Deposit Test Completed Successfully ===\n");
    }

    [Fact]
    public void TestMultipleDeposits() {
        Console.WriteLine("\n=== Testing Multiple Deposits ===");
        
        // Initialize bank
        Bank bank = new Bank();
        bank.AddAccount("123456", AccountType.Saving, "1111-2222-3333-4444", "1234");
        Console.WriteLine("✓ Bank initialized with account 123456 (PIN: 1234)");

        // Initialize simulated ATM components
        SimulatedCardProcessor cardProcessor = new SimulatedCardProcessor();
        SimulatedDepositBox depositBox = new SimulatedDepositBox();
        ConsoleDisplay display = new ConsoleDisplay();
        SimulatedKeyPad keypad = new SimulatedKeyPad();
        SimulatedCashDispenser cashDispenser = new SimulatedCashDispenser();

        ATMMachine atmMachine = new ATMMachine(bank, cardProcessor, depositBox, cashDispenser, keypad, display);
        Console.WriteLine("✓ ATM machine initialized");

        // First check idle state
        Assert.IsType<IdleState>(atmMachine.CurrentState);
        Console.WriteLine("✓ ATM is in IDLE state");

        // Step 1: Insert card
        Console.WriteLine("\n--- First Deposit Session ---");
        cardProcessor.HandleCardInsertion("1111-2222-3333-4444", atmMachine);
        Assert.Equal("Please enter your PIN", display.DisplayedMessage);
        Console.WriteLine("✓ Card inserted, PIN requested");

        // Step 2: Enter PIN
        keypad.HandlePinEntry("1234", atmMachine);
        Assert.Equal("PIN correct, select transaction type", display.DisplayedMessage);
        Console.WriteLine("✓ PIN verified, transaction menu displayed");

        // Step 3: Select deposit
        keypad.HandleSelectTransaction(TransactionType.Deposit, atmMachine);
        Assert.Equal("Please deposit cash into the deposit box.", display.DisplayedMessage);
        Console.WriteLine("✓ Deposit selected, waiting for cash");

        // Step 4: Simulate first deposit
        depositBox.AcceptDeposit(200m, atmMachine);
        Assert.Equal("Deposit successful. Deposited amount: 200 to account: 123456", display.DisplayedMessage);
        Console.WriteLine("✓ First deposit: $200 completed");

        // Step 5: Verify account balance after first deposit
        Assert.Equal(200m, bank.GetAccountByAccountNumber("123456").Balance);
        Console.WriteLine("✓ Account balance after first deposit: $200");

        // Step 6: From idle, select deposit again
        Console.WriteLine("\n--- Second Deposit Session ---");
        keypad.HandleSelectTransaction(TransactionType.Deposit, atmMachine);
        Assert.Equal("Please deposit cash into the deposit box.", display.DisplayedMessage);
        Console.WriteLine("✓ Second deposit selected, waiting for cash");

        // Step 7: Simulate second deposit
        depositBox.AcceptDeposit(300m, atmMachine);
        Assert.Equal("Deposit successful. Deposited amount: 300 to account: 123456", display.DisplayedMessage);
        Console.WriteLine("✓ Second deposit: $300 completed");

        // Step 8: Verify account balance after second deposit
        Assert.Equal(500m, bank.GetAccountByAccountNumber("123456").Balance);
        Console.WriteLine("✓ Final account balance: $500 (200 + 300)");
        Console.WriteLine("=== Multiple Deposits Test Completed Successfully ===\n");
    }

    [Fact]
    public void TestMultipleWithdrawals() {
        Console.WriteLine("\n=== Testing Multiple Withdrawals ===");
        
        // Initialize bank
        Bank bank = new Bank();
        bank.AddAccount("123456", AccountType.Saving, "1111-2222-3333-4444", "1234");
        bank.GetAccountByAccountNumber("123456").UpdateBalanceWithTransaction(500m);
        Console.WriteLine("✓ Bank initialized with account 123456 (PIN: 1234)");
        Console.WriteLine("✓ Account pre-loaded with $500");

        // Initialize simulated ATM components
        SimulatedCardProcessor cardProcessor = new SimulatedCardProcessor();
        SimulatedDepositBox depositBox = new SimulatedDepositBox();
        ConsoleDisplay display = new ConsoleDisplay();
        SimulatedKeyPad keypad = new SimulatedKeyPad();
        SimulatedCashDispenser cashDispenser = new SimulatedCashDispenser();

        ATMMachine atmMachine = new ATMMachine(bank, cardProcessor, depositBox, cashDispenser, keypad, display);
        Console.WriteLine("✓ ATM machine initialized");

        // First check idle state
        Assert.IsType<IdleState>(atmMachine.CurrentState);
        Console.WriteLine("✓ ATM is in IDLE state");

        // Step 1: Insert card
        Console.WriteLine("\n--- First Withdrawal Session ---");
        cardProcessor.HandleCardInsertion("1111-2222-3333-4444", atmMachine);
        Assert.Equal("Please enter your PIN", display.DisplayedMessage);
        Console.WriteLine("✓ Card inserted, PIN requested");

        // Step 2: Enter PIN
        keypad.HandlePinEntry("1234", atmMachine);
        Assert.Equal("PIN correct, select transaction type", display.DisplayedMessage);
        Console.WriteLine("✓ PIN verified, transaction menu displayed");

        // Step 3: Select withdraw
        keypad.HandleSelectTransaction(TransactionType.Withdraw, atmMachine);
        Assert.Equal("Enter amount to withdraw:", display.DisplayedMessage);
        Console.WriteLine("✓ Withdrawal selected, amount requested");

        // Step 4: Simulate first withdrawal
        keypad.HandleAmountEntry(200m, atmMachine);
        Assert.Equal("Please take your cash.", display.DisplayedMessage);
        Console.WriteLine("✓ First withdrawal: $200 dispensed");

        // Step 5: Verify account balance after first withdrawal
        Assert.Equal(300m, bank.GetAccountByAccountNumber("123456").Balance);
        Console.WriteLine("✓ Account balance after first withdrawal: $300 (500 - 200)");

        // Step 6: Select withdraw again
        Console.WriteLine("\n--- Second Withdrawal Session ---");
        keypad.HandleSelectTransaction(TransactionType.Withdraw, atmMachine);
        Assert.Equal("Enter amount to withdraw:", display.DisplayedMessage);
        Console.WriteLine("✓ Second withdrawal selected, amount requested");

        // Step 7: Simulate second withdrawal
        keypad.HandleAmountEntry(100m, atmMachine);
        Assert.Equal("Please take your cash.", display.DisplayedMessage);
        Console.WriteLine("✓ Second withdrawal: $100 dispensed");

        // Step 8: Verify account balance after second withdrawal
        Assert.Equal(200m, bank.GetAccountByAccountNumber("123456").Balance);
        Console.WriteLine("✓ Account balance after second withdrawal: $200 (300 - 100)");

        // Step 9: Attempt withdrawal exceeding balance
        Console.WriteLine("\n--- Attempting Excessive Withdrawal ---");
        keypad.HandleSelectTransaction(TransactionType.Withdraw, atmMachine);
        Assert.Equal("Enter amount to withdraw:", display.DisplayedMessage);
        keypad.HandleAmountEntry(300m, atmMachine);
        Assert.Equal("Insufficient funds, please try again.", display.DisplayedMessage);
        Console.WriteLine("✓ Attempted to withdraw $300 (exceeds balance of $200)");
        Console.WriteLine("✓ ATM correctly rejected: 'Insufficient funds'");

        // Step 10: Verify account balance remains unchanged
        Assert.Equal(200m, bank.GetAccountByAccountNumber("123456").Balance);
        Console.WriteLine("✓ Account balance unchanged: $200 (no funds deducted)");
        Console.WriteLine("=== Multiple Withdrawals Test Completed Successfully ===\n");
    }

    [Fact]
    public void TestInvalidCardInsertion() {
        Console.WriteLine("\n=== Testing Invalid Card Insertion ===");
        
        // Initialize bank
        Bank bank = new Bank();
        Console.WriteLine("✓ Bank initialized (no accounts registered)");

        // Initialize simulated ATM components
        SimulatedCardProcessor cardProcessor = new SimulatedCardProcessor();
        SimulatedDepositBox depositBox = new SimulatedDepositBox();
        ConsoleDisplay display = new ConsoleDisplay();
        SimulatedKeyPad keypad = new SimulatedKeyPad();
        SimulatedCashDispenser cashDispenser = new SimulatedCashDispenser();

        ATMMachine atmMachine = new ATMMachine(bank, cardProcessor, depositBox, cashDispenser, keypad, display);
        Console.WriteLine("✓ ATM machine initialized");

        // First check idle state
        Assert.IsType<IdleState>(atmMachine.CurrentState);
        Console.WriteLine("✓ ATM is in IDLE state");

        // Attempt to insert an invalid card
        Console.WriteLine("\n--- Attempting Invalid Card Insertion ---");
        cardProcessor.HandleCardInsertion("9999-8888-7777-6666", atmMachine);
        Assert.Equal("Invalid card. Please try again.", display.DisplayedMessage);
        Console.WriteLine("✓ Invalid card inserted: 9999-8888-7777-6666");
        Console.WriteLine("✓ ATM correctly rejected: 'Invalid card. Please try again.'");

        // Verify state remains IdleState
        Assert.IsType<IdleState>(atmMachine.CurrentState);
        Console.WriteLine("✓ ATM remains in IDLE state (ready for valid card)");
        Console.WriteLine("=== Invalid Card Test Completed Successfully ===\n");
    }

    [Fact]
    public void TestInvalidPinEntry() {
        Console.WriteLine("\n=== Testing Invalid PIN Entry ===");
        
        // Initialize bank
        Bank bank = new Bank();
        bank.AddAccount("123456", AccountType.Saving, "1111-2222-3333-4444", "1234");
        Console.WriteLine("✓ Bank initialized with account 123456 (PIN: 1234)");

        // Initialize simulated ATM components
        SimulatedCardProcessor cardProcessor = new SimulatedCardProcessor();
        SimulatedDepositBox depositBox = new SimulatedDepositBox();
        ConsoleDisplay display = new ConsoleDisplay();
        SimulatedKeyPad keypad = new SimulatedKeyPad();
        SimulatedCashDispenser cashDispenser = new SimulatedCashDispenser();

        ATMMachine atmMachine = new ATMMachine(bank, cardProcessor, depositBox, cashDispenser, keypad, display);
        Console.WriteLine("✓ ATM machine initialized");

        // Insert valid card
        Console.WriteLine("\n--- Inserting Valid Card ---");
        cardProcessor.HandleCardInsertion("1111-2222-3333-4444", atmMachine);
        Assert.Equal("Please enter your PIN", display.DisplayedMessage);
        Console.WriteLine("✓ Valid card inserted: 1111-2222-3333-4444");
        Console.WriteLine("✓ ATM requests PIN entry");

        // Enter invalid PIN
        Console.WriteLine("\n--- Entering Invalid PIN ---");
        keypad.HandlePinEntry("0000", atmMachine);
        Assert.Equal("Invalid PIN. Please try again", display.DisplayedMessage);
        Console.WriteLine("✓ Invalid PIN entered: 0000 (correct PIN is 1234)");
        Console.WriteLine("✓ ATM correctly rejected: 'Invalid PIN. Please try again'");

        // Verify state remains PinEntryState
        Assert.IsType<PinEntryState>(atmMachine.CurrentState);
        Console.WriteLine("✓ ATM remains in PIN entry state (allows retry)");
        Console.WriteLine("=== Invalid PIN Test Completed Successfully ===\n");
    }

    [Fact]
    public void TestWithdrawWithoutSufficientFunds() {
        Console.WriteLine("\n=== Testing Withdrawal Without Sufficient Funds ===");
        
        // Initialize bank
        Bank bank = new Bank();
        bank.AddAccount("123456", AccountType.Saving, "1111-2222-3333-4444", "1234");
        bank.GetAccountByAccountNumber("123456").UpdateBalanceWithTransaction(100m);
        Console.WriteLine("✓ Bank initialized with account 123456 (PIN: 1234)");
        Console.WriteLine("✓ Account balance: $100");

        // Initialize simulated ATM components
        SimulatedCardProcessor cardProcessor = new SimulatedCardProcessor();
        SimulatedDepositBox depositBox = new SimulatedDepositBox();
        ConsoleDisplay display = new ConsoleDisplay();
        SimulatedKeyPad keypad = new SimulatedKeyPad();
        SimulatedCashDispenser cashDispenser = new SimulatedCashDispenser();

        ATMMachine atmMachine = new ATMMachine(bank, cardProcessor, depositBox, cashDispenser, keypad, display);
        Console.WriteLine("✓ ATM machine initialized");

        // Insert valid card
        Console.WriteLine("\n--- Starting Withdrawal Process ---");
        cardProcessor.HandleCardInsertion("1111-2222-3333-4444", atmMachine);
        Assert.Equal("Please enter your PIN", display.DisplayedMessage);
        Console.WriteLine("✓ Card inserted, PIN requested");

        // Enter valid PIN
        keypad.HandlePinEntry("1234", atmMachine);
        Assert.Equal("PIN correct, select transaction type", display.DisplayedMessage);
        Console.WriteLine("✓ PIN verified, transaction menu displayed");

        // Select withdraw
        keypad.HandleSelectTransaction(TransactionType.Withdraw, atmMachine);
        Assert.Equal("Enter amount to withdraw:", display.DisplayedMessage);
        Console.WriteLine("✓ Withdrawal selected, amount requested");

        // Attempt to withdraw more than balance
        Console.WriteLine("\n--- Attempting Excessive Withdrawal ---");
        keypad.HandleAmountEntry(200m, atmMachine);
        Assert.Equal("Insufficient funds, please try again.", display.DisplayedMessage);
        Console.WriteLine("✓ Attempted to withdraw $200 (exceeds balance of $100)");
        Console.WriteLine("✓ ATM correctly rejected: 'Insufficient funds, please try again.'");

        // Verify state remains TransactionSelectionState
        Assert.IsType<TransactionSelectionState>(atmMachine.CurrentState);
        Console.WriteLine("✓ ATM returned to transaction selection state (allows other transactions)");
        Console.WriteLine("=== Insufficient Funds Test Completed Successfully ===\n");
    }

    [Fact]
    public void TestEjectCardDuringTransaction() {
        Console.WriteLine("\n=== Testing Card Ejection During Transaction ===");
        
        // Initialize bank
        Bank bank = new Bank();
        bank.AddAccount("123456", AccountType.Saving, "1111-2222-3333-4444", "1234");
        Console.WriteLine("✓ Bank initialized with account 123456 (PIN: 1234)");

        // Initialize simulated ATM components
        SimulatedCardProcessor cardProcessor = new SimulatedCardProcessor();
        SimulatedDepositBox depositBox = new SimulatedDepositBox();
        ConsoleDisplay display = new ConsoleDisplay();
        SimulatedKeyPad keypad = new SimulatedKeyPad();
        SimulatedCashDispenser cashDispenser = new SimulatedCashDispenser();

        ATMMachine atmMachine = new ATMMachine(bank, cardProcessor, depositBox, cashDispenser, keypad, display);
        Console.WriteLine("✓ ATM machine initialized");

        // Insert valid card
        Console.WriteLine("\n--- Starting Transaction Process ---");
        cardProcessor.HandleCardInsertion("1111-2222-3333-4444", atmMachine);
        Assert.Equal("Please enter your PIN", display.DisplayedMessage);
        Console.WriteLine("✓ Card inserted, PIN requested");

        // Enter valid PIN
        keypad.HandlePinEntry("1234", atmMachine);
        Assert.Equal("PIN correct, select transaction type", display.DisplayedMessage);
        Console.WriteLine("✓ PIN verified, transaction menu displayed");

        // Select deposit
        keypad.HandleSelectTransaction(TransactionType.Deposit, atmMachine);
        Assert.Equal("Please deposit cash into the deposit box.", display.DisplayedMessage);
        Console.WriteLine("✓ Deposit selected, waiting for cash");

        // Eject card during transaction
        Console.WriteLine("\n--- Ejecting Card During Transaction ---");
        cardProcessor.HandleCardEjection(atmMachine);
        Assert.Equal("Transaction cancelled, card ejected", display.DisplayedMessage);
        Console.WriteLine("✓ Card ejected during active transaction");
        Console.WriteLine("✓ ATM displays: 'Transaction cancelled, card ejected'");

        // Verify state transitions back to IdleState
        Assert.IsType<IdleState>(atmMachine.CurrentState);
        Console.WriteLine("✓ ATM returned to IDLE state (ready for new card)");
        Console.WriteLine("=== Card Ejection Test Completed Successfully ===\n");
    }
}
