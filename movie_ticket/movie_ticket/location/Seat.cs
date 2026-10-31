namespace MovieTicket;

public class Seat {
    private readonly string seatNumber;
    private IPricingStrategy pricingStrategy;

    public Seat(string seatNumber, IPricingStrategy pricingStrategy) {
        this.seatNumber = seatNumber;
        this.pricingStrategy = pricingStrategy;
    }

    public string SeatNumber => seatNumber;

    public IPricingStrategy PricingStrategy => pricingStrategy;

    public void SetPricingStrategy(IPricingStrategy pricingStrategy) {
        this.pricingStrategy = pricingStrategy;
    }
}
