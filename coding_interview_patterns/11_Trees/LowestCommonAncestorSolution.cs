// «Паттерны Coding Interview», глава 11: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Trees;

public static class LowestCommonAncestorSolution {
    private static TreeNode lca;

    public static TreeNode LowestCommonAncestor(TreeNode root,
                                                TreeNode p, TreeNode q) {
        Dfs(root, p, q);
        return lca;
    }

    private static bool Dfs(TreeNode node, TreeNode p, TreeNode q) {
        // Базовый случай: пустой узел не является ни p, ни q.
        if (node == null) {
            return false;
        }
        bool nodeIsPOrQ = node == p || node == q;
        // Рекурсивно проверяем, содержит ли левое и правое
        // поддерево p или q.
        bool leftContainsPOrQ = Dfs(node.Left, p, q);
        bool rightContainsPOrQ = Dfs(node.Right, p, q);
        // Если два из трех условий истинны, текущий узел — это
        // наименьший общий предок.
        if ((nodeIsPOrQ ? 1 : 0)
            + (leftContainsPOrQ ? 1 : 0)
            + (rightContainsPOrQ ? 1 : 0)
            == 2) {
            lca = node;
        }
        // Возвращаем true, если текущее поддерево содержит p
        // или q.
        return nodeIsPOrQ || leftContainsPOrQ || rightContainsPOrQ;
    }
}
