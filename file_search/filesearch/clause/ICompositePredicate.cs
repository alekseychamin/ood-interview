namespace FileSearchSystem;

public interface ICompositePredicate : IPredicate {
    // This interface is intentionally empty as it serves as a marker
    // to identify predicates that combine multiple other predicates (AND, OR, NOT)
}
