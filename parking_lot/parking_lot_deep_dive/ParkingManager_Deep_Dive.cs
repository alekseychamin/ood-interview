namespace ParkingLotSystem.DeepDive;

public class ParkingManager_Deep_Dive {
    private readonly Dictionary<VehicleSize, List<IParkingSpot>> availableSpots;
    private readonly Dictionary<IVehicle, IParkingSpot> vehicleToSpotMap;
    private readonly Dictionary<IParkingSpot, IVehicle> spotToVehicleMap;

    // Create Parking Manager based on a given map of available spots
    public ParkingManager_Deep_Dive(Dictionary<VehicleSize, List<IParkingSpot>> availableSpots) {
        this.availableSpots = availableSpots;
        this.vehicleToSpotMap = new();
        this.spotToVehicleMap = new();
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
            // Record bidirectional mapping
            vehicleToSpotMap[vehicle] = spot;
            spotToVehicleMap[spot] = vehicle;
            // Remove the spot from the available list
            availableSpots.GetValueOrDefault(spot.Size).Remove(spot);
            return spot;  // Parking successful
        }
        return null;  // No spot found for this vehicle
    }

    public void UnparkVehicle(IVehicle vehicle) {
        vehicleToSpotMap.Remove(vehicle, out IParkingSpot spot);
        if (spot != null) {
            spotToVehicleMap.Remove(spot);
            spot.Vacate();
            availableSpots.GetValueOrDefault(spot.Size).Add(spot);
        }
    }

    // Find vehicle's parking spot
    public IParkingSpot FindVehicleBySpot(IVehicle vehicle) {
        return vehicleToSpotMap.GetValueOrDefault(vehicle);
    }

    // Find which vehicle is parked in a spot
    public IVehicle FindSpotByVehicle(IParkingSpot spot) {
        return spotToVehicleMap.GetValueOrDefault(spot);
    }
}
