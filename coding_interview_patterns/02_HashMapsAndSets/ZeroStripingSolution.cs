// «Паттерны Coding Interview», глава 2: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.HashMapsAndSets;

public static class ZeroStripingSolution {
    public static void ZeroStripingHashSets(int[][] matrix) {
        if (matrix.Length == 0 || matrix[0].Length == 0) {
            return;
        }
        int m = matrix.Length, n = matrix[0].Length;
        var zeroRows = new HashSet<int>();
        var zeroCols = new HashSet<int>();
        // 1 проход: определяем строки и столбцы, содержащие нули,
        // и сохраняем их индексы в соответствующие хеш-множества.
        for (int r = 0; r < m; r++) {
            for (int c = 0; c < n; c++) {
                if (matrix[r][c] == 0) {
                    zeroRows.Add(r);
                    zeroCols.Add(c);
                }
            }
        }
        // 2 проход: обнуляем те ячейки, индексы строк которых находятся
        // в множестве zeroRows или индексы столбцов в множестве zeroCols.
        for (int r = 0; r < m; r++) {
            for (int c = 0; c < n; c++) {
                if (zeroRows.Contains(r) || zeroCols.Contains(c)) {
                    matrix[r][c] = 0;
                }
            }
        }
    }

    public static void ZeroStriping(int[][] matrix) {
        if (matrix.Length == 0 || matrix[0].Length == 0) {
            return;
        }
        int m = matrix.Length, n = matrix[0].Length;
        // Проверка: содержит ли первая строка изначально ноль.
        bool firstRowHasZero = false;
        for (int c = 0; c < n; c++) {
            if (matrix[0][c] == 0) {
                firstRowHasZero = true;
                break;
            }
        }
        // Проверка: содержит ли первый столбец изначально ноль.
        bool firstColHasZero = false;
        for (int r = 0; r < m; r++) {
            if (matrix[r][0] == 0) {
                firstColHasZero = true;
                break;
            }
        }
        // Используем первую строку и первый столбец как маркеры.
        // Если в подматрице обнаружен ноль, обнуляем
        // соответствующие ячейки в первых строке и столбце.
        for (int r = 1; r < m; r++) {
            for (int c = 1; c < n; c++) {
                if (matrix[r][c] == 0) {
                    matrix[0][c] = 0;
                    matrix[r][0] = 0;
                }
            }
        }
        // Обновляем значения в подматрице на основе установленных
        // маркеров.
        for (int r = 1; r < m; r++) {
            for (int c = 1; c < n; c++) {
                if (matrix[0][c] == 0 || matrix[r][0] == 0) {
                    matrix[r][c] = 0;
                }
            }
        }
        // Если первая строка изначально содержала ноль — обнуляем
        // ее полностью.
        if (firstRowHasZero) {
            for (int c = 0; c < n; c++) {
                matrix[0][c] = 0;
            }
        }
        // Если первый столбец изначально содержал ноль — обнуляем
        // его полностью.
        if (firstColHasZero) {
            for (int r = 0; r < m; r++) {
                matrix[r][0] = 0;
            }
        }
    }
}
