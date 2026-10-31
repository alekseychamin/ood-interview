// «Паттерны Coding Interview», глава 11: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Trees;

public static class WidestBinaryTreeLevelSolution {
    public static int WidestBinaryTreeLevel(TreeNode root) {
        if (root == null) {
            return 0;
        }
        int maxWidth = 0;
        // Хранит пары (узел, индекс).
        var queue = new Queue<(TreeNode Node, int Index)>([(root, 0)]);
        while (queue.Count > 0) {
            int levelSize = queue.Count;
            // Устанавливаем leftmostIndex как индекс первого
            // узла на этом уровне. rightmostIndex изначально
            // равен leftmostIndex и обновляется по мере обхода
            // уровня, в итоге указывая на последний его узел.
            int leftmostIndex = queue.Peek().Index;
            int rightmostIndex = leftmostIndex;
            // Обрабатываем все узлы текущего уровня.
            for (int k = 0; k < levelSize; k++) {
                var (node, i) = queue.Dequeue();
                if (node.Left != null) {
                    queue.Enqueue((node.Left, 2 * i + 1));
                }
                if (node.Right != null) {
                    queue.Enqueue((node.Right, 2 * i + 2));
                }
                rightmostIndex = i;
            }
            maxWidth = Math.Max(maxWidth, rightmostIndex - leftmostIndex + 1);
        }
        return maxWidth;
    }
}
