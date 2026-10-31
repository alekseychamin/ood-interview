namespace VendingMachineSystem.DeepDive;

public class InvalidStateException : Exception {
    public InvalidStateException(string message) : base(message) {
    }
}
