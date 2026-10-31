// «Паттерны Coding Interview», глава 12: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Tries;

public static class FindAllWordsOnABoardSolution {
    public class TrieNode {
        public Dictionary<char, TrieNode> Children = new();
        public string Word = null;
    }

    public static List<string> FindAllWordsOnABoard(char[][] board, string[] words) {
        TrieNode root = new TrieNode();
        // Вставляем каждое слово в префиксное дерево.
        foreach (string word in words) {
            TrieNode node = root;
            foreach (char ch in word) {
                if (!node.Children.ContainsKey(ch)) {
                    node.Children[ch] = new TrieNode();
                }
                node = node.Children[ch];
            }
            node.Word = word;
        }
        var res = new List<string>();
        // Запускаем обход в глубину из каждой ячейки доски,
        // соответствующей дочернему узлу корня.
        for (int r = 0; r < board.Length; r++) {
            for (int c = 0; c < board[0].Length; c++) {
                if (root.Children.ContainsKey(board[r][c])) {
                    Dfs(board, r, c, root.Children[board[r][c]], res);
                }
            }
        }
        return res;
    }

    private static void Dfs(char[][] board, int r, int c,
                            TrieNode node, List<string> res) {
        // Если текущий узел — конец слова, добавляем слово в
        // результат.
        if (node.Word != null) {
            res.Add(node.Word);
            // Обеспечиваем добавление слова только один раз.
            node.Word = null;
        }
        char temp = board[r][c];
        // Отмечаем текущую ячейку как посещенную.
        board[r][c] = '#';
        // Исследуем все смежные ячейки, соответствующие дочерним
        // узлам текущего узла.
        (int, int)[] dirs = [(-1, 0), (1, 0), (0, -1), (0, 1)];
        foreach (var (dr, dc) in dirs) {
            int nextR = r + dr, nextC = c + dc;
            if (IsWithinBounds(nextR, nextC, board)
                && node.Children.ContainsKey(board[nextR][nextC])) {
                Dfs(
                    board, nextR, nextC,
                    node.Children[board[nextR][nextC]],
                    res
                );
            }
        }
        // Возврат назад — восстанавливаем исходный символ ячейки.
        board[r][c] = temp;
    }

    private static bool IsWithinBounds(int r, int c, char[][] board) {
        return 0 <= r && r < board.Length && 0 <= c && c < board[0].Length;
    }
}
