namespace Elevator;

public class ShortestSeekTimeFirstStrategy : IDispatchingStrategy {
    public ElevatorCar SelectElevator(List<ElevatorCar> elevators, int floor, Direction direction) {
        ElevatorCar bestElevator = null;
        int shortestDistance = int.MaxValue;

        foreach (ElevatorCar elevator in elevators) {
            int distance = Math.Abs(elevator.CurrentFloor - floor);
            if ((elevator.IsIdle || elevator.CurrentDirection == direction) && distance < shortestDistance) {
                bestElevator = elevator;
                shortestDistance = distance;
            }
        }

        return bestElevator;
    }
}
