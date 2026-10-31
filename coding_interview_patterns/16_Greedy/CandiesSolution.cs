// «Паттерны Coding Interview», глава 16: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Greedy;

public static class CandiesSolution {
    public static int Candies(int[] ratings) {
        int n = ratings.Length;
        // Убедиться, что каждый ребенок получил по 1 конфете.
        int[] candies = new int[n];
        Array.Fill(candies, 1);
        // Первый проход: для каждого ребенка убедиться, что у
        // него больше конфет, чем у соседа слева, если оценка
        // выше.
        for (int i = 1; i < n; i++) {
            if (ratings[i] > ratings[i - 1]) {
                candies[i] = candies[i - 1] + 1;
            }
        }
        // Второй проход: для каждого ребенка убедиться, что у
        // него больше конфет, чем у соседа справа, если оценка
        // выше.
        for (int i = n - 2; i >= 0; i--) {
            if (ratings[i] > ratings[i + 1]) {
                // Если у ребенка уже больше конфет, чем
                // у соседа справа, оставить большее количество.
                candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
            }
        }
        return candies.Sum();
    }
}
