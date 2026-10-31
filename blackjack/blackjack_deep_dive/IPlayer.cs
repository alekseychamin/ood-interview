namespace BlackJack.DeepDive;

// Interface representing a player in the deepdive version of Blackjack
public interface IPlayer {
    // Returns the decision logic for the player
    IPlayerDecisionLogic DecisionLogic { get; }
    
    // Returns the player's hand
    Hand Hand { get; }
    
    // Returns true if the player has busted
    bool IsBust { get; }
    
    // Returns the player's name
    string Name { get; }
}
