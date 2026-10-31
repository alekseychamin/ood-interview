namespace ShippingLocker.DeepDive;

public class LockerManagerChange {
    // List of observers that will be notified of locker events
    private readonly List<ILockerEventObserver> observers = new();

    public void AddObserver(ILockerEventObserver observer) {
        observers.Add(observer);
    }

    public void RemoveObserver(ILockerEventObserver observer) {
        observers.Remove(observer);
    }

    private void NotifyObservers(string message, Account account) {
        foreach (ILockerEventObserver observer in observers) {
            observer.Update(message, account);
        }
    }

    // Assigns a package to an available locker and notifies observers.
    public void AssignPackage(IShippingPackage pkg) {
        Locker locker = AssignLockerToPackage(pkg);
        if (locker != null) {
            NotifyObservers("Package assigned to locker ", pkg.User);
        }
    }

    private Locker AssignLockerToPackage(IShippingPackage pkg) {
        return null;
    }
}
