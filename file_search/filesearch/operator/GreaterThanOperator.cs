namespace FileSearchSystem;

// Implements greater than comparison for numeric values
public class GreaterThanOperator<T> : IComparisonOperator<T> where T : System.Numerics.INumber<T> {
    public bool IsMatch(T attributeValue, T expectedValue) {
        return attributeValue > expectedValue;
    }
}
