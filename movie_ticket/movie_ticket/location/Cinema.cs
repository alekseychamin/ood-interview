namespace MovieTicket;

public class Cinema {
    private readonly string name;
    private readonly string location;
    private readonly List<Room> rooms;

    public Cinema(string name, string location) {
        this.name = name;
        this.location = location;
        this.rooms = new();
    }

    public void AddRoom(Room room) {
        rooms.Add(room);
    }

    public List<Room> Rooms => rooms;

    public string Name => name;

    public string Location => location;
}
