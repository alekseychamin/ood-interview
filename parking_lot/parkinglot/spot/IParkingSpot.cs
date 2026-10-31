namespace ParkingLotSystem;

public interface IParkingSpot {
    bool IsAvailable { get; }
    void Occupy(IVehicle vehicle);
    void Vacate();
    int SpotNumber { get; }
    VehicleSize Size { get; }
}
