namespace ShippingLocker.DeepDive;

// Factory class for creating Locker instances
public class LockerFactory {
    // Creates a new locker of the specified size
    public static Locker CreateLocker(LockerSize size) {
        return size switch {
            LockerSize.Small => new Locker(LockerSize.Small),
            LockerSize.Medium => new Locker(LockerSize.Medium),
            LockerSize.Large => new Locker(LockerSize.Large),
            _ => throw new ArgumentException("Unknown locker size: " + size),
        };
    }
}
