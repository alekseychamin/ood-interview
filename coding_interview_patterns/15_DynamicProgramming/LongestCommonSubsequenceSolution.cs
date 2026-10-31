// «Паттерны Coding Interview», глава 15: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.DynamicProgramming;

public static class LongestCommonSubsequenceSolution {
    public static int LongestCommonSubsequence(string s1, string s2) {
        // Базовый случай: установим последнюю строку и последний
        // столбец в 0, инициализировав всю таблицу dp нулями.
        int[,] dp = new int[s1.Length + 1, s2.Length + 1];
        // Заполняем таблицу dp.
        for (int i = s1.Length - 1; i >= 0; i--) {
            for (int j = s2.Length - 1; j >= 0; j--) {
                // Если символы совпадают, длина наибольшей общей
                // подпоследовательности в dp[i, j] равна
                // 1 + длина LCS для оставшихся подстрок.
                if (s1[i] == s2[j]) {
                    dp[i, j] = 1 + dp[i + 1, j + 1];
                }
                // Если символы не совпадают, длину LCS в
                // dp[i, j] можно найти, выбрав:
                // 1. Исключить текущий символ из s1.
                // 2. Исключить текущий символ из s2.
                else {
                    dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j + 1]);
                }
            }
        }
        return dp[0, 0];
    }

    public static int LongestCommonSubsequenceOptimized(string s1, string s2) {
        // Инициализируем prevRow как значения dp для последней строки.
        int[] prevRow = new int[s2.Length + 1];
        for (int i = s1.Length - 1; i >= 0; i--) {
            // Устанавливаем последнюю ячейку currRow в 0 для
            // базового случая. Это делается инициализацией всей
            // строки нулями.
            int[] currRow = new int[s2.Length + 1];
            for (int j = s2.Length - 1; j >= 0; j--) {
                // Если символы совпадают, длина LCS в
                // currRow[j] равна 1 + длина LCS для
                // оставшихся подстрок (prevRow[j + 1]).
                if (s1[i] == s2[j]) {
                    currRow[j] = 1 + prevRow[j + 1];
                }
                // Если символы не совпадают, длину LCS в
                // currRow[j] можно найти, выбрав:
                // 1. Исключить текущий символ из s1 (prevRow[j]).
                // 2. Исключить текущий символ из s2 (currRow[j + 1]).
                else {
                    currRow[j] = Math.Max(prevRow[j], currRow[j + 1]);
                }
            }
            // Обновляем prevRow значениями currRow для
            // следующей итерации.
            prevRow = currRow;
        }
        return prevRow[0];
    }
}
