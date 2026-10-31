namespace FileSearchSystem;

// Implements logical AND operation between multiple predicates
public class AndPredicate : ICompositePredicate {
    // List of predicates that must all match for this predicate to match
    private readonly List<IPredicate> operands;

    // Creates a new AND predicate with the specified predicates
    public AndPredicate(List<IPredicate> operands) {
        this.operands = operands;
    }

    // Checks if the given file matches ALL predicates
    public bool IsMatch(File inputFile) {
        return operands.All(predicate => predicate.IsMatch(inputFile));
    }
}
