// «Паттерны Coding Interview», глава 13: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Graphs;

public static class BipartiteGraphValidationSolution {
    public static bool BipartiteGraphValidation(int[][] graph) {
        int[] colors = new int[graph.Length];
        // Проверяем, является ли каждая компонента графа
        // двудольной.
        for (int i = 0; i < graph.Length; i++) {
            if (colors[i] == 0 && !Dfs(i, 1, graph, colors)) {
                return false;
            }
        }
        return true;
    }

    private static bool Dfs(int node, int color, int[][] graph, int[] colors) {
        colors[node] = color;
        foreach (int neighbor in graph[node]) {
            // Если соседняя вершина имеет тот же цвет, граф не
            // является двудольным.
            if (colors[neighbor] == color) {
                return false;
            }
            // Если соседняя вершина еще не окрашена, раскрашиваем
            // ее другим цветом и продолжаем обход.
            if (colors[neighbor] == 0
                && !Dfs(neighbor, -color, graph, colors)) {
                return false;
            }
        }
        return true;
    }
}
