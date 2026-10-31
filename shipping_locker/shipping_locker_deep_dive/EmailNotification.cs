namespace ShippingLocker.DeepDive;

// Implementation of LockerEventObserver that sends email notifications
public class EmailNotification : ILockerEventObserver {
    // Updates the observer with a message and sends it to the account owner
    public void Update(string message, Account account) {
        // Email sent to account owner
    }
}
