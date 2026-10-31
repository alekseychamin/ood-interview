namespace Atm;

public class TransactionSelectionState : ATMState {

    /**
     * Handles card ejection by returning to idle state and canceling transaction
     */
    public override void ProcessCardEjection(ATMMachine atmMachine) {
        atmMachine.Display.ShowMessage("Card ejected, transaction cancelled.");
        atmMachine.TransitionToState(new IdleState());
    }

    /**
     * Initiates withdrawal process by transitioning to amount entry state
     */
    public override void ProcessWithdrawalRequest(ATMMachine atmMachine) {
        atmMachine.Display.ShowMessage("Enter amount to withdraw:");
        atmMachine.TransitionToState(new WithdrawAmountEntryState());
    }

    /**
     * Initiates deposit process by transitioning to deposit collection state
     */
    public override void ProcessDepositRequest(ATMMachine atmMachine) {
        atmMachine.Display.ShowMessage("Please deposit cash into the deposit box.");
        atmMachine.TransitionToState(new DepositCollectionState());
    }
}
