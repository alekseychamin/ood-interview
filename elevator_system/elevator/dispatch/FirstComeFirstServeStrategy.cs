namespace Elevator;

public class FirstComeFirstServeStrategy : IDispatchingStrategy {
    public ElevatorCar SelectElevator(List<ElevatorCar> elevators, int floor, Direction direction) {
        foreach (ElevatorCar elevator in elevators) {
            if (elevator.IsIdle || elevator.CurrentDirection == direction) {
                return elevator;
            }
        }
        return elevators[Random.Shared.Next(elevators.Count)];
    }
}
