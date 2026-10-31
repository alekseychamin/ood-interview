namespace BlackJack;

// Represents a player's hand in Blackjack
public class Hand {
    internal List<Card> handCards = new();

    /** Sorted set of all possible hand values, accounting for Ace flexibility (1 or 11). */
    internal SortedSet<int> possibleValues = new();

    // Constructor for Hand
    public Hand() {
    }

    /**
     * Adds a card to the hand and updates the set of possible total values.
     * For Aces (1 or 11), computes all combinations with existing totals; for other cards, adds their value to each total.
     */
    public void AddCard(Card card) {
        if (card == null) {
            throw new ArgumentException("Cannot add null card to hand");
        }
        handCards.Add(card);

        // card.getRankValues() returns [1, 11] for Aces or a single value (e.g., [10]) for others. 
        if (possibleValues.Count == 0) {
            // Initialize with the card's values
            foreach (int value in card.RankValues) {
                possibleValues.Add(value);
            }
        } else {
            // Add all possible card values to each existing total
            SortedSet<int> newPossibleValue = new();
            foreach (int value in possibleValues) {
                foreach (int cardValue in card.RankValues) {
                    newPossibleValue.Add(value + cardValue);
                }
            }
            possibleValues.Clear();
            possibleValues.UnionWith(newPossibleValue);
        }
    }

    // Returns an unmodifiable list of cards in the hand
    public List<Card> Cards => new(handCards);

    // Returns an unmodifiable sorted set of possible hand values
    public SortedSet<int> PossibleValues => new(possibleValues);

    // Clears the hand and possible values
    public void Clear() {
        handCards.Clear();
        possibleValues.Clear();
    }

    // Returns a string representation of the hand
    public override string ToString() {
        return "Hand{" +
                "handCards=[" + string.Join(", ", handCards) + "]" +
                ", possibleValue=[" + string.Join(", ", possibleValues) + "]" +
                '}';
    }

    // Checks if the hand is bust (all possible values > 21)
    public bool IsBust
    {
        get
        {
            // check if all possible value of the player's hand is busted
            if (possibleValues.Count == 0) {
                return false;
            }
            else {
                return possibleValues.Min > 21;
            }
        }
    }
}
