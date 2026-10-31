namespace BlackJack;

public class BlackJackGame {
    private readonly Deck deck = new Deck();
    private readonly List<IPlayer> players = new();
    protected internal readonly IPlayer dealer = new DealerPlayer();
    private IPlayer currentPlayer = null;

    // Tracks the current status of each player's turn (e.g., HIT or STAND)
    internal Dictionary<IPlayer, Action?> playerTurnStatusMap = new();
    internal GamePhase currentPhase = GamePhase.Started;

    public BlackJackGame(List<IPlayer> players){
        foreach (IPlayer player in players) {
            if (player == null) throw new ArgumentException();
            this.players.Add(player);
            this.playerTurnStatusMap[player] = null;
        }
        this.playerTurnStatusMap[dealer] = null;
        deck.Shuffle();  // Shuffle the deck when game starts
    }

    // Determines the next player who can take an action (i.e., has not stood or bust). If the current player is the dealer, it triggers the dealer's turn.
    public IPlayer NextEligiblePlayer
    {
        get
        {
            // If current player hasn't stood or bust, they can continue their turn
            if (currentPlayer != null && 
                !Action.Stand.Equals(playerTurnStatusMap.GetValueOrDefault(currentPlayer)) && 
                !currentPlayer.IsBust) {
                return currentPlayer;
            }
    
            // Find the first player who hasn't stood or bust
            if (currentPlayer == null) {
                foreach (IPlayer player in players) {
                    if (!Action.Stand.Equals(playerTurnStatusMap.GetValueOrDefault(player)) && !player.IsBust) {
                        currentPlayer = player;
                        return currentPlayer;
                    }
                }
            }
    
            // else, find the next player after the current one who hasn't stood or bust
            int currentPlayerIndex = players.IndexOf(currentPlayer);
            for (int i = currentPlayerIndex + 1; i < players.Count; i++) {
                IPlayer player = players[i] ;
                if (!Action.Stand.Equals(playerTurnStatusMap.GetValueOrDefault(player)) && !player.IsBust) {
                    if (currentPlayer == dealer) {
                        if (!Action.Stand.Equals(playerTurnStatusMap.GetValueOrDefault(dealer)))
                            DealerTurn();
                        return currentPlayer;
                    }
                    currentPlayer = player;
                    return currentPlayer;
                }
            }
    
    
            // If no players are left to act, return null
            return null;
        }
    }

    protected internal void DealerTurn() {
        // Dealer hits if below 17
        while (dealer.Hand.PossibleValues.Max < 17) {
            Card newDraw = deck.Draw();
            dealer.Hand.AddCard(newDraw);
        }
        playerTurnStatusMap[dealer] = Action.Stand;
        CheckGameEndCondition();
    }

    public void StartNewRound() {
        deck.Reset();
        foreach (IPlayer player in playerTurnStatusMap.Keys) {
            player.Hand.Clear(); // Clear player's hand
        }
        dealer.Hand.Clear(); // Clear dealer's hand
        // Reset all turn statuses to null
        foreach (IPlayer p in playerTurnStatusMap.Keys.ToList()) {
            playerTurnStatusMap[p] = null;
        }
        currentPlayer = null; // Reset current player
        currentPhase = GamePhase.Started;
    }

    public void DealInitialCards() {
        if (!GamePhase.BetPlaced.Equals(currentPhase)) {
            throw new InvalidOperationException("All players must bet before dealing");
        }
        // Deal first card to each real player in order
        foreach (IPlayer player in players) {
            player.Hand.AddCard(deck.Draw());
        }
        // Deal first card to dealer
        dealer.Hand.AddCard(deck.Draw());
        // Deal second card to each real player in order
        foreach (IPlayer player in players) {
            player.Hand.AddCard(deck.Draw());
        }
        // Deal second card to dealer
        dealer.Hand.AddCard(deck.Draw());
        currentPhase = GamePhase.InitialCardDrawn;
    }

    public void Bet(IPlayer player, int bet) {
        if (!GamePhase.Started.Equals(currentPhase)) {
            throw new InvalidOperationException("Bets must be placed at the start of the round");
        }
        player.Bet(bet);
        // Transition to BET_PLACED once all players have bet
        if (players.Where(
                p => !(p is DealerPlayer)
        ).All(p => p.CurrentBet > 0)) {
            currentPhase = GamePhase.BetPlaced;
        }
    }

    public void Hit(IPlayer player) {
        if (Action.Stand.Equals(playerTurnStatusMap.GetValueOrDefault(player))) {
            throw new InvalidOperationException("Player has already stood");
        }
        if (player.IsBust) {
            throw new InvalidOperationException("Player is already bust");
        }

        Card drawnCard = deck.Draw();
        player.Hand.AddCard(drawnCard);
        playerTurnStatusMap[player] = Action.Hit;
    }

    public void Stand(IPlayer player) {
        if (Action.Stand.Equals(playerTurnStatusMap.GetValueOrDefault(player))) {
            throw new InvalidOperationException("Player has already stood");
        }
        if (player.IsBust) {
            throw new InvalidOperationException("Player is already bust");
        }
        playerTurnStatusMap[player] = Action.Stand;
    }

    /**
     * Checks if the game has ended (all players done), then resolves bets by comparing each player's hand to the dealer's.
     */
    private void CheckGameEndCondition() {
        bool allPlayersDone = players
                .All(p => Action.Stand.Equals(playerTurnStatusMap.GetValueOrDefault(p)) || p.IsBust);
        if (!allPlayersDone) {
            return;
        }

        int dealerValue = dealer.Hand.PossibleValues.Max;
        bool dealerBusts = dealer.IsBust;

        foreach (IPlayer player in players) {
            if (player.IsBust) {
                player.LoseBet();
            } else {
                int playerValue = player.Hand.PossibleValues.Max;
                if (dealerBusts || playerValue > dealerValue) {
                    player.Payout();
                } else if (playerValue == dealerValue) {
                    player.ReturnBet();
                } else {
                    player.LoseBet();
                }
            }
        }
        currentPhase = GamePhase.End;
    }

    public string StateString
    {
        get
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (IPlayer player in playerTurnStatusMap.Keys) {
                stringBuilder
                        .Append(player.Name).Append(": ")
                        .Append(player.Hand.ToString()).Append(", ")
                        .Append(playerTurnStatusMap.GetValueOrDefault(player))
                        .Append("\n");
            }
            return stringBuilder.ToString();
        }
    }

    protected Deck Deck => deck;

    public IPlayer CurrentTurnPlayer => currentPlayer;
}
