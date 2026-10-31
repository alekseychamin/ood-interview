namespace ShippingLocker;

// Basic implementation of a shipping package
public class BasicShippingPackage : IShippingPackage {
    // Unique identifier for the order
    private readonly string orderId;
    // User account associated with this package
    private readonly Account user;
    // Width of the package in inches
    private readonly decimal width;
    // Height of the package in inches
    private readonly decimal height;
    // Depth of the package in inches
    private readonly decimal depth;
    // Current status of the package
    private ShippingStatus status;

    // Creates a new shipping package with specified dimensions
    public BasicShippingPackage(string orderId, Account user, decimal width, decimal height, decimal depth) {
        this.orderId = orderId;
        this.user = user;
        this.width = width;
        this.height = height;
        this.depth = depth;
        this.status = ShippingStatus.Created;
    }

    // Returns the order identifier
    public string OrderId => orderId;

    // Returns the user account
    public Account User => user;

    // Returns the package width
    public decimal Width => width;

    // Returns the package height
    public decimal Height => height;

    // Returns the package depth
    public decimal Depth => depth;

    // Returns the current package status
    public ShippingStatus Status => status;

    // Updates the package status
    public void UpdateShippingStatus(ShippingStatus status) {
        this.status = status;
    }

    // Determines the smallest locker size that can fit this package
    public LockerSize LockerSize
    {
        get
        {
            foreach (LockerSize size in Enum.GetValues<LockerSize>()) {
                if(size.Width >= width && 
                   size.Height >= height && 
                   size.Depth >= depth) {
                    return size;
                }
            }
            throw new PackageIncompatibleException("No locker size available for the package");
        }
    }
}
