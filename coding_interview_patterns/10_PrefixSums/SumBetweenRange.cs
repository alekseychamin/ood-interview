// «Паттерны Coding Interview», глава 10: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.PrefixSums;

public class SumBetweenRange {
    private readonly List<int> prefixSum;

    public SumBetweenRange(int[] nums) {
        prefixSum = [nums[0]];
        for (int i = 1; i < nums.Length; i++) {
            prefixSum.Add(prefixSum[^1] + nums[i]);
        }
    }

    public int SumRange(int i, int j) {
        if (i == 0) {
            return prefixSum[j];
        }
        return prefixSum[j] - prefixSum[i - 1];
    }
}
