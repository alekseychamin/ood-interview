namespace BlackJack;

// Interface representing a player in Blackjack
public interface IPlayer {
    // Places a bet for the player
    void Bet(int bet);

    // Handles the player losing a bet
    void LoseBet();

    // Handles returning the player's bet
    void ReturnBet();

    // Handles the player winning a payout
    void Payout();

    // Checks if the player is bust
    bool IsBust { get; }

    // Returns the player's hand
    Hand Hand { get; }

    // Returns the player's balance
    int Balance { get; }

    // Returns the player's name
    string Name { get; }

    // Returns the player's current bet
    int CurrentBet { get; }
}
