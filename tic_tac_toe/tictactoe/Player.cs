namespace TicTacToe;

public class Player {
    // Player's name identifier
    private readonly string name;
    // Player's symbol (X or O)
    private readonly char symbol;
    
    // Creates a new player with a name and symbol
    public Player(string name, char symbol) {
        this.name = name;
        this.symbol = symbol;
    }

    // Returns the player's name
    public string Name => name;

    // Returns a string representation of the player (their name)
    public override string ToString(){
        return name;
    }

    // Returns the player's symbol (X or O)
    public char Symbol => symbol;
}
