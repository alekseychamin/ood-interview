namespace Atm;

// Base interface for all types of bank transactions with common operations
public interface ITransaction {
    TransactionType Type { get; }

    bool ValidateTransaction();

    void ExecuteTransaction();
}
