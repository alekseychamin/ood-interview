namespace FileSearchSystem;

// Implements regular expression pattern matching for string values
// (string is sealed in C#, so the operator is not generic as in the Java version)
public class RegexMatchOperator : IComparisonOperator<string> {
    public bool IsMatch(string attributeValue, string expectedValue) {
        // Java's Matcher.matches() requires the whole input to match the pattern
        return Regex.IsMatch(attributeValue, "^(?:" + expectedValue + ")$");
    }
}
