namespace Atm;

// Interface for keypad hardware component
public interface IKeypad {
    // Handles PIN entry from user
    void HandlePinEntry(string pin, ATMMachine machine);

    // Handles amount entry from user
    void HandleAmountEntry(decimal amount, ATMMachine machine);

    // Handles transaction type selection from user
    void HandleSelectTransaction(TransactionType transactionType, ATMMachine atmMachine);
}
