namespace Atm;

public interface IDisplay {
    // Displays a message to the user on the ATM screen
    void ShowMessage(string message);

    // Returns the currently displayed message
    string DisplayedMessage { get; }
}
