namespace MovieTicket;

public class VIPRate : IPricingStrategy {
    private readonly decimal price;

    public VIPRate(decimal price) {
        this.price = price;
    }

    public decimal Price => price;
}
