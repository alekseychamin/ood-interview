namespace MovieTicket;

public class NormalRate : IPricingStrategy {
    private readonly decimal price;

    public NormalRate(decimal price) {
        this.price = price;
    }

    public decimal Price => price;
}
