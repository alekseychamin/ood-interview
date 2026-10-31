namespace TicTacToe.DeepDive;

public class MoveHistory {
    // Stack-like structure to store moves in chronological order
    private readonly Stack<Move> history = new();

    // Adds a new move to the history stack
    public void RecordMove(Move move) {
        history.Push(move);
    }

    // Removes and returns the most recent move from the history
    public Move UndoMove() {
        return history.Pop();
    }

    // Clears all moves from the history
    public void ClearHistory() {
        history.Clear();
    }
}
