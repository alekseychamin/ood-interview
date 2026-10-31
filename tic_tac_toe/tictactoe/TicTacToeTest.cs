namespace TicTacToe;

// xUnit test ported from JUnit 5

public class TicTacToeTest {
    [Fact]
    public void TestPlay() {
        Console.WriteLine("\n=== Testing Tic-Tac-Toe Game System: Complete Game Play ===");
        
        Console.WriteLine("\n--- Creating Players ---");
        Player playerX = new Player("X", 'X');
        Player playerY = new Player("Y", 'Y');
        Console.WriteLine("✓ Created Player X (symbol: X)");
        Console.WriteLine("✓ Created Player Y (symbol: Y)");

        Console.WriteLine("\n--- Initializing Game ---");
        Game game = new Game(playerX, playerY);
        Console.WriteLine("✓ New tic-tac-toe game started");
        Assert.Equal(GameCondition.InProgress, game.GameStatus);
        Assert.Equal(playerX, game.CurrentPlayer);
        Console.WriteLine("✓ Game status: IN_PROGRESS");
        Console.WriteLine("✓ Current player: Player X (first to move)");

        Console.WriteLine("\n--- Making Game Moves ---");
        Console.WriteLine("✓ Player X moves at position (0,0) - Top-left corner");
        game.MakeMove(0,0, game.CurrentPlayer);
        Assert.Equal(playerY, game.CurrentPlayer);
        Console.WriteLine("✓ Turn switched to Player Y");

        Console.WriteLine("✓ Player Y moves at position (1,0) - Middle-left");
        game.MakeMove(1,0, game.CurrentPlayer);
        Console.WriteLine("✓ Player X moves at position (0,1) - Top-center");
        game.MakeMove(0,1, game.CurrentPlayer);
        Console.WriteLine("✓ Player Y moves at position (1,1) - Center");
        game.MakeMove(1,1, game.CurrentPlayer);
        Console.WriteLine("✓ Player X moves at position (0,2) - Top-right corner");
        game.MakeMove(0,2, game.CurrentPlayer);

        Console.WriteLine("\n--- Game Completion ---");
        Assert.Equal(GameCondition.Ended, game.GameStatus);
        Console.WriteLine("✓ Game status: ENDED");
        Console.WriteLine("✓ Player X wins with a horizontal line in the top row!");
        Console.WriteLine("✓ Final game board:");
        game.PrintGameState();

        Console.WriteLine("\n--- Score Tracking ---");
        ScoreTracker scoreTracker = game.ScoreTracker;
        Assert.Equal(1, scoreTracker.PlayerRatings[playerX]);
        Console.WriteLine("✓ Player X rating: " + scoreTracker.PlayerRatings[playerX] + " point");
        Console.WriteLine("✓ Player Y rating: " + scoreTracker.PlayerRatings[playerY] + " points");

        Assert.Equal(1, scoreTracker.GetRank(playerX));
        Assert.Equal(2, scoreTracker.GetRank(playerY));
        Assert.Equal(2, scoreTracker.TopPlayers.Count);
        Console.WriteLine("✓ Player rankings:");
        Console.WriteLine("  - Player X rank: " + scoreTracker.GetRank(playerX) + " (Winner)");
        Console.WriteLine("  - Player Y rank: " + scoreTracker.GetRank(playerY) + " (Runner-up)");
        Console.WriteLine("  - Total players tracked: " + scoreTracker.TopPlayers.Count);
        Console.WriteLine("=== Tic-Tac-Toe Game Test Completed Successfully ===\n");
    }

    [Fact]
    public void TestDuplicatePlay() {
        Console.WriteLine("\n=== Testing Tic-Tac-Toe: Duplicate Move Validation ===");
        
        Console.WriteLine("\n--- Setting Up Game ---");
        Player playerX = new Player("X", 'X');
        Player playerY = new Player("Y", 'Y');
        Game game = new Game(playerX, playerY);
        Console.WriteLine("✓ New game started with Player X and Player Y");

        Console.WriteLine("\n--- Making First Move ---");
        Console.WriteLine("✓ Player X moves at position (1,1) - Center");
        game.MakeMove(1,1, game.CurrentPlayer);
        Console.WriteLine("✓ Move successful - center position occupied");

        Console.WriteLine("\n--- Attempting Duplicate Move ---");
        Console.WriteLine("✓ Player Y attempts to move at position (1,1) - Already occupied");
        try {
            game.MakeMove(1,1, game.CurrentPlayer);
            Assert.Fail("didn't catch IllegalArgumentException");
        } catch (ArgumentException e) {
            Console.WriteLine("✓ Duplicate move correctly rejected:");
            Console.WriteLine("  - Expected behavior: Cannot place move on occupied position");
        }
        Console.WriteLine("=== Duplicate Move Test Completed Successfully ===\n");
    }
}
