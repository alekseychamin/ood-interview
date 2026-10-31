namespace ShippingLocker;

public enum ShippingStatus {
    Created,        // Initial state when package is first created
    Pending,        // Package is ready for locker assignment
    InLocker,      // Package has been assigned to a locker
    Retrieved,      // Package has been picked up by the customer
    Expired,        // Package has exceeded maximum storage time
}
