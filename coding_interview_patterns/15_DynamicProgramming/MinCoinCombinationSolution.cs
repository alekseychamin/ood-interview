// «Паттерны Coding Interview», глава 15: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.DynamicProgramming;

public static class MinCoinCombinationSolution {
    // «Бесконечность», которая не переполняется при прибавлении 1.
    private const int Inf = int.MaxValue / 2;

    public static int MinCoinCombinationTopDown(int[] coins, int target) {
        int res = TopDownDp(coins, target, new Dictionary<int, int>());
        return res == Inf ? -1 : res;
    }

    private static int TopDownDp(int[] coins, int target,
                                 Dictionary<int, int> memo) {
        // Базовый случай: если цель равна 0, то для ее достижения
        // нужно 0 монет.
        if (target == 0) {
            return 0;
        }
        if (memo.TryGetValue(target, out int cached)) {
            return cached;
        }
        // Инициализируем minCoins большим числом.
        int minCoins = Inf;
        foreach (int coin in coins) {
            // Избегаем отрицательных значений цели.
            if (coin <= target) {
                // Рассчитываем минимальное количество монет,
                // если используем текущую монету.
                minCoins = Math.Min(minCoins,
                                    1 + TopDownDp(coins, target - coin, memo));
            }
        }
        memo[target] = minCoins;
        return memo[target];
    }

    public static int MinCoinCombinationBottomUp(int[] coins, int target) {
        // Массив динамического программирования будет хранить
        // минимальное количество монет, необходимых для каждой
        // суммы. Изначально установим все элементы в большое
        // число (Inf = int.MaxValue / 2).
        int[] dp = new int[target + 1];
        Array.Fill(dp, Inf);
        // Базовый случай: если цель равна 0, монеты не нужны.
        dp[0] = 0;
        // Обновляем массив динамического программирования для
        // всех сумм больше 0.
        for (int t = 1; t <= target; t++) {
            foreach (int coin in coins) {
                if (coin <= t) {
                    dp[t] = Math.Min(dp[t], 1 + dp[t - coin]);
                }
            }
        }
        return dp[target] != Inf ? dp[target] : -1;
    }
}
