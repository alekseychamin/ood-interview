// «Паттерны Coding Interview», глава 11: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Trees;

public static class BinarySearchTreeValidationSolution {
    public static bool BinarySearchTreeValidation(TreeNode root) {
        // Начинаем проверку с корневого узла. Он может
        // содержать любое значение, поэтому начальные нижнюю и
        // верхнюю границы устанавливаем в -∞ и +∞ соответственно.
        return IsWithinBounds(root, long.MinValue, long.MaxValue);
    }

    private static bool IsWithinBounds(TreeNode node, long lowerBound,
                                       long upperBound) {
        // Базовый случай: если узел пустой, он удовлетворяет
        // условию BST.
        if (node == null) {
            return true;
        }
        // Если значение текущего узла не находится в допустимых
        // пределах, дерево не является корректным BST.
        if (!(lowerBound < node.Val && node.Val < upperBound)) {
            return false;
        }
        // Если левое поддерево не является BST, то и все дерево
        // не является BST.
        if (!IsWithinBounds(node.Left, lowerBound, node.Val)) {
            return false;
        }
        // В противном случае возвращаем true, если правое
        // поддерево также является BST.
        return IsWithinBounds(node.Right, node.Val, upperBound);
    }
}
