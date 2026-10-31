namespace ParkingLotSystem;

public class PeakHoursFareStrategy : IFareStrategy {
    private const decimal PeakHoursMultiplier = 1.5m;  // 50% higher during peak hours

    public PeakHoursFareStrategy() {

    }

    public decimal CalculateFare(Ticket ticket, decimal inputFare) {
        decimal fare = inputFare;
        if (IsPeakHours(ticket.EntryTime)) {
            fare = (fare * PeakHoursMultiplier);
        }
        return fare;
    }

    private bool IsPeakHours(DateTime time) {
        int hour = time.Hour;
        return (hour >= 7 && hour <= 10) || (hour >= 16 && hour <= 19);  // Example peak hours
    }
}
