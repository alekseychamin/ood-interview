namespace Elevator;

// Observable Subject: HallwayButtonPanel
public class HallwayButtonPanel {
    private readonly int floor;
    private readonly List<IElevatorObserver> observers;

    public HallwayButtonPanel(int floor) {
        this.floor = floor;
        this.observers = new();
    }

    public void PressButton(Direction direction) {
        NotifyObservers(direction);
    }

    public void AddObserver(IElevatorObserver observer) {
        observers.Add(observer);
    }

    private void NotifyObservers(Direction direction) {
        foreach (IElevatorObserver observer in observers) {
            observer.Update(floor, direction);
        }
    }
}
