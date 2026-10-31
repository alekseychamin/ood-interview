namespace ShippingLocker;

public class PackageIncompatibleException : Exception {
    public PackageIncompatibleException(string s) : base(s) {
    }
}
