namespace MovieTicket;

// Represents the seating layout of a cinema room.
public class Layout {
    private readonly int rows;
    private readonly int columns;
    
    // Maps seat numbers (e.g., "0-0") to Seat objects for direct access
    private readonly Dictionary<string, Seat> seatsByNumber;
    
    // Nested map for position-based access (row → column → seat)
    private readonly Dictionary<int, Dictionary<int, Seat>> seatsByPosition;

    public Layout(int rows, int columns) {
        this.rows = rows;
        this.columns = columns;
        this.seatsByNumber = new();
        this.seatsByPosition = new();
        InitializeLayout();
    }

    // Creates seats for all positions with default null pricing
    private void InitializeLayout() {
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                string seatNumber = i + "-" + j;
                AddSeat(seatNumber, i, j, new Seat(seatNumber, null));
            }
        }
    }

    public void AddSeat(string seatNumber, int row, int column, Seat seat) {
        // Store seat in number-based lookup map
        seatsByNumber[seatNumber] = seat;
        // Store seat in position-based lookup map
        if (!seatsByPosition.TryGetValue(row, out Dictionary<int, Seat> rowSeats)) {
            rowSeats = new Dictionary<int, Seat>();
            seatsByPosition[row] = rowSeats;
        }
        rowSeats[column] = seat;
    }

    public Seat GetSeatByNumber(string seatNumber) {
        return seatsByNumber.GetValueOrDefault(seatNumber);
    }

    // Gets a seat by its row and column position
    public Seat GetSeatByPosition(int row, int column) {
        Dictionary<int, Seat> rowSeats = seatsByPosition.GetValueOrDefault(row);
        return (rowSeats != null) ? rowSeats.GetValueOrDefault(column) : null;
    }

    public List<Seat> AllSeats => [.. seatsByNumber.Values];
}
