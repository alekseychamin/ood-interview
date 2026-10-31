namespace BlackJack;

// Represents a playing card with a rank and suit
public class Card {
    public readonly Rank rank;
    public readonly Suit suit;

    // Constructor for Card
    public Card(Rank rank, Suit suit) {
        this.rank = rank;
        this.suit = suit;
    }
 
    // Returns the possible values for the card's rank
    public int[] RankValues => rank.RankValues;

    // Returns a string representation of the card
    public override string ToString() {
        return "Card{" + "rank=" + rank + ", suit=" + suit + '}';
    }
}
