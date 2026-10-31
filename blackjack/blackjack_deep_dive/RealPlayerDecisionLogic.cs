namespace BlackJack.DeepDive;

// Implements decision logic for a real player in Blackjack
public class RealPlayerDecisionLogic : IPlayerDecisionLogic {
    // Decides whether the real player should hit or stand based on hand value
    public Action DecideAction(Hand hand) {
        return hand.PossibleValues.Last() < 16 ? Action.Hit : Action.Stand;
    }
}
