namespace FileSearchSystem;

// Implements less than comparison for numeric values
public class LessThanOperator<T> : IComparisonOperator<T> where T : System.Numerics.INumber<T> {
    public bool IsMatch(T attributeValue, T expectedValue) {
        return attributeValue < expectedValue;
    }
}
