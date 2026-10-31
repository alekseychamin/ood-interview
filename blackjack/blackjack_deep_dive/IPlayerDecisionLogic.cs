namespace BlackJack.DeepDive;

// Interface for player decision logic in the deepdive version
public interface IPlayerDecisionLogic {
    // Returns the action the player should take based on their hand
    Action DecideAction(Hand hand);
}
