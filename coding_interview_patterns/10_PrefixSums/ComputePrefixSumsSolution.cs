// «Паттерны Coding Interview», глава 10: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.PrefixSums;

public static class ComputePrefixSumsSolution {
    public static List<int> ComputePrefixSums(int[] nums) {
        // Сначала добавляем первый элемент в массив префиксных
        // сумм.
        var prefixSum = new List<int> { nums[0] };
        // Для всех оставшихся индексов прибавляем nums[i] к
        // накопленной сумме из предыдущего индекса.
        for (int i = 1; i < nums.Length; i++) {
            prefixSum.Add(prefixSum[^1] + nums[i]);
        }
        return prefixSum;
    }
}
