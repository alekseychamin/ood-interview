// «Паттерны Coding Interview», глава 11: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Trees;

public static class BalancedBinaryTreeValidationSolution {
    public static bool BalancedBinaryTreeValidation(TreeNode root) {
        return GetHeightImbalance(root) != -1;
    }

    private static int GetHeightImbalance(TreeNode node) {
        // Базовый случай: если узел пустой, его высота равна 0.
        if (node == null) {
            return 0;
        }
        // Рекурсивно получаем высоту левого и правого
        // поддеревьев. Если одно из них несбалансировано,
        // передаем -1 вверх по дереву.
        int leftHeight = GetHeightImbalance(node.Left);
        int rightHeight = GetHeightImbalance(node.Right);
        if (leftHeight == -1 || rightHeight == -1) {
            return -1;
        }
        // Если поддерево текущего узла несбалансировано
        // (разница высот > 1), возвращаем -1.
        if (Math.Abs(leftHeight - rightHeight) > 1) {
            return -1;
        }
        // Возвращаем высоту текущего поддерева.
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
