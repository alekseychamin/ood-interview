// «Паттерны Coding Interview», глава 10: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.PrefixSums;

public static class KSumSubarraysSolution {
    public static int KSumSubarrays(int[] nums, int k) {
        int n = nums.Length;
        int count = 0;
        // Заполняем массив префиксных сумм, устанавливая его
        // первый элемент в 0.
        var prefixSum = new List<int> { 0 };
        for (int i = 0; i < n; i++) {
            prefixSum.Add(prefixSum[^1] + nums[i]);
        }
        // Перебираем все допустимые пары значений префиксных
        // сумм, чтобы найти все подмассивы,
        // сумма которых равна k.
        for (int j = 1; j <= n; j++) {
            for (int i = 1; i <= j; i++) {
                if (prefixSum[j] - prefixSum[i - 1] == k) {
                    count++;
                }
            }
        }
        return count;
    }

    public static int KSumSubarraysOptimized(int[] nums, int k) {
        int count = 0;
        // Инициализируем хеш-таблицу с 0, чтобы обрабатывать
        // подмассивы, сумма которых равна k и которые
        // начинаются с начала массива.
        var prefixSumMap = new Dictionary<int, int> { [0] = 1 };
        int currPrefixSum = 0;
        foreach (int num in nums) {
            // Обновляем текущую префиксную сумму, прибавляя
            // текущий элемент.
            currPrefixSum += num;
            // Если найден подмассив с суммой k, увеличиваем
            // count на количество раз, которое он встречался.
            if (prefixSumMap.TryGetValue(currPrefixSum - k, out int seen)) {
                count += seen;
            }
            // Обновляем частоту currPrefixSum в хеш-таблице.
            int freq = prefixSumMap.GetValueOrDefault(currPrefixSum, 0);
            prefixSumMap[currPrefixSum] = freq + 1;
        }
        return count;
    }
}
