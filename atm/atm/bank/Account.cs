namespace Atm;

// Represents a bank account with balance, card details, and PIN security
public class Account {
    // Calculates MD5 hash of the PIN for secure storage
    private static byte[] CalculateMd5(string pinNumber) {
        try {
            return System.Security.Cryptography.MD5.HashData(Encoding.UTF8.GetBytes(pinNumber));
        } catch (PlatformNotSupportedException e) {
            throw new CryptographicException("MD5 algorithm not available in the current environment", e);
        }
    }
    private decimal balance;
    private readonly string accountNumber;
    private readonly string cardNumber;
    private readonly byte[] cardPinHash;
    private readonly AccountType accountType;

    // Creates a new account with initial zero balance and hashed PIN
    public Account(string accountNumber,
                   AccountType type,
                   string cardNumber,
                   string pin) {
        this.accountNumber = accountNumber;
        this.accountType = type;
        this.cardNumber = cardNumber;
        this.cardPinHash = CalculateMd5(pin);  // PIN is hashed for security
        this.balance = 0m;
    }

    // Validates the entered PIN against stored hash
    public bool ValidatePin(string pinNumber) {
        byte[] entryPinHash = CalculateMd5(pinNumber);
        return cardPinHash.AsSpan().SequenceEqual(entryPinHash);
    }

    // Updates account balance by adding the specified amount
    public void UpdateBalanceWithTransaction(decimal balanceChange) {
        this.balance = (this.balance + balanceChange);
    }

    // Returns current account balance
    public decimal Balance => balance;

    // Returns account number
    public string AccountNumber => accountNumber;

    // Returns associated card number
    public string CardNumber => cardNumber;

    // Returns account type (e.g., SAVING, CHECKING)
    public AccountType AccountType => accountType;


}
