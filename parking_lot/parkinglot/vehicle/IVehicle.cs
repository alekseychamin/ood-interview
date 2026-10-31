namespace ParkingLotSystem;

public interface IVehicle {
    string LicensePlate { get; }
    VehicleSize Size { get; }
}
