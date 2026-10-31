namespace Atm;

public class ConsoleDisplay : IDisplay {
    // Stores the current message to be displayed
    private string message;

    public void ShowMessage(string message) {
        this.message = message;
    }

    // Returns the currently stored message
    public string DisplayedMessage => message;
}
