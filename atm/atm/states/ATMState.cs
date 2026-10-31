namespace Atm;

/**
 * ATMState is an abstract class that defines the state of the ATM.
 * This abstract class contains the default behavior for each state, which usually
 * renders a message to the display and does not perform any action.
 */
public class ATMState {
    // Displays an invalid action message on the ATM screen
    private static void RenderDefaultAction(ATMMachine atmMachine) {
        atmMachine.Display.ShowMessage("Invalid action, please try again.");
    }

    // Default implementation for card insertion
    public virtual void ProcessCardInsertion(ATMMachine atmMachine, string cardNumber) {
        RenderDefaultAction(atmMachine);
    }

    // Default implementation for card ejection
    public virtual void ProcessCardEjection(ATMMachine atmMachine) {
        RenderDefaultAction(atmMachine);
    }

    // Default implementation for PIN entry
    public virtual void ProcessPinEntry(ATMMachine atmMachine, string pin) {
        RenderDefaultAction(atmMachine);
    }

    // Default implementation for withdrawal request
    public virtual void ProcessWithdrawalRequest(ATMMachine atmMachine) {
        RenderDefaultAction(atmMachine);
    }

    // Default implementation for deposit request
    public virtual void ProcessDepositRequest(ATMMachine atmMachine){
        RenderDefaultAction(atmMachine);
    }

    // Default implementation for amount entry
    public virtual void ProcessAmountEntry(ATMMachine atmMachine, decimal amount) {
        RenderDefaultAction(atmMachine);
    }

    // Default implementation for deposit collection
    public virtual void ProcessDepositCollection(ATMMachine atmMachine, decimal amount) {
        RenderDefaultAction(atmMachine);
    }
}
