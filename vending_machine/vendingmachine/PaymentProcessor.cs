namespace VendingMachineSystem;

public class PaymentProcessor {
    private decimal currentBalance = 0m;
    public void AddBalance(decimal amount){
        currentBalance = (currentBalance + amount);
    }
    public void Charge(decimal amount){
        currentBalance = (currentBalance - amount);
    }
    public decimal ReturnChange() {
        decimal change = currentBalance;
        currentBalance = 0m;
        return change;
    }

    // Getter and setters
    public decimal CurrentBalance => currentBalance;
}
