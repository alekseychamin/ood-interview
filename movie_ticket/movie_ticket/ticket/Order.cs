namespace MovieTicket;

public class Order {
    private readonly List<Ticket> tickets;
    private readonly DateTime orderDate;

    public Order(DateTime orderDate) {
        this.tickets = new();
        this.orderDate = orderDate;
    }

    public void AddTicket(Ticket ticket) {
        tickets.Add(ticket);
    }

    public List<Ticket> AllTickets => tickets;

    // Calculates the total price of all tickets in the order
    public decimal CalculateTotalPrice() {
        return tickets.Sum(ticket => ticket.Price);
    }

    public DateTime OrderDate => orderDate;
}
