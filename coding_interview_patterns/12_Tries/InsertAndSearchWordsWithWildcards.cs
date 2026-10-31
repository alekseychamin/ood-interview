// «Паттерны Coding Interview», глава 12: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Tries;

public class InsertAndSearchWordsWithWildcards {
    private readonly TrieNode root = new TrieNode();

    public void Insert(string word) {
        TrieNode node = root;
        foreach (char c in word) {
            if (!node.Children.ContainsKey(c)) {
                node.Children[c] = new TrieNode();
            }
            node = node.Children[c];
        }
        node.IsWord = true;
    }

    public bool Search(string word) {
        // Начинаем поиск с корня префиксного дерева.
        return SearchHelper(0, word, root);
    }

    private bool SearchHelper(int wordIndex, string word, TrieNode node) {
        for (int i = wordIndex; i < word.Length; i++) {
            char c = word[i];
            // Если встречается подстановочный символ, рекурсивно
            // ищем оставшуюся часть слова во всех потомках.
            if (c == '.') {
                foreach (TrieNode child in node.Children.Values) {
                    // Если найдено совпадение, возвращаем
                    // true.
                    if (SearchHelper(i + 1, word, child)) {
                        return true;
                    }
                }
                return false;
            } else if (node.Children.TryGetValue(c, out TrieNode next)) {
                node = next;
            } else {
                return false;
            }
        }
        // После обработки последнего символа возвращаем true,
        // если достигнут конец слова.
        return node.IsWord;
    }
}
