namespace MovieTicket;

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
}
