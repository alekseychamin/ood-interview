namespace TicTacToe;

public class Game {
    // Core game components
    private readonly Board board;              // Manages the game board state
    private readonly ScoreTracker scoreTracker;// Keeps track of player scores
    private Player[] players;               // Array of players in the game
    private int currentPlayerIndex;         // Index of the current player's turn

    // Constructor initializes game components and starts a new game
    public Game(Player playerX, Player playerY) {
        board = new Board();
        scoreTracker = new ScoreTracker();
        StartNewGame(playerX, playerY);
    }

    // Resets the game state and initializes players for a new game
    public void StartNewGame(Player playerX, Player playerY) {
        board.Reset();
        players = new Player[]{playerX, playerY};
        currentPlayerIndex = 0;
    }

    // Processes a player's move, validates it, and updates game state
    public void MakeMove(int colIndex, int rowIndex, Player player) {
        // Validate that game hasn't ended
        if (GameStatus.Equals(GameCondition.Ended)) {
            throw new InvalidOperationException("game ended");
        }
        // Validate that it's the correct player's turn
        if (players[currentPlayerIndex] != player) {
            throw new ArgumentException("not the current player");
        }
        // Validate that the position is not already taken
        if(board.GetPlayerAt(colIndex, rowIndex) != null) {
            throw new ArgumentException("board position is taken");
        }
        // Update the board with the player's move
        board.UpdateBoard(colIndex, rowIndex, player);
        // Switch to the next player
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
        // If game has ended, update the score
        if (GameStatus.Equals(GameCondition.Ended)) {
            scoreTracker.ReportGameResult(players[0], players[1], board.Winner);
        }
    }

    // Determines if the game is in progress or has ended
    public GameCondition GameStatus
    {
        get
        {
            Player winner = board.Winner;
            if (winner != null) {
                return GameCondition.Ended;
            }
            return board.IsFull ? GameCondition.Ended : GameCondition.InProgress;
        }
    }

    // Returns a string representation of the current game state
    public string StateString => "Between players " + "[" + string.Join(", ", players) + "]" + ", state: " + GameStatus;

    // Returns the player whose turn it is
    public Player CurrentPlayer => players[currentPlayerIndex];

    // Prints the current state of the game for visualization
    public void PrintGameState() {
        // Printing Game State
        // Between players [Player1, Player2], state: IN_PROGRESS
        // Current Player: Player1
    }

    // Returns the score tracker for accessing game statistics
    public ScoreTracker ScoreTracker => scoreTracker;
}
