namespace Elevator;

public class ElevatorCar {
    private ElevatorStatus status;
    private readonly Queue<int> targetFloors;

    public ElevatorCar(int startingFloor) {
        this.status = new ElevatorStatus(startingFloor, Direction.Idle);
        this.targetFloors = new();
    }

    public ElevatorStatus Status => status;

    public void AddFloorRequest(int floor) {
        if (!targetFloors.Contains(floor)) {
            targetFloors.Enqueue(floor);
            UpdateDirection(floor);
        }
    }

    public int CurrentFloor => status.CurrentFloor;

    public Direction CurrentDirection => status.CurrentDirection;

    public bool IsIdle => targetFloors.Count == 0;

    private void UpdateDirection(int targetFloor) {
        if (status.CurrentFloor < targetFloor) {
            status = new ElevatorStatus(status.CurrentFloor, Direction.Up);
        } else if (status.CurrentFloor > targetFloor) {
            status = new ElevatorStatus(status.CurrentFloor, Direction.Down);
        }
    }

    public void MoveOneStep() {
        if (targetFloors.Count == 0) return;

        int nextFloor = targetFloors.Peek();
        if (status.CurrentFloor < nextFloor) {
            status = new ElevatorStatus(status.CurrentFloor + 1, Direction.Up);
        } else if (status.CurrentFloor > nextFloor) {
            status = new ElevatorStatus(status.CurrentFloor - 1, Direction.Down);
        } else {
            targetFloors.Dequeue();
            if (targetFloors.Count == 0) {
                status = new ElevatorStatus(status.CurrentFloor, Direction.Idle);
            }
        }
    }

    public bool IsAtDestination => targetFloors.Count > 0 && status.CurrentFloor == targetFloors.Peek();

    public void NextDestination() {
        if (IsAtDestination) {
            targetFloors.Dequeue();
        }
    }

    public void MoveUntilNextFloor() {
        if (targetFloors.Count > 0) {
            int nextFloor = targetFloors.Peek();
            while (status.CurrentFloor != nextFloor) {
                MoveOneStep();
            }
        }
    }
}
