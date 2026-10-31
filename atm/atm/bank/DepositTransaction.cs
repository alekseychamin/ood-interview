namespace Atm;

// Handles the deposit transaction process for adding funds to an account
public class DepositTransaction : ITransaction {
    internal Account account;
    internal decimal amount;

    // Returns the transaction type as DEPOSIT
    public TransactionType Type => TransactionType.Deposit;

    // Deposit transactions are always valid
    public bool ValidateTransaction() {
        return true;
    }

    public DepositTransaction(Account account, decimal amount) {
        this.account = account;
        this.amount = amount;
    }

    // Executes the deposit by adding the amount to the account balance
    public void ExecuteTransaction() {
        account.UpdateBalanceWithTransaction(amount);
    }
}
