namespace ShippingLocker;

// Enum representing different sizes of lockers with their dimensions and charges
public enum LockerSize {
    // Small locker with 10x10x10 dimensions and $5 daily charge
    Small,
    // Medium locker with 20x20x20 dimensions and $10 daily charge
    Medium,
    // Large locker with 30x30x30 dimensions and $15 daily charge
    Large
}

// C# enums cannot hold fields like Java enums, so the size data is
// exposed through C# 14 extension properties (size.DailyCharge, size.Width, ...)
public static class LockerSizeExtensions {
    extension(LockerSize size) {
        // Name of the locker size
        public string SizeName => size.ToString();

        // Daily charge for using this size locker
        public decimal DailyCharge => size switch {
            LockerSize.Small => 5.00m,
            LockerSize.Medium => 10.00m,
            _ => 15.00m,
        };

        // Width of the locker in inches
        public decimal Width => size switch {
            LockerSize.Small => 10.00m,
            LockerSize.Medium => 20.00m,
            _ => 30.00m,
        };

        // Height of the locker in inches
        public decimal Height => size.Width;

        // Depth of the locker in inches
        public decimal Depth => size.Width;
    }
}
