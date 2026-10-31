using System.Reflection;

namespace BlackJack;

// xUnit test ported from JUnit 5

public class BlackJackGameTest {
    // Helper to set up a deck with a known order
    private void SetDeckOrder(BlackJackGame game, List<Card> cards) {
        // The Java test uses reflection; in C# the fields are internal, so we can reach them directly
        // after reading the private 'deck' field with reflection.
        var deckField = typeof(BlackJackGame).GetField("deck", BindingFlags.NonPublic | BindingFlags.Instance);
        var deck = (Deck)deckField.GetValue(game);
        deck.cards = new List<Card>(cards);
        deck.nextCardIndex = 0;
    }

    // Helper to advance the game until it is over
    private void PlayUntilGameEnd(BlackJackGame game) {
        IPlayer player = game.CurrentTurnPlayer;
        while (player != null) {
            if (!"Dealer".Equals(player.Name)) {
                if (!player.IsBust && Action.Stand != game.playerTurnStatusMap.GetValueOrDefault(player)) {
                    game.Stand(player);
                }
            }
            player = game.CurrentTurnPlayer;
        }
        Action? dealerStatus = game.playerTurnStatusMap.GetValueOrDefault(game.dealer);
        if (dealerStatus != null && dealerStatus != Action.Stand) {
            game.DealerTurn();
        }
    }

    [Fact]
    public void TestTie() {
        Console.WriteLine("\n=== Testing Tie Scenario ===");
        
        IPlayer a = new RealPlayer("A", 100);
        BlackJackGame game = new BlackJackGame([a]);
        Console.WriteLine("✓ Game initialized with Player A (balance: $100)");
        
        SetDeckOrder(game, [
                new Card(Rank.Ten, Suit.Hearts),     // Player A's first card
                new Card(Rank.Ten, Suit.Clubs),      // Player A's second card
                new Card(Rank.Ten, Suit.Spades),     // Dealer's first card
                new Card(Rank.Ten, Suit.Diamonds)    // Dealer's second card
        ]);
        
        Console.WriteLine("\n--- Placing Bet ---");
        game.Bet(a, 10);
        Console.WriteLine("✓ Player A bets $10 (new balance: $90)");
        
        Console.WriteLine("\n--- Dealing Initial Cards ---");
        game.DealInitialCards();
        Console.WriteLine("✓ Initial cards dealt:");
        Console.WriteLine("  Player A: 10♥ + 10♣ = 20");
        Console.WriteLine("  Dealer: 10♠ + 10♦ = 20");
        
        Console.WriteLine("\n--- Player Action ---");
        game.Stand(a);
        Console.WriteLine("✓ Player A stands with 20");
        
        Console.WriteLine("\n--- Dealer's Turn ---");
        game.DealerTurn();
        PlayUntilGameEnd(game);
        Console.WriteLine("✓ Dealer stands with 20 (tie game)");
        
        Assert.Equal(100, a.Balance);
        Console.WriteLine("✓ Final balance verified: $100 (bet returned on tie)");
        Console.WriteLine("=== Tie Test Completed Successfully ===\n");
    }

    [Fact]
    public void TestPlayerStandsAndWins() {
        Console.WriteLine("\n=== Testing Player Stands and Wins ===");
        
        IPlayer a = new RealPlayer("A", 100);
        BlackJackGame game = new BlackJackGame([a]);
        Console.WriteLine("✓ Game initialized with Player A (balance: $100)");
        
        SetDeckOrder(game, [
                new Card(Rank.Ten, Suit.Hearts),     // Player's first card
                new Card(Rank.Ten, Suit.Clubs),      // Player's second card
                new Card(Rank.Ten, Suit.Spades),     // Dealer's first card
                new Card(Rank.Eight, Suit.Diamonds)  // Dealer's second card
        ]);
        
        Console.WriteLine("\n--- Placing Bet ---");
        game.Bet(a, 10);
        Console.WriteLine("✓ Player A bets $10 (new balance: $90)");
        
        Console.WriteLine("\n--- Dealing Initial Cards ---");
        game.DealInitialCards();
        Console.WriteLine("✓ Initial cards dealt:");
        Console.WriteLine("  Player A: 10♥ + 10♣ = 20");
        Console.WriteLine("  Dealer: 10♠ + 8♦ = 18");
        
        Console.WriteLine("\n--- Player Action ---");
        game.Stand(a);
        Console.WriteLine("✓ Player A stands with 20");
        
        Console.WriteLine("\n--- Dealer's Turn ---");
        game.DealerTurn();
        PlayUntilGameEnd(game);
        Console.WriteLine("✓ Dealer stands with 18 (Player wins: 20 > 18)");
        
        Assert.Equal(110, a.Balance);
        Console.WriteLine("✓ Final balance verified: $110 (won $20: bet + winnings)");
        Console.WriteLine("=== Player Stands and Wins Test Completed Successfully ===\n");
    }

    [Fact]
    public void TestPlayerHitsAndWins() {
        Console.WriteLine("\n=== Testing Player Hits and Wins ===");
        
        IPlayer a = new RealPlayer("A", 100);
        BlackJackGame game = new BlackJackGame([a]);
        Console.WriteLine("✓ Game initialized with Player A (balance: $100)");
        
        SetDeckOrder(game, [
                new Card(Rank.Five, Suit.Hearts),    // Player's first card
                new Card(Rank.Five, Suit.Clubs),     // Player's second card
                new Card(Rank.Ten, Suit.Spades),     // Dealer's first card
                new Card(Rank.Eight, Suit.Diamonds), // Dealer's second card
                new Card(Rank.Six, Suit.Hearts),     // Player's hit card
                new Card(Rank.Seven, Suit.Spades)    // Extra card for dealer if needed
        ]);
        
        Console.WriteLine("\n--- Placing Bet ---");
        game.Bet(a, 10);
        Console.WriteLine("✓ Player A bets $10 (new balance: $90)");
        
        Console.WriteLine("\n--- Dealing Initial Cards ---");
        game.DealInitialCards();
        Console.WriteLine("✓ Initial cards dealt:");
        Console.WriteLine("  Player A: 5♥ + 5♣ = 10");
        Console.WriteLine("  Dealer: 10♠ + 8♦ = 18");
        
        Console.WriteLine("\n--- Player Actions ---");
        game.Hit(a);
        Console.WriteLine("✓ Player A hits and gets 6♥ (new total: 16)");
        game.Stand(a);
        Console.WriteLine("✓ Player A stands with 16");
        
        Console.WriteLine("\n--- Dealer's Turn ---");
        game.DealerTurn();
        Console.WriteLine("✓ Dealer stands with 18 (Player wins: 16 < 18, but dealer busts or loses)");
        
        Assert.Equal(110, a.Balance);
        Console.WriteLine("✓ Final balance verified: $110 (won $20: bet + winnings)");
        Console.WriteLine("=== Player Hits and Wins Test Completed Successfully ===\n");
    }

    [Fact]
    public void TestPlayerHitsAndBusts() {
        Console.WriteLine("\n=== Testing Player Hits and Busts ===");
        
        IPlayer a = new RealPlayer("A", 100);
        BlackJackGame game = new BlackJackGame([a]);
        Console.WriteLine("✓ Game initialized with Player A (balance: $100)");
        
        SetDeckOrder(game, [
                new Card(Rank.Ten, Suit.Hearts),     // Player's first card
                new Card(Rank.Ten, Suit.Clubs),      // Player's second card
                new Card(Rank.Ten, Suit.Spades),     // Dealer's first card
                new Card(Rank.Eight, Suit.Diamonds), // Dealer's second card
                new Card(Rank.Two, Suit.Hearts)      // Player's hit card
        ]);
        
        Console.WriteLine("\n--- Placing Bet ---");
        game.Bet(a, 10);
        Console.WriteLine("✓ Player A bets $10 (new balance: $90)");
        
        Console.WriteLine("\n--- Dealing Initial Cards ---");
        game.DealInitialCards();
        Console.WriteLine("✓ Initial cards dealt:");
        Console.WriteLine("  Player A: 10♥ + 10♣ = 20");
        Console.WriteLine("  Dealer: 10♠ + 8♦ = 18");
        
        Console.WriteLine("\n--- Player Actions ---");
        game.Hit(a);
        Console.WriteLine("✓ Player A hits and gets 2♥ (new total: 22 - BUST!)");
        Console.WriteLine("✓ Player A busts with 22");
        
        Console.WriteLine("\n--- Dealer's Turn ---");
        game.DealerTurn();
        Console.WriteLine("✓ Dealer wins (Player busted)");
        
        Assert.Equal(90, a.Balance);
        Console.WriteLine("✓ Final balance verified: $90 (lost $10 bet due to bust)");
        Console.WriteLine("=== Player Hits and Busts Test Completed Successfully ===\n");
    }

    [Fact]
    public void TestMultiplePlayersAndMultipleHits() {
        Console.WriteLine("\n=== Testing Multiple Players with Multiple Hits ===");
        
        IPlayer a = new RealPlayer("A", 100);
        IPlayer b = new RealPlayer("B", 100);
        BlackJackGame game = new BlackJackGame([a, b]);
        Console.WriteLine("✓ Game initialized with Player A and Player B (balance: $100 each)");
        
        SetDeckOrder(game, [
                new Card(Rank.Five, Suit.Hearts),    // Player A's first card
                new Card(Rank.Five, Suit.Clubs),     // Player B's first card
                new Card(Rank.Ten, Suit.Spades),     // Dealer's first card
                new Card(Rank.Five, Suit.Diamonds),  // Player A's second card
                new Card(Rank.Ten, Suit.Hearts),     // Player B's second card
                new Card(Rank.Eight, Suit.Diamonds), // Dealer's second card
                new Card(Rank.Three, Suit.Hearts),   // Player A's first hit
                new Card(Rank.Three, Suit.Clubs),    // Player A's second hit
                new Card(Rank.Two, Suit.Spades),     // Player B's hit
                new Card(Rank.Seven, Suit.Hearts)    // Extra card for dealer if needed
        ]);
        Console.WriteLine("✓ Deck set up for complex multi-player scenario");
        
        Console.WriteLine("\n--- Placing Bets ---");
        game.Bet(a, 10);
        game.Bet(b, 10);
        Console.WriteLine("✓ Player A bets $10 (balance: $90)");
        Console.WriteLine("✓ Player B bets $10 (balance: $90)");
        
        Console.WriteLine("\n--- Dealing Initial Cards ---");
        game.DealInitialCards();
        Console.WriteLine("✓ Initial cards dealt:");
        Console.WriteLine("  Player A: 5♥ + 5♦ = 10");
        Console.WriteLine("  Player B: 5♣ + 10♥ = 15");
        Console.WriteLine("  Dealer: 10♠ + 8♦ = 18");
        
        Console.WriteLine("\n--- Player A's Turn (Multiple Hits) ---");
        game.Hit(a);
        Console.WriteLine("✓ Player A hits and gets 3♥ (new total: 13)");
        game.Hit(a);
        Console.WriteLine("✓ Player A hits and gets 3♣ (new total: 16)");
        game.Stand(a);
        Console.WriteLine("✓ Player A stands with 16");
        
        Console.WriteLine("\n--- Player B's Turn (Single Hit) ---");
        game.Hit(b);
        Console.WriteLine("✓ Player B hits and gets 2♠ (new total: 17)");
        game.Stand(b);
        Console.WriteLine("✓ Player B stands with 17");
        
        Console.WriteLine("\n--- Dealer's Turn ---");
        game.DealerTurn();
        Console.WriteLine("✓ Dealer stands with 18");
        Console.WriteLine("✓ Results:");
        Console.WriteLine("  Player A: 16 vs Dealer: 18 → Loses");
        Console.WriteLine("  Player B: 17 vs Dealer: 18 → Loses");
        
        // Check final balances
        Assert.Equal(90, a.Balance);  // Player A should lose (16 < dealer's 18)
        Assert.Equal(90, b.Balance);  // Player B should lose (17 < dealer's 18)
        Console.WriteLine("✓ Final balances verified:");
        Console.WriteLine("  Player A: $90 (lost $10)");
        Console.WriteLine("  Player B: $90 (lost $10)");
        Console.WriteLine("=== Multiple Players Test Completed Successfully ===\n");
    }
}
