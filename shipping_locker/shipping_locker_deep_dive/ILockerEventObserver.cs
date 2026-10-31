namespace ShippingLocker.DeepDive;

// Interface for objects that need to be notified of locker events
public interface ILockerEventObserver {
    // Updates the observer with a message and the affected account
    void Update(string message, Account account);
}
