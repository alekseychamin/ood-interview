// «Паттерны Coding Interview», глава 15: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.DynamicProgramming;

public static class NeighborhoodBurglarySolution {
    public static int NeighborhoodBurglary(int[] houses) {
        // Обработка случаев, когда массив меньше 2,
        // чтобы избежать ошибок выхода за границы при присвоении
        // базовых значений.
        if (houses.Length == 0) {
            return 0;
        }
        if (houses.Length == 1) {
            return houses[0];
        }
        int[] dp = new int[houses.Length];
        // Базовый случай: если дом только один, преступники грабят его.
        dp[0] = houses[0];
        // Базовый случай: если два дома, преступники грабят тот, в котором
        // больше денег.
        dp[1] = Math.Max(houses[0], houses[1]);
        // Заполняем остальную часть массива dp.
        for (int i = 2; i < houses.Length; i++) {
            // dp[i] = max (добыча при пропуске дома i,
            // добыча при краже из дома i)
            dp[i] = Math.Max(dp[i - 1], houses[i] + dp[i - 2]);
        }
        return dp[houses.Length - 1];
    }

    public static int NeighborhoodBurglaryOptimized(int[] houses) {
        if (houses.Length == 0) {
            return 0;
        }
        if (houses.Length == 1) {
            return houses[0];
        }
        // Инициализация переменных базовыми случаями.
        int prevMaxProfit = Math.Max(houses[0], houses[1]);
        int prevPrevMaxProfit = houses[0];
        for (int i = 2; i < houses.Length; i++) {
            int currMaxProfit = Math.Max(prevMaxProfit,
                                         houses[i] + prevPrevMaxProfit);
            // Обновление значений для следующей итерации.
            prevPrevMaxProfit = prevMaxProfit;
            prevMaxProfit = currMaxProfit;
        }
        return prevMaxProfit;
    }
}
