# Blackjack C# Project

This is a simple object-oriented Blackjack game implemented in C# (.NET 10). It includes a basic game engine, player classes, and comprehensive xUnit tests for the main game logic.

## Prerequisites


- .NET SDK 10.0 (C# 14)
- xUnit (restored automatically by `dotnet restore`)

## Project Structure

```
blackjack/
  Action.cs
  BlackJackGame.cs
  BlackJackGameTest.cs
  GamePhase.cs
  deck/
    Card.cs
    Deck.cs
    Rank.cs
    Suit.cs
  player/
    DealerPlayer.cs
    Hand.cs
    IPlayer.cs
    RealPlayer.cs
```

## Running the Tests

```bash
# From repository root
dotnet test blackjack/BlackJack.csproj
```

## Test Cases

The project includes several test cases that verify different aspects of the game:

1. `TestDealerWins`
   - Tests a scenario where the dealer wins against a player
   - Verifies correct balance updates when player loses

2. `TestTie`
   - Tests a scenario where the player and dealer tie
   - Verifies that the player's bet is returned

3. `TestPlayerStandsAndWins`
   - Tests a scenario where the player wins by standing
   - Verifies correct balance updates when player wins

4. `TestPlayerHitsAndWins`
   - Tests a scenario where the player wins after hitting
   - Verifies that players can hit and still win
   - Tests dealer busting scenario

5. `TestPlayerHitsAndBusts`
   - Tests a scenario where the player busts after hitting
   - Verifies correct balance updates when player busts

6. `TestMultiplePlayersAndMultipleHits`
   - Tests a scenario with multiple players
   - Verifies turn order and multiple hits
   - Tests game flow with multiple players against dealer

## Notes
- Built and tested with the .NET SDK (`dotnet test`).
- The test suite covers various game scenarios including:
  - Basic win/lose scenarios
  - Ties
  - Hitting and standing
  - Busting
  - Multiple players
  - Multiple hits
  - Balance updates
  - Dealer behavior
- To add more tests, create additional test methods in the `BlackJackGameTest` class.

## License
This project is for educational purposes.
