namespace FileSearchSystem;

// Implements exact equality comparison between values
public class EqualsOperator<T> : IComparisonOperator<T> {
    public bool IsMatch(T attributeValue, T expectedValue) {
        return Equals(attributeValue, expectedValue);
    }
}
