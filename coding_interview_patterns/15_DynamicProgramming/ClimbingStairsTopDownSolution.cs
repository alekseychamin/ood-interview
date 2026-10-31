// «Паттерны Coding Interview», глава 15: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.DynamicProgramming;

public static class ClimbingStairsTopDownSolution {
    private static readonly Dictionary<int, int> memo = new();

    public static int ClimbingStairsTopDown(int n) {
        // Базовые случаи: для лестницы из 1 ступени есть только
        // один способ подняться, для лестницы из 2 ступеней есть
        // два способа.
        if (n <= 2) {
            return n;
        }
        if (memo.TryGetValue(n, out int cached)) {
            return cached;
        }
        // Количество способов подняться на n-ю ступень равно
        // сумме количества способов подняться на n-1 и n-2
        // ступеней.
        memo[n] =
            ClimbingStairsTopDown(n - 1) +
            ClimbingStairsTopDown(n - 2);
        return memo[n];
    }
}
