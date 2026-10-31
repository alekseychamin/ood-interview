namespace MovieTicket.DeepDive;

// Manages the relationships between movies, screenings, and tickets in the booking system
public class ScreeningManager {
    // Maps movies to their scheduled screenings
    private readonly Dictionary<Movie, List<Screening>> screeningsByMovie;
    // Maps screenings to tickets sold for that screening
    private readonly Dictionary<Screening, List<Ticket>> ticketsByScreening;

    public ScreeningManager() {
        this.screeningsByMovie = new();
        this.ticketsByScreening = new();
    }

    public void AddScreening(Movie movie, Screening screening) {
        if (!screeningsByMovie.TryGetValue(movie, out List<Screening> screenings)) {
            screenings = new List<Screening>();
            screeningsByMovie[movie] = screenings;
        }
        screenings.Add(screening);
    }

    // Returns all screenings for a specific movie
    public List<Screening> GetScreeningsForMovie(Movie movie) {
        return screeningsByMovie.GetValueOrDefault(movie, new List<Screening>());
    }

    public void AddTicket(Screening screening, Ticket ticket) {
        if (!ticketsByScreening.TryGetValue(screening, out List<Ticket> tickets)) {
            tickets = new List<Ticket>();
            ticketsByScreening[screening] = tickets;
        }
        tickets.Add(ticket);
    }

    // Returns all tickets sold for a specific screening
    public List<Ticket> GetTicketsForScreening(Screening screening) {
        return ticketsByScreening.GetValueOrDefault(screening, new List<Ticket>());
    }

    // Calculates which seats are still available for a screening
    public List<Seat> GetAvailableSeats(Screening screening) {
        List<Seat> allSeats = screening.Room.Layout.AllSeats;
        List<Ticket> bookedTickets = GetTicketsForScreening(screening);

        List<Seat> availableSeats = new(allSeats);
        foreach (Ticket ticket in bookedTickets) {
            availableSeats.Remove(ticket.Seat);
        }
        return availableSeats;
    }
    // Simplified optimistic locking in ScreeningManager
    // (Java: synchronized method; C#: lock statement)
    private readonly object syncRoot = new();

    public Ticket BookSeatOptimistically(Screening screening, Seat seat) {
        lock (syncRoot) {
            // First check if a seat is available (optimistic)
            if (IsSeatBooked(screening, seat)) {
                throw new InvalidOperationException("Seat is already booked");
            }

            // Create ticket - at this point, we're optimistically assuming
            // the seat is still available
            decimal price = seat.PricingStrategy.Price;
            Ticket ticket = new Ticket(screening, seat, price);

            // Add to booking system - this effectively "reserves" the seat
            AddTicket(screening, ticket);
            return ticket;
        }
    }

    // Helper method to check if a seat is already booked
    private bool IsSeatBooked(Screening screening, Seat seat) {
        List<Ticket> tickets = GetTicketsForScreening(screening);
        return tickets.Any(ticket => ticket.Seat.Equals(seat));
    }
}
