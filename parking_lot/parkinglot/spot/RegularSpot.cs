namespace ParkingLotSystem;

public class RegularSpot : IParkingSpot {
    private int spotNumber;
    private IVehicle vehicle;  // The vehicle currently occupying this spot

    public RegularSpot(int spotNumber) {
        this.spotNumber = spotNumber;
        this.vehicle = null;  // No vehicle occupying initially
    }

    public int SpotNumber => spotNumber;

    public bool IsAvailable => vehicle == null; // Available if no vehicle is occupying

    public void Occupy(IVehicle vehicle) {
        if (IsAvailable) {
            this.vehicle = vehicle;
        } else {
            // Spot is already occupied
        }
    }

    public void Vacate() {
        this.vehicle = null;  // Make the spot available
    }

    public VehicleSize Size => VehicleSize.Medium; // Regular spots fit medium vehicles
}
