namespace Atm;

public class SimulatedCardProcessor : ICardProcessor {
    // Stores the currently inserted card number
    private string cardNumber;

    // Simulates card insertion by storing card number and notifying ATM
    public void HandleCardInsertion(string cardNumber, ATMMachine atmMachine) {
        this.cardNumber = cardNumber;
        atmMachine.InsertCard(cardNumber);
    }

    // Simulates card ejection by clearing stored card number and notifying ATM
    public void HandleCardEjection(ATMMachine atmMachine) {
        this.cardNumber = null;
        atmMachine.EjectCard();
    }

    // Returns the currently stored card number
    public string CardNumber => cardNumber;
}
