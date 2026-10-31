namespace MovieTicket;

public class Movie {
    private readonly string title;
    private readonly string genre;
    private readonly int durationInMinutes;

    public Movie(string title, string genre, int durationInMinutes) {
        this.title = title;
        this.genre = genre;
        this.durationInMinutes = durationInMinutes;
    }

    public string Title => title;

    public string Genre => genre;

    public TimeSpan Duration => TimeSpan.FromMinutes(durationInMinutes);
}
