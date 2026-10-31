namespace FileSearchSystem;

// Implements logical NOT operation on a predicate
public class NotPredicate : ICompositePredicate {
    // The predicate to negate
    private readonly IPredicate operand;

    // Creates a new NOT predicate with the specified predicate to negate
    public NotPredicate(IPredicate operand) {
        this.operand = operand;
    }

    public bool IsMatch(File inputFile) {
        return !operand.IsMatch(inputFile);
    }
}
