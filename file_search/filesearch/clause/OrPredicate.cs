namespace FileSearchSystem;

// Implements logical OR operation between multiple predicates
public class OrPredicate : ICompositePredicate {
    // List of predicates, at least one of which must match
    private readonly List<IPredicate> operands;

    // Creates a new OR predicate with the specified predicates
    public OrPredicate(List<IPredicate> operands) {
        this.operands = operands;
    }

    public bool IsMatch(File inputFile) {
        return operands.Any(predicate => predicate.IsMatch(inputFile));
    }
}
