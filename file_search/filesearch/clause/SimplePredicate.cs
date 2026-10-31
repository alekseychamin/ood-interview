namespace FileSearchSystem;

// Represents a basic predicate that compares a file attribute with an expected value
public class SimplePredicate<T> : IPredicate {
    // The name of the file attribute to check
    private readonly FileAttribute attributeName;
    // The operator to use for comparison (equals, contains, greater than, etc.)
    private readonly IComparisonOperator<T> comparisonOperator;
    // The expected value to compare against
    internal T expectedValue;

    // Creates a new simple predicate with the specified attribute, operator, and
    // expected value
    public SimplePredicate(
            FileAttribute attributeName,
            IComparisonOperator<T> comparisonOperator,
            T expectedValue) {
        this.attributeName = attributeName;
        this.comparisonOperator = comparisonOperator;
        this.expectedValue = expectedValue;
    }

    public bool IsMatch(File inputFile) {
        // Extract the actual value of the attribute from the file
        object actualValue = inputFile.Extract(attributeName);
        // Check if the actual value is of the correct type
        if (actualValue is T typedValue) {
            // Perform the comparison using the specified operator
            return comparisonOperator.IsMatch(typedValue, expectedValue);
        } else {
            return false;
        }
    }
}
