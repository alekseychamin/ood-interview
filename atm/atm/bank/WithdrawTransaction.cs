namespace Atm;

// Handles the withdrawal transaction process for removing funds from an account
public class WithdrawTransaction : ITransaction {
    internal Account account;
    internal decimal amount;

    // Returns the transaction type as WITHDRAW
    public TransactionType Type => TransactionType.Withdraw;

    // Validates if the account has sufficient funds for withdrawal
    public bool ValidateTransaction() {
        System.Diagnostics.Debug.Assert(account != null);
        return account.Balance > amount;
    }

    // Creates a new withdrawal transaction, throws exception if validation fails
    public WithdrawTransaction(Account account, decimal amount) {
        // Fields are assigned before validation: the Java original validated first,
        // which dereferences a null account.
        this.account = account;
        this.amount = amount;
        if (!ValidateTransaction()) {
            throw new InvalidOperationException("Cannot complete withdrawal: Insufficient funds in account");
        }
    }

    // Executes the withdrawal by subtracting the amount from account balance
    public void ExecuteTransaction() {
        account.UpdateBalanceWithTransaction((-amount));
    }
}
