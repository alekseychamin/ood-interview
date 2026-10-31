# Tic Tac Toe Game

A simple implementation of the classic Tic Tac Toe game in C# (.NET 10).

## Project Structure

```
tictactoe/
├── Board.cs
├── Game.cs
├── GameCondition.cs
├── Move.cs
├── MoveHistory.cs
├── Player.cs
├── ScoreTracker.cs
└── TicTacToeTest.cs
```

## Prerequisites


- .NET SDK 10.0 (C# 14)
- xUnit (restored automatically by `dotnet restore`)

## Running the Tests

```bash
# From repository root
dotnet test tic_tac_toe/TicTacToe.csproj
```

## Game Rules

1. The game is played on a 3x3 grid
2. Players take turns placing their marks (X or O) in empty cells
3. The first player to get 3 of their marks in a row (horizontally, vertically, or diagonally) wins
4. If all cells are filled and no player has won, the game is a draw

## Features

- Two-player gameplay
- Score tracking
- Move history
- Input validation
- Game state tracking

## Class Diagram

The game follows a simple object-oriented design with the following main classes:
- `Game`: Main game controller
- `Board`: Manages the game board state
- `Player`: Represents a player with name and symbol
- `Move`: Represents a player's move
- `ScoreTracker`: Tracks player scores
- `MoveHistory`: Keeps track of game moves

## License

This project is open source and available under the MIT License.
