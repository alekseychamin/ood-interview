namespace MovieTicket;

public class PremiumRate : IPricingStrategy {
    private readonly decimal price;

    public PremiumRate(decimal price) {
        this.price = price;
    }

    public decimal Price => price;
}
