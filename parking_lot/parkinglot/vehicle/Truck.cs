namespace ParkingLotSystem;

public class Truck : IVehicle {
    private string licensePlate;

    public Truck(string licensePlate) {
        this.licensePlate = licensePlate;
    }

    public string LicensePlate => this.licensePlate;

    public VehicleSize Size => VehicleSize.Large; // Trucks are large-sized
}
