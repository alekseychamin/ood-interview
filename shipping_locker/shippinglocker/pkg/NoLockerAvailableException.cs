namespace ShippingLocker;

public class NoLockerAvailableException : Exception {
    public NoLockerAvailableException(string message) : base(message) {
    }
}
