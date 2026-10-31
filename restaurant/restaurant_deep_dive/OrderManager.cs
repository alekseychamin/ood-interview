namespace RestaurantSystem.DeepDive;

// Step 3: Implement the Invoker, which will replace direct method implementation.
public class OrderManager {
    private readonly List<IOrderCommand> commandQueue = new();

    // Adds a command to the queue for later execution
    public void AddCommand(IOrderCommand command) {
        commandQueue.Add(command);
    }

    // Executes all commands in the queue and clears it
    public void ExecuteCommands() {
        foreach (IOrderCommand command in commandQueue) {
            command.Execute();
        }
        commandQueue.Clear();
    }
}
