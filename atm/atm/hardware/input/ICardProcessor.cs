namespace Atm;

// Interface for card processor hardware component
public interface ICardProcessor {
    // Handles card insertion by storing card number and notifying ATM
    void HandleCardInsertion(string cardNumber, ATMMachine atmMachine);

    // Handles card ejection by clearing stored card number and notifying ATM
    void HandleCardEjection(ATMMachine atmMachine);

    // Returns the currently stored card number
    string CardNumber { get; }
}
