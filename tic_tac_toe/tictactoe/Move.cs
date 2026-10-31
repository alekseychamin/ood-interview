namespace TicTacToe;

public class Move {
    // Row index of the move (0-2)
    internal int rowIndex;
    // Column index of the move (0-2)
    internal int colIndex;
    // Player who made the move
    internal Player player;

    // Creates a new move with position and player information
    public Move(int colIndex, int rowIndex, Player player) {
        this.rowIndex = rowIndex;
        this.colIndex = colIndex;
        this.player = player;
    }

    // Returns the row index of the move
    public int RowIndex => rowIndex;

    // Returns the column index of the move
    public int ColIndex => colIndex;

    // Returns the player who made the move
    public Player Player => player;
}
