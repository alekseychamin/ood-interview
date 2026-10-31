// «Паттерны Coding Interview», глава 13: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Graphs;

public static class GraphDeepCopySolution {
    public static GraphNode GraphDeepCopy(GraphNode node) {
        if (node == null) {
            return null;
        }
        return Dfs(node, new Dictionary<GraphNode, GraphNode>());
    }

    private static GraphNode Dfs(GraphNode node,
                                 Dictionary<GraphNode, GraphNode> cloneMap) {
        // Если эта вершина уже была клонирована, возвращаем ранее
        // созданный клон.
        if (cloneMap.TryGetValue(node, out GraphNode existing)) {
            return existing;
        }
        // Клонируем текущую вершину.
        GraphNode clonedNode = new GraphNode(node.Val);
        // Сохраняем текущий клон, чтобы избежать его повторного
        // создания в будущих вызовах DFS.
        cloneMap[node] = clonedNode;
        // Проходим по соседям текущей вершины, чтобы соединить
        // их клоны с текущей клонированной вершиной.
        foreach (GraphNode neighbor in node.Neighbors) {
            GraphNode clonedNeighbor = Dfs(neighbor, cloneMap);
            clonedNode.Neighbors.Add(clonedNeighbor);
        }
        return clonedNode;
    }
}
