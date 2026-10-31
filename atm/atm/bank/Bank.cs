namespace Atm;

// Manages bank accounts and provides banking operations like validation and transactions
public class Bank : IBank {
    private readonly Dictionary<string, Account> accounts = new();
    private readonly Dictionary<string, Account> accountByCard = new();

    // Creates a new account and stores it in both account and card maps
    public void AddAccount(string accountNumber,
                           AccountType type,
                           string cardNumber,
                           string pin) {
        Account newAccount = new Account(accountNumber, type, cardNumber, pin);
        accounts[newAccount.AccountNumber] = newAccount;
        accountByCard[newAccount.CardNumber] = newAccount;
    }

    // Checks if a card number exists in the bank's records
    public bool ValidateCard(string cardNumber) {
        return GetAccountByCard(cardNumber) != null;
    }

    // Verifies if the provided PIN matches the card's stored PIN
    public bool CheckPin(string cardNumber, string pinNumber) {
        Account account = GetAccountByCard(cardNumber);
        if (account != null) {
            return account.ValidatePin(pinNumber);
        }
        return false;
    }

    // Retrieves account by account number
    public Account GetAccountByAccountNumber(string accountNumber) {
        return accounts.GetValueOrDefault(accountNumber);
    }

    // Retrieves account by card number
    public Account GetAccountByCard(string cardNumber) {
        return accountByCard.GetValueOrDefault(cardNumber);
    }

    // Attempts to withdraw specified amount from account if sufficient funds exist
    public bool WithdrawFunds(Account account, decimal amount) {
        if (account.Balance >= amount) {
            account.UpdateBalanceWithTransaction((-amount));
            return true;
        }
        return false;
    }
}
