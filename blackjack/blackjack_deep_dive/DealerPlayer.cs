namespace BlackJack.DeepDive;

// Represents the dealer player in the deepdive version of Blackjack
public class DealerPlayer : IPlayer {
    private readonly IPlayerDecisionLogic decisionLogic;

    // Constructor for DealerPlayer
    public DealerPlayer() {
        this.hand = new Hand();
        this.decisionLogic = new DealerDecisionLogic();
    }

    // Returns the decision logic for the dealer
    public IPlayerDecisionLogic DecisionLogic => decisionLogic;
    // ... other methods ...
}
