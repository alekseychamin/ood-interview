namespace ShippingLocker;

// Exception thrown when a package exceeds its maximum allowed storage period
public class MaximumStoragePeriodExceededException : Exception {
    // Creates a new exception with the specified message
    public MaximumStoragePeriodExceededException(string message) : base(message) {
    }
}
