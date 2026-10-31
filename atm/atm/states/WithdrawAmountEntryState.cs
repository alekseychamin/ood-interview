namespace Atm;

public class WithdrawAmountEntryState : ATMState {
    // Handles card ejection by canceling transaction and returning to idle state
    public override void ProcessCardEjection(ATMMachine atmMachine) {
        atmMachine.Display.ShowMessage("Transaction cancelled, card ejected");
        atmMachine.TransitionToState(new IdleState());
    }

    // Processes withdrawal request by checking balance and dispensing cash if sufficient funds
    public override void ProcessAmountEntry(ATMMachine atmMachine, decimal amount) {
        string cardNumber = atmMachine.CardProcessor.CardNumber;
        Account account = atmMachine.BankInterface.GetAccountByCard(cardNumber);
        bool isSuccess = atmMachine.BankInterface.WithdrawFunds(account, amount);

        if (isSuccess) {
            atmMachine.CashDispenser.DispenseCash(amount);
            atmMachine.Display.ShowMessage("Please take your cash.");
        } else {
            atmMachine.Display.ShowMessage("Insufficient funds, please try again.");
        }
        atmMachine.TransitionToState(new TransactionSelectionState());
    }
}
