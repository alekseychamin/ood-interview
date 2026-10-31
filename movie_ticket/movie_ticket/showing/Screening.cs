namespace MovieTicket;

// Represents a scheduled screening of a movie in a specific cinema room.
public class Screening {
    private readonly Movie movie;
    private readonly Room room;
    private readonly DateTime startTime;
    private readonly DateTime endTime;

    public Screening(Movie movie, Room room, DateTime startTime, DateTime endTime) {
        this.movie = movie;
        this.room = room;
        this.startTime = startTime;
        this.endTime = endTime;
    }

    public Movie Movie => movie;

    public Room Room => room;

    public DateTime StartTime => startTime;

    public DateTime EndTime => endTime;

    public TimeSpan Duration => (endTime - startTime);
}
