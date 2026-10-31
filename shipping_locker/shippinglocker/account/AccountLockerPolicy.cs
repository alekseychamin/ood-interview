namespace ShippingLocker;

// Defines the policy for locker usage for an account
public class AccountLockerPolicy {
    // Number of days of free storage
    internal int freePeriodDays;
    // Maximum number of days a package can be stored
    internal int maximumPeriodDays;

    // Creates a new locker policy with specified free and maximum periods
    public AccountLockerPolicy(int freePeriodDays, int maximumPeriodDays) {
        this.freePeriodDays = freePeriodDays;
        this.maximumPeriodDays = maximumPeriodDays;
    }

    // Returns the number of free storage days
    public int FreePeriodDays => freePeriodDays;

    // Returns the maximum allowed storage period in days
    public int MaximumPeriodDays => maximumPeriodDays;
}
