namespace Elevator;

// Observer Interface
public interface IElevatorObserver {
    void Update(int floor, Direction direction);
}
