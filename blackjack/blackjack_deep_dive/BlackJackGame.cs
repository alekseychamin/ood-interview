namespace BlackJack.DeepDive;

// Represents a deep-dive version of the BlackJackGame for advanced logic
public class BlackJackGame {

    // ... fields unchanged ...

    // Finds the next eligible player who can take an action
    public IPlayer NextEligiblePlayer
    {
        get
        {
            // No current player: find first eligible player from the start
            if (currentPlayer == null) {
                foreach (IPlayer player in players) {
                    if (!Action.Stand.Equals(playerTurnStatusMap.GetValueOrDefault(player)) && !player.IsBust) {
                        currentPlayer = player;
                        return currentPlayer;
                    }
                }
                // Instead of calling dealerTurn(), check if the dealer can act
                if (!Action.Stand.Equals(playerTurnStatusMap.GetValueOrDefault(dealer))) {
                    currentPlayer = dealer;
                    return dealer;
                }
            } else {
                int currentIndex = players.IndexOf(currentPlayer);
                for (int i = currentIndex + 1; i < players.Count; i++) {
                    IPlayer player = players[i];
                    if (!Action.Stand.Equals(playerTurnStatusMap.GetValueOrDefault(player)) && !player.IsBust) {
                        currentPlayer = player;
                        return currentPlayer;
                    }
                }
                // If all players are done, check if the dealer can act
                if (currentPlayer != dealer && !Action.Stand.Equals(playerTurnStatusMap.GetValueOrDefault(dealer))) {
                    currentPlayer = dealer;
                    return dealer;
                }
            }
            return null;  // All turns are complete, including the dealer's
        }
    }


    // Executes the next turn by acting for the next player or dealer
    public void PlayNextTurn() {
        IPlayer nextPlayer = NextEligiblePlayer;
        if (nextPlayer != null) {
            PerformPlayerAction(nextPlayer);
        }
    }


    // Performs the action decided by the player's decision logic
    public void PerformPlayerAction(IPlayer player) {
        Action action = player.DecisionLogic.DecideAction(player.Hand);
        if (action == Action.Hit) {
            Hit(player);
        } else if (action == Action.Stand) {
            Stand(player);
        }
    }


    // ... other methods unchanged, dealerTurn() removed ...
}
