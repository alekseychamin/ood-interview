namespace MovieTicket;

public class Room {
    private readonly string roomNumber;
    private readonly Layout layout;

    public Room(string roomNumber, Layout layout) {
        this.roomNumber = roomNumber;
        this.layout = layout;
    }

    public string RoomNumber => roomNumber;

    public Layout Layout => layout;
}
