namespace Atm;

public class SimulatedKeyPad : IKeypad {
    // Simulates PIN entry by forwarding the input to ATM machine
    public void HandlePinEntry(string pin, ATMMachine atmMachine) {
        atmMachine.EnterPin(pin);
    }

    // Simulates amount entry by forwarding the input to ATM machine
    public void HandleAmountEntry(decimal amount, ATMMachine atmMachine) {
        atmMachine.EnterAmount(amount);
    }

    // Simulates transaction selection by forwarding the choice to ATM machine
    public void HandleSelectTransaction(TransactionType transactionType, ATMMachine atmMachine) {
        switch (transactionType) {
            case TransactionType.Withdraw:
                atmMachine.WithdrawRequest();
                break;
            case TransactionType.Deposit:
                atmMachine.DepositRequest();
                break;
            default:
                throw new ArgumentException("Invalid transaction type: " + transactionType);
        }
    }
}
