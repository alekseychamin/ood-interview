// «Паттерны Coding Interview», глава 18: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.BitManipulation;

public static class HammingWeightsOfIntegersSolution {
    public static List<int> HammingWeightsOfIntegers(int n) {
        return Enumerable.Range(0, n + 1).Select(CountSetBits).ToList();
    }

    private static int CountSetBits(int x) {
        int count = 0;
        // Считаем каждый установленный бит числа x, пока x не
        // станет равным 0.
        while (x > 0) {
            // Увеличиваем счетчик, если LSB равен 1.
            count += x & 1;
            // Сдвигаем x вправо, чтобы следующий бит оказался
            // на позиции LSB.
            x >>= 1;
        }
        return count;
    }

    public static int[] HammingWeightsOfIntegersDp(int n) {
        // Базовый случай: количество установленных битов в числе
        // 0 равно 0. Мы задаем dp[0] = 0, инициализируя весь
        // массив dp нулями.
        int[] dp = new int[n + 1];
        for (int x = 1; x <= n; x++) {
            // Значение dp[x] получаем, используя результат
            // dp[x >> 1] и прибавляя к нему младший бит числа x.
            dp[x] = dp[x >> 1] + (x & 1);
        }
        return dp;
    }
}
