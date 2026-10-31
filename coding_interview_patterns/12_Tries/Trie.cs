// «Паттерны Coding Interview», глава 12: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Tries;

public class Trie {
    private readonly TrieNode root = new TrieNode();

    public void Insert(string word) {
        TrieNode node = root;
        foreach (char c in word) {
            // Для каждого символа, если его нет среди
            // потомков текущего узла, создаем новый узел
            // префиксного дерева.
            if (!node.Children.ContainsKey(c)) {
                node.Children[c] = new TrieNode();
            }
            node = node.Children[c];
        }
        // Отмечаем последний узел как конец слова.
        node.IsWord = true;
    }

    public bool Search(string word) {
        TrieNode node = root;
        foreach (char c in word) {
            // Если символа нет среди
            // потомков текущего узла, значит, и слова нет в
            // префиксном дереве.
            if (!node.Children.ContainsKey(c)) {
                return false;
            }
            node = node.Children[c];
        }
        // Возвращаем, отмечен ли текущий узел как конец
        // слова.
        return node.IsWord;
    }

    public bool HasPrefix(string prefix) {
        TrieNode node = root;
        foreach (char c in prefix) {
            if (!node.Children.ContainsKey(c)) {
                return false;
            }
            node = node.Children[c];
        }
        // После обхода узлов, соответствующих каждому символу
        // префикса, возвращаем true.
        return true;
    }
}
