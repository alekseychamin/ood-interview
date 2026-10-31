namespace Elevator;

// Example Usage
public class ObserverPatternExample {
    private readonly ElevatorSystem elevatorSystem;

    public ObserverPatternExample(ElevatorSystem elevatorSystem) {
        this.elevatorSystem = elevatorSystem;
    }

    // Renamed from Main: the test SDK already generates an entry point for this project
    public static void Run(string[] args) {
        HallwayButtonPanel hallwayButtonPanel = new HallwayButtonPanel(5);
        ElevatorDispatchController controller = new ElevatorDispatchController();

        hallwayButtonPanel.AddObserver(controller);
        hallwayButtonPanel.PressButton(Direction.Up);
    }
}
