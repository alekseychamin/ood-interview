// «Паттерны Coding Interview», глава 11: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Trees;

public static class RightmostNodesOfABinaryTreeSolution {
    public static List<int> RightmostNodesOfABinaryTree(TreeNode root) {
        if (root == null) {
            return [];
        }
        var res = new List<int>();
        var queue = new Queue<TreeNode>([root]);
        while (queue.Count > 0) {
            int levelSize = queue.Count;
            // Добавляем все ненулевые потомки узлов текущего
            // уровня в очередь.
            for (int i = 0; i < levelSize; i++) {
                TreeNode node = queue.Dequeue();
                if (node.Left != null) {
                    queue.Enqueue(node.Left);
                }
                if (node.Right != null) {
                    queue.Enqueue(node.Right);
                }
                // Записываем последний узел этого уровня в массив
                // результатов.
                if (i == levelSize - 1) {
                    res.Add(node.Val);
                }
            }
        }
        return res;
    }
}
