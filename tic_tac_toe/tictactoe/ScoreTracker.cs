namespace TicTacToe;

public class ScoreTracker {
    // Stores player ratings in a map where key is player and value is their score
    private Dictionary<Player, int> playerRatings = new();

    // Updates player ratings based on game outcome
    // Winner gets +1 point, loser gets -1 point, no change for draw
    // This logic is customizable and, in reality, will use a complex ranking algorithm. For the interview, we use a simple victory count system where the winner gets one point, the loser loses a point, and no changes occur for a draw.
    public void ReportGameResult(Player player1, Player player2, Player winningPlayer) {
        if (winningPlayer != null) 
        {
            Player winner = winningPlayer;
            Player loser = player1 == winner ? player2 : player1;
            playerRatings.TryAdd(winner, 0);
            playerRatings[winner] = playerRatings.GetValueOrDefault(winner) + 1;
            playerRatings.TryAdd(loser, 0);
            playerRatings[loser] = playerRatings.GetValueOrDefault(loser) - 1;
        }
    }

    // Returns a list of players sorted by their ratings in descending order
    public List<Player> TopPlayers
    {
        get
        {
            return playerRatings
                .OrderByDescending(entry => entry.Value)
                .Select(entry => entry.Key)
                .ToList();
        }
    }

    // Returns the rank of a player (1-based) based on their rating
    public int GetRank(Player player) 
    {
        List<Player> sortedPlayers = playerRatings
                .OrderByDescending(entry => entry.Value)
                .Select(entry => entry.Key)
                .ToList();
        return sortedPlayers.IndexOf(player) + 1;
    }

    // Returns the complete map of player ratings
    public Dictionary<Player, int> PlayerRatings => playerRatings;
}
