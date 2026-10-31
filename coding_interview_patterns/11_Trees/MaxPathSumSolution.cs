// «Паттерны Coding Interview», глава 11: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Trees;

public static class MaxPathSumSolution {
    private static int maxSum = int.MinValue;

    public static int MaxPathSum(TreeNode root) {
        maxSum = int.MinValue;
        MaxPathSumHelper(root);
        return maxSum;
    }

    private static int MaxPathSumHelper(TreeNode node) {
        // Базовый случай: пустой узел не имеет суммы пути.
        if (node == null) {
            return 0;
        }
        // Вычисляем максимальную сумму из левого и правого
        // поддеревьев, при этом заменяем отрицательные значения
        // на 0.
        int leftSum = Math.Max(MaxPathSumHelper(node.Left), 0);
        int rightSum = Math.Max(MaxPathSumHelper(node.Right), 0);
        // Обновляем глобальную максимальную сумму пути, если
        // текущая больше.
        maxSum = Math.Max(maxSum, node.Val + leftSum + rightSum);
        // Возвращаем максимальную сумму одного непрерывного пути,
        // в котором текущий узел является конечной точкой.
        return node.Val + Math.Max(leftSum, rightSum);
    }
}
