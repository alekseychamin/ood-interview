namespace Atm;

public class DepositCollectionState : ATMState {
    // Handles card ejection by canceling transaction and returning to idle state
    public override void ProcessCardEjection(ATMMachine atmMachine) {
        atmMachine.Display.ShowMessage("Transaction cancelled, card ejected");
        atmMachine.TransitionToState(new IdleState());
    }

    /**
     * Processes deposit by updating account balance and returning to transaction selection
     */
    public override void ProcessDepositCollection(ATMMachine atmMachine, decimal amount) {
        string cardNumber = atmMachine.CardProcessor.CardNumber;
        Account account = atmMachine.BankInterface.GetAccountByCard(cardNumber);
        DepositTransaction transaction = new DepositTransaction(account, amount);
        transaction.ExecuteTransaction();
        atmMachine.Display.ShowMessage(
                        string.Format("Deposit successful. Deposited amount: {0} to account: {1}",
                                amount,
                                account.AccountNumber));

        atmMachine.TransitionToState(new TransactionSelectionState());
    }
}
