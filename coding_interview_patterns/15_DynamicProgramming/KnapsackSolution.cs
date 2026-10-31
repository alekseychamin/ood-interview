// «Паттерны Coding Interview», глава 15: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.DynamicProgramming;

public static class KnapsackSolution {
    public static int Knapsack(int cap, int[] weights, int[] values) {
        int n = values.Length;
        // Базовый случай: устанавливаем первый столбец и
        // последнюю строку в 0, инициализируя всю таблицу dp 0.
        int[][] dp = Enumerable.Range(0, n + 1)
                               .Select(_ => new int[cap + 1]).ToArray();
        // Заполняем таблицу dp.
        for (int i = n - 1; i >= 0; i--) {
            for (int c = 1; c <= cap; c++) {
                // Если предмет i можно доложить в рюкзак,
                // не превысив максимальный общий вес, максимальная стоимость
                // украденного в dp[i][c] — это большее из:
                // 1. Максимальная стоимость украденного при включении
                // в него предмета i.
                // 2. Максимальная стоимость украденного при исключении
                // из него предмета i.
                if (weights[i] <= c) {
                    dp[i][c] = Math.Max(values[i] + dp[i + 1][c - weights[i]],
                                        dp[i + 1][c]);
                }
                // Если предмет слишком тяжелый, его нужно исключить.
                else {
                    dp[i][c] = dp[i + 1][c];
                }
            }
        }
        return dp[0][cap];
    }

    public static int KnapsackOptimized(int cap, int[] weights, int[] values) {
        int n = values.Length;
        // Инициализируем prevRow как значения dp для строки
        // ниже текущей.
        int[] prevRow = new int[cap + 1];
        for (int i = n - 1; i >= 0; i--) {
            // Устанавливаем первый элемент currRow в 0 для
            // базового случая этой строки. Это делается путем
            // инициализации всей строки нулями.
            int[] currRow = new int[cap + 1];
            for (int c = 1; c <= cap; c++) {
                // Если предмет i можно доложить в рюкзак,
                // не превысив максимальный общий вес, максимальная стоимость
                // украденного в dp[i][c] — это большее из:
                // 1. Максимальная стоимость украденного при включении
                // в него предмета i.
                // 2. Максимальная стоимость украденного при исключении
                // из него предмета i.
                if (weights[i] <= c) {
                    currRow[c] = Math.Max(values[i] + prevRow[c - weights[i]],
                                          prevRow[c]);
                }
                // Если предмет i не подходит, исключаем его.
                else {
                    currRow[c] = prevRow[c];
                }
            }
            // Обновляем prevRow значениями currRow для
            // следующей итерации.
            prevRow = currRow;
        }
        return prevRow[cap];
    }
}
