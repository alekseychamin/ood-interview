namespace FileSearchSystem;

// Base interface for all file search predicates
public interface IPredicate {
    // Checks if the given file matches the search condition
    bool IsMatch(File inputFile);
}
