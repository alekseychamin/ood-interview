namespace ParkingLotSystem;

public class Car : IVehicle {
    private string licensePlate;

    public Car(string licensePlate) {
        this.licensePlate = licensePlate;
    }

    public string LicensePlate => this.licensePlate;

    public VehicleSize Size => VehicleSize.Medium; // Cars are medium-sized
}
