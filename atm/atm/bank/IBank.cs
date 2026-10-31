namespace Atm;

// Defines the contract for bank operations that must be implemented by any bank implementation
public interface IBank {
    void AddAccount(string accountNumber, AccountType type, string cardNumber, string pin);
    bool ValidateCard(string cardNumber);
    bool CheckPin(string cardNumber, string pinNumber);
    Account GetAccountByAccountNumber(string accountNumber);
    Account GetAccountByCard(string cardNumber);

    bool WithdrawFunds(Account account, decimal amount);
}
