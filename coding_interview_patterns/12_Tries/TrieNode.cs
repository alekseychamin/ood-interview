// «Паттерны Coding Interview», глава 12: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Tries;

public class TrieNode {
    public Dictionary<char, TrieNode> Children = new();
    public bool IsWord = false;
}
