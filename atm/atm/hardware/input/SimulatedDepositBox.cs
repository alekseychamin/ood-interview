namespace Atm;

public class SimulatedDepositBox : IDepositBox {
    // Simulates accepting cash deposit by notifying the ATM machine
    public void AcceptDeposit(decimal amount, ATMMachine atmMachine) {
        atmMachine.CollectDeposit(amount);
    }
}
