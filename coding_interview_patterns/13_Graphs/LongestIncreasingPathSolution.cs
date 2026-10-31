// «Паттерны Coding Interview», глава 13: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Graphs;

public static class LongestIncreasingPathSolution {
    public static int LongestIncreasingPath(int[][] matrix) {
        if (matrix.Length == 0) {
            return 0;
        }
        int res = 0;
        int m = matrix.Length, n = matrix[0].Length;
        int[][] memo = Enumerable.Range(0, m).Select(_ => new int[n]).ToArray();
        // Находим самый длинный возрастающий путь, начинающийся
        // из каждой ячейки. Максимальное значение среди них равно
        // длине общего самого длинного пути.
        for (int r = 0; r < m; r++) {
            for (int c = 0; c < n; c++) {
                res = Math.Max(res, Dfs(r, c, matrix, memo));
            }
        }
        return res;
    }

    private static int Dfs(int r, int c, int[][] matrix, int[][] memo) {
        if (memo[r][c] != 0) {
            return memo[r][c];
        }
        int maxPath = 1;
        (int, int)[] dirs = [(-1, 0), (1, 0), (0, -1), (0, 1)];
        // Самый длинный путь, начинающийся с текущей ячейки,
        // равен самому длинному пути ее соседей с наибольшим
        // значением плюс 1.
        foreach (var (dr, dc) in dirs) {
            int nextR = r + dr, nextC = c + dc;
            if (IsWithinBounds(nextR, nextC, matrix)
                && matrix[nextR][nextC] > matrix[r][c]) {
                maxPath = Math.Max(maxPath,
                                   1 + Dfs(nextR, nextC, matrix, memo));
            }
        }
        memo[r][c] = maxPath;
        return maxPath;
    }

    private static bool IsWithinBounds(int r, int c, int[][] matrix) {
        return 0 <= r && r < matrix.Length && 0 <= c && c < matrix[0].Length;
    }
}
