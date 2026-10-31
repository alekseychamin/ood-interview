namespace BlackJack;

public class Deck {
    internal int nextCardIndex = 0;
    internal List<Card> cards;

    // Constructor initializes the deck
    public Deck() {
        InitializeDeck();
    }

    // Initializes the deck with all cards
    private void InitializeDeck() {
        cards = new();
        foreach (Suit suit in Enum.GetValues<Suit>()) {
            foreach (Rank rank in Enum.GetValues<Rank>()) {
                cards.Add(new Card(rank, suit));
            }
        }
        nextCardIndex = 0; // Reset to start drawing from the first card
    }

    // Shuffles the deck using current time as seed
    public void Shuffle() {
        new Random((int)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()).Shuffle(CollectionsMarshal.AsSpan(cards));
    }

    // Shuffles the deck using a provided seed
    public void Shuffle(long seed) {
        new Random((int)seed).Shuffle(CollectionsMarshal.AsSpan(cards));
    }

    // Draws the next card from the deck
    public Card Draw() {
        if (IsEmpty) return null;
        Card drawCard = cards[nextCardIndex];
        nextCardIndex++;
        return drawCard;
    }

    // Returns the number of remaining cards in the deck
    public int RemainingCardCount => cards.Count - nextCardIndex;

    // Checks if the deck is empty
    public bool IsEmpty => RemainingCardCount == 0;

    // Resets the deck to start drawing from the beginning
    public void Reset() {
        nextCardIndex = 0;
    }

    // Returns the list of cards in the deck
    public List<Card> Cards => cards;
}
