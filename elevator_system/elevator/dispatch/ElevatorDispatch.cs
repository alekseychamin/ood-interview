namespace Elevator;

public class ElevatorDispatch {

    private readonly IDispatchingStrategy strategy;

    public ElevatorDispatch(IDispatchingStrategy strategy) {
        this.strategy = strategy;
    }

    public void DispatchElevatorCar(int floor, Direction direction, List<ElevatorCar> elevators) {
        ElevatorCar selectedElevator = strategy.SelectElevator(elevators, floor, direction);
        if (selectedElevator != null) {
            selectedElevator.AddFloorRequest(floor);
        }
    }
}
