namespace ShippingLocker;

// Interface defining the contract for shipping packages
public interface IShippingPackage {
    // Returns the unique order identifier
    string OrderId { get; }

    // Returns the user account associated with this package
    Account User { get; }

    // Returns the width of the package
    decimal Width { get; }

    // Returns the height of the package
    decimal Height { get; }

    // Returns the depth of the package
    decimal Depth { get; }

    // Returns the current status of the package
    ShippingStatus Status { get; }

    // Updates the status of the package
    void UpdateShippingStatus(ShippingStatus status);

    // Determines the appropriate locker size for this package
    LockerSize LockerSize { get; }
}
