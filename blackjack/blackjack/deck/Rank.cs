namespace BlackJack;

// Enum representing the rank of a playing card
public enum Rank {
    Ace,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King
}

// C# enums cannot carry data like Java enums, so the rank values
// are exposed through a C# 14 extension property: rank.RankValues
public static class RankExtensions {
    extension(Rank rank) {
        // Returns the possible values for the rank
        public int[] RankValues => rank switch {
            Rank.Ace => [1, 11],
            Rank.Two => [2],
            Rank.Three => [3],
            Rank.Four => [4],
            Rank.Five => [5],
            Rank.Six => [6],
            Rank.Seven => [7],
            Rank.Eight => [8],
            Rank.Nine => [9],
            _ => [10], // Ten, Jack, Queen, King
        };
    }
}
