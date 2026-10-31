namespace ShippingLocker;

// Represents a user account in the locker system
public class Account {
    // Unique identifier for the account
    private readonly string accountId;
    // Name of the account owner
    private readonly string ownerName;
    // Policy defining locker usage rules for this account
    private readonly AccountLockerPolicy lockerPolicy;
    // Total charges accumulated for locker usage
    private decimal usageCharges = 0.00m;

    // Creates a new account with specified details and policy
    public Account(string accountId, string ownerName, AccountLockerPolicy lockerPolicy) {
        this.accountId = accountId;
        this.ownerName = ownerName;
        this.lockerPolicy = lockerPolicy;
    }

    // Returns the name of the account owner
    public string OwnerName => ownerName;

    // Returns the locker policy associated with this account
    public AccountLockerPolicy LockerPolicy => lockerPolicy;

    // Returns the unique identifier of this account
    public string AccountId => accountId;

    // Adds a charge to the account's total usage charges
    public void AddUsageCharge(decimal amount) {
        usageCharges = (usageCharges + amount);
    }

    // Returns the total usage charges for this account
    public decimal UsageCharges => usageCharges;
}
