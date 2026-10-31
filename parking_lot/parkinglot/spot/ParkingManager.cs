namespace ParkingLotSystem;

public class ParkingManager {
    private readonly Dictionary<VehicleSize, List<IParkingSpot>> availableSpots;
    private readonly Dictionary<IVehicle, IParkingSpot> vehicleToSpotMap;

    // Create Parking Manager based on a given map of available spots
    public ParkingManager(Dictionary<VehicleSize, List<IParkingSpot>> availableSpots) {
        this.availableSpots = availableSpots;
        this.vehicleToSpotMap = new();
    }

    public IParkingSpot FindSpotForVehicle(IVehicle vehicle) {
        VehicleSize vehicleSize = vehicle.Size;

        // Start looking from the smallest spot that can fit the vehicle
        foreach (VehicleSize size in Enum.GetValues<VehicleSize>()) {
            if ((int)size >= (int)vehicleSize) {
                List<IParkingSpot> spots = availableSpots.GetValueOrDefault(size);
                foreach (IParkingSpot spot in spots) {
                    if (spot.IsAvailable) {
                        return spot;  // Return the first available spot
                    }
                }
            }
        }
        return null;  // No suitable spot found
    }

    public IParkingSpot ParkVehicle(IVehicle vehicle) {
        IParkingSpot spot = FindSpotForVehicle(vehicle);
        if (spot != null) {
            spot.Occupy(vehicle);
            // Record the parking spot for the vehicle
            vehicleToSpotMap[vehicle] = spot;  
            // Remove the spot from the available list
            availableSpots.GetValueOrDefault(spot.Size).Remove(spot);
            return spot;  // Parking successful
        }
        return null;  // No spot found for this vehicle
    }

    public void UnparkVehicle(IVehicle vehicle) {
        vehicleToSpotMap.Remove(vehicle, out IParkingSpot spot);
        if (spot != null) {
            spot.Vacate();
            availableSpots.GetValueOrDefault(spot.Size).Add(spot);
        }
    }

    // used for testing 
    public IParkingSpot FindVehicleSpot(IVehicle vehicle) {
        return vehicleToSpotMap.GetValueOrDefault(vehicle);
    }

}
