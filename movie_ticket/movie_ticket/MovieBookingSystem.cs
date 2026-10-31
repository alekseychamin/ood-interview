namespace MovieTicket;

// Manages the complete movie booking system operations
public class MovieBookingSystem {
    
    private readonly List<Movie> movies;
    private readonly List<Cinema> cinemas;
    private readonly ScreeningManager screeningManager;

    public MovieBookingSystem() {
        this.movies = new();
        this.cinemas = new();
        this.screeningManager = new ScreeningManager();
    }

    public void AddMovie(Movie movie) {
        movies.Add(movie);
    }

    public void AddCinema(Cinema cinema) {
        cinemas.Add(cinema);
    }

    public List<Movie> AllMovies => movies;

    public List<Cinema> AllCinemas => cinemas;

    internal ScreeningManager ScreeningManager => screeningManager;

    // Returns all screenings for a specific movie
    public List<Screening> GetScreeningsForMovie(Movie movie) {
        return screeningManager.GetScreeningsForMovie(movie);
    }

    // Returns all available seats for a screening
    public List<Seat> GetAvailableSeats(Screening screening) {
        return screeningManager.GetAvailableSeats(screening);
    }

    // Books a ticket for a specific seat at a screening
    public void BookTicket(Screening screening, Seat seat) {
        decimal price = seat.PricingStrategy.Price;
        Ticket ticket = new Ticket(screening, seat, price);
        screeningManager.AddTicket(screening, ticket);
    }

    public void AddScreening(Movie movie, Screening screening) {
        screeningManager.AddScreening(movie, screening);
    }

    // Returns the number of tickets sold for a screening
    public int GetTicketCount(Screening screening) {
        return screeningManager.GetTicketsForScreening(screening).Count;
    }

    // Returns the list of tickets for a screening
    public List<Ticket> GetTicketsForScreening(Screening screening) {
        return screeningManager.GetTicketsForScreening(screening);
    }
}
