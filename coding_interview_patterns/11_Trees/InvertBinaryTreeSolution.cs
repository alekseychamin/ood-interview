// «Паттерны Coding Interview», глава 11: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Trees;

public static class InvertBinaryTreeSolution {
    public static TreeNode InvertBinaryTreeRecursive(TreeNode root) {
        // Базовый случай: если узел пустой, инвертировать нечего.
        if (root == null) {
            return null;
        }
        // Меняем местами левое и правое поддеревья текущего узла.
        (root.Left, root.Right) = (root.Right, root.Left);
        // Рекурсивно инвертируем левое и правое поддеревья.
        InvertBinaryTreeRecursive(root.Left);
        InvertBinaryTreeRecursive(root.Right);
        return root;
    }

    public static TreeNode InvertBinaryTreeIterative(TreeNode root) {
        if (root == null) {
            return null;
        }
        var stack = new Stack<TreeNode>([root]);
        while (stack.Count > 0) {
            TreeNode node = stack.Pop();
            // Меняем местами левое и правое поддеревья текущего
            // узла.
            (node.Left, node.Right) = (node.Right, node.Left);
            // Добавляем левое и правое поддеревья в стек.
            if (node.Left != null) {
                stack.Push(node.Left);
            }
            if (node.Right != null) {
                stack.Push(node.Right);
            }
        }
        return root;
    }
}
