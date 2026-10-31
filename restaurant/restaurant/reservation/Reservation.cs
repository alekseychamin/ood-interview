namespace RestaurantSystem;

// Represents a reservation made at the restaurant for a specific party, time and table
public class Reservation {
    private readonly string partyName;
    private readonly int partySize;
    private readonly DateTime time;
    private readonly Table assignedTable;

    public Reservation(string partyName, int partySize, DateTime time, Table assignedTable) {
        this.partyName = partyName;
        this.partySize = partySize;
        this.time = time;
        this.assignedTable = assignedTable;
    }

    public string PartyName => partyName;

    public int PartySize => partySize;

    public DateTime Time => time;

    public Table AssignedTable => assignedTable;
}
