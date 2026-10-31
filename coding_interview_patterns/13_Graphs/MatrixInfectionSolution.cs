// «Паттерны Coding Interview», глава 13: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Graphs;

public static class MatrixInfectionSolution {
    public static int MatrixInfection(int[][] matrix) {
        (int, int)[] dirs = [(-1, 0), (1, 0), (0, -1), (0, 1)];
        var queue = new Queue<(int, int)>();
        int ones = 0, seconds = 0;
        // Считаем общее количество незараженных клеток и
        // добавляем каждую зараженную клетку в очередь,
        // представляя уровень 0 обхода по уровням.
        for (int r = 0; r < matrix.Length; r++) {
            for (int c = 0; c < matrix[0].Length; c++) {
                if (matrix[r][c] == 1) {
                    ones++;
                } else if (matrix[r][c] == 2) {
                    queue.Enqueue((r, c));
                }
            }
        }
        // Используем обход по уровням, чтобы определить, сколько
        // времени потребуется для заражения всех незараженных
        // клеток.
        while (queue.Count > 0 && ones > 0) {
            // Проходит по 1 секунде с каждым уровнем
            // исследуемой матрицы.
            seconds++;
            int levelSize = queue.Count;
            for (int k = 0; k < levelSize; k++) {
                var (r, c) = queue.Dequeue();
                // Заражаем соседние клетки и добавляем их в очередь
                // для обработки на следующем уровне.
                foreach (var (dr, dc) in dirs) {
                    int nextR = r + dr, nextC = c + dc;
                    if (IsWithinBounds(nextR, nextC, matrix)
                        && matrix[nextR][nextC] == 1) {
                        matrix[nextR][nextC] = 2;
                        ones--;
                        queue.Enqueue((nextR, nextC));
                    }
                }
            }
        }
        // Если еще остались незараженные клетки, возвращаем -1.
        // Иначе возвращаем время, потраченное на процесс.
        return ones == 0 ? seconds : -1;
    }

    private static bool IsWithinBounds(int r, int c, int[][] matrix) {
        return 0 <= r && r < matrix.Length && 0 <= c && c < matrix[0].Length;
    }
}
