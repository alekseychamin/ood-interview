namespace BlackJack;

// Represents a real player in the Blackjack game
public class RealPlayer : IPlayer {
    private readonly string name;
    private readonly Hand hand;
    private int bet;
    private int balance;

    // Constructor for RealPlayer
    public RealPlayer(string name, int startBalance) {
        this.name = name;
        this.hand = new Hand();
        this.bet = 0;
        this.balance = startBalance;
    }

    // Places a bet for the player
    public void Bet(int bet) {
        if(bet > balance) {
            throw new ArgumentException("Bet is greater than balance");
        }
        this.bet = bet;
        this.balance -= bet;
    }

    // Handles the player losing a bet
    public void LoseBet() {
        this.bet = 0;
    }

    // Handles returning the player's bet
    public void ReturnBet() {
        this.balance += bet;
        this.bet = 0;
    }

    // Handles the player winning a payout
    public void Payout() {
        this.balance += bet * 2;  // Return bet plus equal amount
        this.bet = 0;
    }

    // Checks if the player is bust
    public bool IsBust => hand.IsBust;

    // Returns the player's hand
    public Hand Hand => hand;

    // Returns the player's balance
    public int Balance => balance;

    // Returns the player's name
    public string Name => name;

    // Returns the player's current bet
    public int CurrentBet => bet;

    // getter methods are omitted for brevity
}
