namespace ParkingLotSystem;

public class FareCalculator {
    private readonly List<IFareStrategy> fareStrategies;

    public FareCalculator(List<IFareStrategy> fareStrategies) {
        this.fareStrategies = fareStrategies;
    }
    public decimal CalculateFare(Ticket ticket) {
        decimal fare = 0m;
        foreach (IFareStrategy strategy in fareStrategies) {
            fare = strategy.CalculateFare(ticket, fare);
        }
        return fare;
    }
}
