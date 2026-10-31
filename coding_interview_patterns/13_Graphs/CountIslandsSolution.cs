// «Паттерны Coding Interview», глава 13: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Graphs;

public static class CountIslandsSolution {
    public static int CountIslands(int[][] matrix) {
        if (matrix.Length == 0) {
            return 0;
        }
        int count = 0;
        for (int r = 0; r < matrix.Length; r++) {
            for (int c = 0; c < matrix[0].Length; c++) {
                // Если найдена клетка суши, выполняем
                // функцию обхода в глубину для исследования всего
                // острова и учитываем его в счетчике.
                if (matrix[r][c] == 1) {
                    Dfs(r, c, matrix);
                    count++;
                }
            }
        }
        return count;
    }

    private static void Dfs(int r, int c, int[][] matrix) {
        // Отмечаем текущую клетку-землю как посещенную.
        matrix[r][c] = -1;
        // Определяем векторы направлений: вверх, вниз, влево и
        // вправо.
        (int, int)[] dirs = [(-1, 0), (1, 0), (0, -1), (0, 1)];
        // Рекурсивно вызываем функцию обхода в глубину для каждой
        // соседней клетки-суши, чтобы продолжить
        // исследование этого острова.
        foreach (var (dr, dc) in dirs) {
            int nextR = r + dr, nextC = c + dc;
            if (IsWithinBounds(nextR, nextC, matrix)
                    && matrix[nextR][nextC] == 1) {
                Dfs(nextR, nextC, matrix);
            }
        }
    }

    private static bool IsWithinBounds(int r, int c, int[][] matrix) {
        return 0 <= r && r < matrix.Length && 0 <= c && c < matrix[0].Length;
    }
}
