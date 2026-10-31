// «Паттерны Coding Interview», глава 15: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.DynamicProgramming;

public static class MaximumSubarraySumSolution {
    public static int MaximumSubarraySum(int[] nums) {
        if (nums.Length == 0) {
            return 0;
        }
        // Инициализация переменных суммы минимальным значением int,
        // чтобы учесть отрицательные числа (аналог -∞).
        int maxSum = int.MinValue;
        int currentSum = int.MinValue;
        // Проходим по массиву для поиска максимальной суммы подмассива.
        foreach (int num in nums) {
            // Либо добавляем текущее число к текущей сумме
            // подмассива, либо начинаем новый подмассив.
            // (long — чтобы int.MinValue + num не переполнился.)
            currentSum = (int)Math.Max((long)currentSum + num, num);
            maxSum = Math.Max(maxSum, currentSum);
        }
        return maxSum;
    }

    public static int MaximumSubarraySumDp(int[] nums) {
        int n = nums.Length;
        if (n == 0) {
            return 0;
        }
        int[] dp = new int[n];
        // Базовый случай: максимальная сумма подмассива массива с
        // одним элементом — это сам элемент.
        dp[0] = nums[0];
        int maxSum = dp[0];
        // Заполнение остальной части dp-массива.
        for (int i = 1; i < n; i++) {
            // Вычисляем максимальную сумму подмассива,
            // оканчивающегося на текущем индексе.
            dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i]);
            maxSum = Math.Max(maxSum, dp[i]);
        }
        return maxSum;
    }

    public static int MaximumSubarraySumDpOptimized(int[] nums) {
        int n = nums.Length;
        if (n == 0) {
            return 0;
        }
        int currentSum = nums[0];
        int maxSum = nums[0];
        for (int i = 1; i < n; i++) {
            currentSum = Math.Max(nums[i], currentSum + nums[i]);
            maxSum = Math.Max(maxSum, currentSum);
        }
        return maxSum;
    }
}
