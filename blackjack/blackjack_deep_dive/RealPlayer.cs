namespace BlackJack.DeepDive;

// Represents a real player in the deepdive version of Blackjack
public class RealPlayer : IPlayer {
    private readonly IPlayerDecisionLogic decisionLogic;

    // Constructor for RealPlayer
    public RealPlayer(string name, int startBalance) {
        this.name = name;
        this.hand = new Hand();
        this.bet = 0;
        this.balance = startBalance;
        this.decisionLogic = new RealPlayerDecisionLogic();
    }

    // Returns the decision logic for the player
    public IPlayerDecisionLogic DecisionLogic => decisionLogic;
    // ... other methods ...
}
