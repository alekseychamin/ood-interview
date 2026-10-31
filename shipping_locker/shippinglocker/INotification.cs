namespace ShippingLocker;

public interface INotification {
    void SendNotification(string message, Account user);
}
