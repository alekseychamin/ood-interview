namespace FileSearchSystem;

// Wrapper class that encapsulates a search condition for file matching
public class FileSearchCriteria {
    // The predicate that defines what makes a file match
    private readonly IPredicate predicate;

    // Constructor that takes a predicate defining the criteria
    public FileSearchCriteria(IPredicate predicate) {
        this.predicate = predicate;
    }

    // Checks if the given file matches the search criteria
    public bool IsMatch(File inputFile) {
        return predicate.IsMatch(inputFile);
    }
}
