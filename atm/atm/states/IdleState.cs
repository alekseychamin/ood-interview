namespace Atm;

public class IdleState : ATMState {
    /**
     * This method is called when a card is inserted into the ATM.
     * This transitions the ATM to the PinEntryState if the card is valid.
     */
    public override void ProcessCardInsertion(ATMMachine atmMachine, string cardNumber) {
        if (atmMachine.BankInterface.ValidateCard(cardNumber)) {
            atmMachine.Display.ShowMessage("Please enter your PIN");
            atmMachine.TransitionToState(new PinEntryState());
        } else {
            atmMachine.Display.ShowMessage("Invalid card. Please try again.");
        }
    }
}
