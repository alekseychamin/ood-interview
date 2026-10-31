namespace Elevator;

public class ElevatorStatus {

    private readonly int currentFloor;
    private readonly Direction currentDirection;

    public ElevatorStatus(int currentFloor, Direction currentDirection) {
        this.currentFloor = currentFloor;
        this.currentDirection = currentDirection;
    }

    public int CurrentFloor => currentFloor;

    public Direction CurrentDirection => currentDirection;
}
