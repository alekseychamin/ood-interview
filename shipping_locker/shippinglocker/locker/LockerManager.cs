namespace ShippingLocker;

// Manages the operations of lockers at a site
public class LockerManager {
    // The site being managed
    private readonly Site site;
    // Service for sending notifications
    private readonly INotification notificationService;
    // Map of account IDs to account objects
    private readonly Dictionary<string, Account> accounts;
    // Map of access codes to lockers
    private readonly Dictionary<string, Locker> accessCodeMap = new();

    // Creates a new locker manager for a site
    public LockerManager(Site site, Dictionary<string, Account> accounts, INotification notificationService) {
        this.site = site;
        this.accounts = accounts;
        this.notificationService = notificationService;
    }

    // Assigns a package to an available locker
    public Locker AssignPackage(IShippingPackage pkg, DateTime date) {
        Locker locker = site.PlacePackage(pkg, date);
        if (locker != null) {
            accessCodeMap[locker.AccessCode] = locker;
            notificationService.SendNotification("Package assigned to locker" + locker.AccessCode, pkg.User);
        }
        return locker;
    }

    // Processes package pickup using an access code
    public Locker PickUpPackage(string accessCode) {
        Locker locker = accessCodeMap.GetValueOrDefault(accessCode);
        if (locker != null && locker.CheckAccessCode(accessCode)) {
            try {
                decimal charge = locker.CalculateStorageCharges();
                IShippingPackage pkg = locker.Package;
                locker.ReleaseLocker();
                pkg.User.AddUsageCharge(charge);
                pkg.UpdateShippingStatus(ShippingStatus.Retrieved);
                return locker;
            } catch (MaximumStoragePeriodExceededException e) {
                locker.ReleaseLocker();
                return locker;
            }
        }
        return null;
    }

    // Returns an account by its ID
    public Account GetAccount(string testAccount) {
        return accounts.GetValueOrDefault(testAccount);
    }
}
