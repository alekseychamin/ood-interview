// «Паттерны Coding Interview», глава 11: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Trees;

public static class BuildBinaryTreeSolution {
    private static int preorderIndex = 0;
    private static Dictionary<int, int> inorderIndexesMap = new();

    public static TreeNode BuildBinaryTree(int[] preorder, int[] inorder) {
        preorderIndex = 0;
        inorderIndexesMap = new Dictionary<int, int>();
        // Заполняем хеш-таблицу значениями массива inorder и их
        // индексами.
        for (int i = 0; i < inorder.Length; i++) {
            inorderIndexesMap[inorder[i]] = i;
        }
        // Строим дерево и возвращаем корневой узел.
        return BuildSubtree(0, inorder.Length - 1, preorder, inorder);
    }

    private static TreeNode BuildSubtree(int left, int right, int[] preorder,
                                         int[] inorder) {
        // Базовый случай: если в диапазоне нет элементов —
        // возвращаем null.
        if (left > right) {
            return null;
        }
        int val = preorder[preorderIndex];
        // Устанавливаем inorderIndex в индекс того же значения,
        // на которое указывает preorderIndex.
        int inorderIndex = inorderIndexesMap[val];
        TreeNode node = new TreeNode(val);
        // Увеличиваем preorderIndex, чтобы он указывал на
        // следующий создаваемый узел.
        preorderIndex++;
        // Строим левое и правое поддеревья и присоединяем их к
        // текущему узлу.
        node.Left = BuildSubtree(
            left, inorderIndex - 1, preorder, inorder
        );
        node.Right = BuildSubtree(
            inorderIndex + 1, right, preorder, inorder
        );
        return node;
    }
}
