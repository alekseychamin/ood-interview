namespace BlackJack.DeepDive;

// Implements decision logic for the dealer in Blackjack
public class DealerDecisionLogic : IPlayerDecisionLogic {
    // Decides whether the dealer should hit or stand based on hand value
    public Action DecideAction(Hand hand) {
        return hand.PossibleValues.Last() < 17 ? Action.Hit : Action.Stand;
    }
}
