namespace Atm;

public class PinEntryState : ATMState {
    /**
     * If the user instead ejects the card, the ATM will release the card and go back to Idle State.
     */
    public override void ProcessCardEjection(ATMMachine atmMachine) {
        atmMachine.Display.ShowMessage("Card ejected");
        atmMachine.TransitionToState(new IdleState());
    }

    /**
     * If the user enters a valid PIN, the ATM will transition to TransactionSelectionState.
     * Otherwise, it will stay in this state.
     */
    public override void ProcessPinEntry(ATMMachine atmMachine, string pin) {
        string cardNumber = atmMachine.CardProcessor.CardNumber;

        bool isPinCorrect = atmMachine.BankInterface.CheckPin(cardNumber, pin);

        if (isPinCorrect) {
            atmMachine.Display.ShowMessage("PIN correct, select transaction type");
            atmMachine.TransitionToState(new TransactionSelectionState());
        } else {
            atmMachine.Display.ShowMessage("Invalid PIN. Please try again");
        }
    }
}
