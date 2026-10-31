namespace TicTacToe;

public class Board {
    // 3x3 grid to store player moves
    private readonly Player[][] grid = [new Player[3], new Player[3], new Player[3]];

    // Updates the board with a player's move at the specified position
    public void UpdateBoard(int colIndex, int rowIndex, Player player) {
        if (grid[colIndex][rowIndex] == null) {
            grid[colIndex][rowIndex] = player;
        }
    }

    // Checks for a winner by examining rows, columns, and diagonals
    // Returns null when there is no winner (Java version returns Optional<Player>)
    public Player Winner
    {
        get
        {
            // Check rows for three in a row
            for (int i = 0; i < grid.Length; i++) {
                Player first = grid[i][0];
                if (first != null && grid[i].All(p => p == first)) {
                    return first;
                }
            }
    
            // Check columns for three in a column
            for (int j = 0; j < grid[0].Length; j++) {
                Player first = grid[0][j];
                int finalJ = j; // local variable must be effectively final to pass to lambda
                if (first != null && grid.All(row => row[finalJ] == first)) {
                    return first;
                }
            }
    
            // Check main diagonal (top-left to bottom-right)
            Player topLeft = grid[0][0];
            if (topLeft != null && Enumerable.Range(0, grid.Length).All(i => grid[i][i] == topLeft)) {
                return topLeft;
            }
    
            // Check anti-diagonal (top-right to bottom-left)
            Player topRight = grid[0][grid[0].Length - 1];
            if (topRight != null && Enumerable.Range(0, grid.Length).All(i => grid[i][grid[0].Length - 1 - i] == topRight)) {
                return topRight;
            }
    
            // No winner found
            return null;
        }
    }

    // Checks if all positions on the board are filled
    public bool IsFull => grid.SelectMany(row => row).All(p => p != null);

    // Resets the board by clearing all positions
    public void Reset() {
        foreach (Player[] players in grid) {
            Array.Fill(players, null);
        }
    }

    // Returns a string representation of the current board state
    public string PrintBoard() {
        return "[" + string.Join(", ", grid.Select(row => "[" + string.Join(", ", row.Select(p => p?.ToString() ?? "null")) + "]")) + "]";
    }

    // Returns the player at the specified position, or null if empty
    public Player GetPlayerAt(int colIndex, int rowIndex) {
        return grid[colIndex][rowIndex];
    }
}
