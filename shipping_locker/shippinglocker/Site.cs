namespace ShippingLocker;

// Represents a physical site containing multiple lockers of different sizes
public class Site {
    // Map of locker sizes to sets of lockers of that size
    internal Dictionary<LockerSize, HashSet<Locker>> lockers = new();

    // Creates a new site with specified number of lockers for each size
    public Site(Dictionary<LockerSize, int> lockers) {
        foreach (KeyValuePair<LockerSize, int> entry in lockers) {
            HashSet<Locker> lockerSet = new();
            for (int i = 0; i < entry.Value; i++) {
                lockerSet.Add(new Locker(entry.Key));
            }
            this.lockers[entry.Key] = lockerSet;
        }
    }

    // Finds an available locker of the specified size
    public Locker FindAvailableLocker(LockerSize size) {
        foreach (Locker locker in lockers.GetValueOrDefault(size)) {
            if (locker.IsAvailable) {
                return locker;
            }
        }
        return null;
    }

    // Places a package in an available locker of appropriate size
    public Locker PlacePackage(IShippingPackage pkg, DateTime date) {
        // Determine the smallest locker size that can fit this package
        LockerSize size = pkg.LockerSize;
        Locker locker = FindAvailableLocker(size);
        if (locker != null) {
            locker.AssignPackage(pkg, date);
            pkg.UpdateShippingStatus(ShippingStatus.InLocker);
            return locker;
        } 
        throw new NoLockerAvailableException("No locker of size " + size + " is currently available");
    }
}
