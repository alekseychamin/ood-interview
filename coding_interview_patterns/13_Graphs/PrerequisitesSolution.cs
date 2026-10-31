// «Паттерны Coding Interview», глава 13: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Graphs;

public static class PrerequisitesSolution {
    public static bool Prerequisites(int n, int[][] prerequisites) {
        var graph = new Dictionary<int, List<int>>();
        int[] inDegrees = new int[n];
        // Представляем граф в виде списка смежности и записываем
        // входящую степень каждого курса.
        foreach (int[] pair in prerequisites) {
            int prerequisite = pair[0], course = pair[1];
            if (!graph.ContainsKey(prerequisite)) {
                graph[prerequisite] = new List<int>();
            }
            graph[prerequisite].Add(course);
            inDegrees[course]++;
        }
        var queue = new Queue<int>();
        // Добавляем все курсы с входящей степенью 0 в очередь.
        for (int i = 0; i < n; i++) {
            if (inDegrees[i] == 0) {
                queue.Enqueue(i);
            }
        }
        int enrolledCourses = 0;
        // Выполняем топологическую сортировку.
        while (queue.Count > 0) {
            int node = queue.Dequeue();
            enrolledCourses++;
            foreach (int neighbor in graph.GetValueOrDefault(node, new List<int>())) {
                inDegrees[neighbor]--;
                // Если входящая степень соседнего курса стала 0,
                // добавляем его в очередь.
                if (inDegrees[neighbor] == 0) {
                    queue.Enqueue(neighbor);
                }
            }
        }
        // Возвращаем true, если удалось записаться на все курсы.
        return enrolledCourses == n;
    }
}
