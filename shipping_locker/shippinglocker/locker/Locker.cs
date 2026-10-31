namespace ShippingLocker;

// Represents a physical locker that can store packages
public class Locker {
    // Size of the locker
    private readonly LockerSize size;
    // Currently stored package
    private IShippingPackage currentPackage;
    // Date when the current package was assigned
    private DateTime? assignmentDate;
    // Access code for retrieving the package
    private string accessCode;

    // Creates a new locker of the specified size
    public Locker(LockerSize size) {
        this.size = size;
    }

    // Assigns a package to this locker and generates an access code
    public void AssignPackage(IShippingPackage pkg, DateTime date) {
        this.currentPackage = pkg;
        this.assignmentDate = date;
        this.accessCode = GenerateAccessCode();
    }

    // Releases the locker by removing the current package and its details
    public void ReleaseLocker() {
        this.currentPackage = null;
        this.assignmentDate = null;
        this.accessCode = null;
    }

    // Calculates storage charges based on usage duration and policy
    public decimal CalculateStorageCharges() {
        if (currentPackage == null || assignmentDate == null) {
            return 0m;
        }
        
        AccountLockerPolicy policy = currentPackage.User.LockerPolicy;
        long totalDaysUsed = (long)(DateTime.Now - assignmentDate.Value).TotalDays;
        
        // Check if exceeds maximum period
        if (totalDaysUsed > policy.MaximumPeriodDays) {
            currentPackage.UpdateShippingStatus(ShippingStatus.Expired);
            throw new MaximumStoragePeriodExceededException(
                "Package has exceeded maximum allowed storage period of " + policy.MaximumPeriodDays + " days");
        }
        
        // Calculate chargeable days (excluding free period)
        long chargeableDays = Math.Max(0, totalDaysUsed - policy.FreePeriodDays);
        return (size.DailyCharge * chargeableDays);
    }

    // Checks if the locker is available for new packages
    public bool IsAvailable => currentPackage == null;

    // Verifies if the provided access code matches the locker's code
    public bool CheckAccessCode(string code) {
        return this.accessCode != null && accessCode.Equals(code);
    }

    // Generates a random 6-digit access code
    private string GenerateAccessCode() {
        int accessCode = 100000 + Random.Shared.Next(900000);
        return accessCode.ToString();
    }

    // Returns the current access code
    public string AccessCode => accessCode;

    // Returns the size of this locker
    public LockerSize Size => this.size;

    // Returns the currently stored package
    public IShippingPackage Package => currentPackage;

    // Sets the current package
    public void SetPackage(IShippingPackage pkg) {
        this.currentPackage = pkg;
    }

    // getter and setter methods are omitted for brevity
}
