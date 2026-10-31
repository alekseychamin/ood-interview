namespace ParkingLotSystem;

public class BaseFareStrategy : IFareStrategy {
    private const decimal SmallVehicleRate = 1.0m;
    private const decimal MediumVehicleRate = 2.0m;
    private const decimal LargeVehicleRate = 3.0m;

    // Calculate fare based on the duration and add it to the input fare to return a new total
    public decimal CalculateFare(Ticket ticket, decimal inputFare) {
        decimal fare = inputFare;
        decimal rate;
        switch (ticket.Vehicle.Size) {
            case VehicleSize.Medium:
                rate = MediumVehicleRate;
                break;
            case VehicleSize.Large:
                rate = LargeVehicleRate;
                break;
            default:
                rate = SmallVehicleRate;
                break;
        }
        fare = (fare + (rate * ticket.CalculateParkingDuration()));
        return fare;
    }
}
