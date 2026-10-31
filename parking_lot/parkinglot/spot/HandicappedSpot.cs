namespace ParkingLotSystem;

public class HandicappedSpot : IParkingSpot {
    private int spotNumber;
    private IVehicle vehicle;

    public HandicappedSpot(int spotNumber) {
        this.spotNumber = spotNumber;
        this.vehicle = null;
    }

    public int SpotNumber => spotNumber;

    public bool IsAvailable => vehicle == null;

    public void Occupy(IVehicle vehicle) {
        if (IsAvailable) {
            this.vehicle = vehicle;
        } else {
            // Spot is already occupied
        }
    }

    public void Vacate() {
        this.vehicle = null;
    }

    public VehicleSize Size => VehicleSize.Medium;
}
