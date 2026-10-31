// «Паттерны Coding Interview», глава 15: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.DynamicProgramming;

public static class ClimbingStairsBottomUpSolution {
    public static int ClimbingStairsBottomUp(int n) {
        if (n <= 2) {
            return n;
        }
        int[] dp = new int[n + 1];
        // Базовые случаи.
        dp[1] = 1;
        dp[2] = 2;
        // Начиная с третьей ступени вычисляем количество
        // способов добраться до каждой ступени вплоть до n-й.
        for (int i = 3; i <= n; i++) {
            dp[i] = dp[i - 1] + dp[i - 2];
        }
        return dp[n];
    }

    public static int ClimbingStairsBottomUpOptimized(int n) {
        if (n <= 2) {
            return n;
        }
        // Задаем базовые значения для oneStepBefore и
        // twoStepsBefore.
        int oneStepBefore = 2, twoStepsBefore = 1;
        for (int i = 3; i <= n; i++) {
            // Вычисляем количество способов достичь текущей
            // ступени.
            int current = oneStepBefore + twoStepsBefore;
            // Обновляем значения для следующей итерации.
            twoStepsBefore = oneStepBefore;
            oneStepBefore = current;
        }
        return oneStepBefore;
    }
}
