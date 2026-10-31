namespace BlackJack;

// Represents the dealer in the Blackjack game
public class DealerPlayer : IPlayer {
    private readonly string name = "Dealer";
    private readonly Hand hand;

    // Constructor for DealerPlayer
    public DealerPlayer() {
        this.hand = new Hand();
    }

    // Dealer does not bet, so this method is empty
    public void Bet(int bet) {
        // Dealer does not bet, so this method is empty
    }

    // Dealer does not lose bets, so this method is empty
    public void LoseBet() {
        // Dealer does not lose bets, so this method is empty
    }

    // Dealer does not return bets, so this method is empty
    public void ReturnBet() {
        // Dealer does not return bets, so this method is empty
    }

    // Dealer does not get a payout, so this method only prints the winning hand
    public void Payout() {
        // Player won with card value
    }

    // Checks if the dealer is bust
    public bool IsBust => hand.IsBust;

    // Returns the dealer's hand
    public Hand Hand => hand;

    // Returns the dealer's balance (always 0)
    public int Balance => 0;

    // Returns the dealer's name
    public string Name => name;

    // Returns the dealer's bet (always 0)
    public int CurrentBet => 0;
}
