// «Паттерны Coding Interview», глава 15: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.DynamicProgramming;

public static class MatrixPathwaysSolution {
    public static int MatrixPathways(int m, int n) {
        // Базовые случаи: установить все ячейки в строке 0 и
        // столбце 0 равными 1. Это можно сделать, инициализировав
        // все ячейки таблицы dp единицами.
        int[][] dp = Enumerable.Range(0, m)
                               .Select(_ => Enumerable.Repeat(1, n).ToArray()).ToArray();
        // Заполнить остальную таблицу dp.
        for (int r = 1; r < m; r++) {
            for (int c = 1; c < n; c++) {
                // Пути к текущей ячейке = пути сверху + пути
                // слева.
                dp[r][c] = dp[r - 1][c] + dp[r][c - 1];
            }
        }
        return dp[m - 1][n - 1];
    }

    public static int MatrixPathwaysOptimized(int m, int n) {
        // Инициализируем prevRow как значения dp для строки 0,
        // все элементы равны 1.
        int[] prevRow = new int[n];
        Array.Fill(prevRow, 1);
        // Итерация по матрице начиная с первой строки.
        for (int r = 1; r < m; r++) {
            // Устанавливаем первый элемент currRow в 1. Это
            // делается установкой всей строки в 1.
            int[] currRow = new int[n];
            Array.Fill(currRow, 1);
            for (int c = 1; c < n; c++) {
                // Количество уникальных путей к текущей ячейке
                // равно сумме путей от ячейки сверху
                // (prevRow[c]) и слева (currRow[c - 1]).
                currRow[c] = prevRow[c] + currRow[c - 1];
            }
            // Обновляем prevRow значениями currRow для
            // следующей итерации.
            prevRow = currRow;
        }
        // Последний элемент prevRow содержит результат для
        // правой нижней ячейки.
        return prevRow[n - 1];
    }
}
