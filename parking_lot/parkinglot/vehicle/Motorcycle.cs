namespace ParkingLotSystem;

public class Motorcycle : IVehicle {
    private string licensePlate;

    public Motorcycle(string licensePlate) {
        this.licensePlate = licensePlate;
    }

    public string LicensePlate => this.licensePlate;

    public VehicleSize Size => VehicleSize.Small; // Motorcycles are small-sized
}
