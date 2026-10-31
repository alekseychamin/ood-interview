namespace RestaurantSystem;

// Manages the collection of tables in the restaurant and their arrangement
public class Layout {
    private readonly Dictionary<int, Table> tablesById = new();
    // Groups tables by their capacity for efficient table assignment, sorted from smallest to largest capacity
    private readonly SortedDictionary<int, HashSet<Table>> tablesByCapacity = new();

    public Layout(List<int> tableCapacities) {
        for (int i = 0; i < tableCapacities.Count; i++) {
            int capacity = tableCapacities[i];
            Table table = new Table(i, capacity);
            tablesById[i] = table;
            if (!tablesByCapacity.TryGetValue(capacity, out HashSet<Table> tables)) {
                tables = new HashSet<Table>();
                tablesByCapacity[capacity] = tables;
            }
            tables.Add(table);
        }
    }

    // Finds the smallest available table that can accommodate a party of the given size at the given time
    public Table FindAvailableTable(int partySize, DateTime reservationTime) {
        // Equivalent of Java's TreeMap.tailMap(partySize): capacities >= partySize, in ascending order
        foreach (HashSet<Table> tables in tablesByCapacity.Where(entry => entry.Key >= partySize).Select(entry => entry.Value)) {
            foreach (Table table in tables) {
                if (table.IsAvailableAt(reservationTime)) {
                    return table;
                }
            }
        }
        return null;
    }
}
