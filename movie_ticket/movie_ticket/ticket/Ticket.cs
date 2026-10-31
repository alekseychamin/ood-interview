namespace MovieTicket;

public class Ticket {
    private readonly Screening screening;
    private readonly Seat seat;
    private readonly decimal price;

    public Ticket(Screening screening, Seat seat, decimal price) {
        this.screening = screening;
        this.seat = seat;
        this.price = price;
    }

    public Screening Screening => screening;

    public Seat Seat => seat;

    public decimal Price => price;
}
