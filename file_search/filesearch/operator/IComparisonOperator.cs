namespace FileSearchSystem;

// Base interface for all comparison operations in the file search system
public interface IComparisonOperator<T> {
    bool IsMatch(T attributeValue, T expectedValue);
}
