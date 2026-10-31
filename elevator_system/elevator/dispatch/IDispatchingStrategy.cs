namespace Elevator;

public interface IDispatchingStrategy {
    ElevatorCar SelectElevator(List<ElevatorCar> elevators, int floor, Direction direction);
}
