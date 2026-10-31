namespace Elevator;

public class ElevatorSystem {

    private readonly List<ElevatorCar> elevators;
    private readonly ElevatorDispatch dispatchController;

    public ElevatorSystem(List<ElevatorCar> elevators, IDispatchingStrategy strategy) {
        this.elevators = elevators;
        this.dispatchController = new ElevatorDispatch(strategy);
    }

    public List<ElevatorStatus> AllElevatorStatuses
    {
        get
        {
            List<ElevatorStatus> statuses = new();
            foreach (ElevatorCar elevator in elevators) {
                statuses.Add(elevator.Status);
            }
            return statuses;
        }
    }

    public void RequestElevator(int currentFloor, Direction direction) {
        dispatchController.DispatchElevatorCar(currentFloor, direction, elevators);
    }

    public void SelectFloor(ElevatorCar car, int destinationFloor) {
        // selecting the floor from within the elevator is directly handled by the elevator car
        car.AddFloorRequest(destinationFloor);
    }

}
