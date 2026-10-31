namespace Atm;

// Interface for handling cash deposits into the ATM
public interface IDepositBox {
    // Accepts cash deposit and notifies ATM of the deposited amount
    void AcceptDeposit(decimal amount, ATMMachine machine);
}
