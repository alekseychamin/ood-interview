// «Паттерны Coding Interview», глава 1: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.TwoPointers;

public static class PairSumSortedSolution {
    public static int[] PairSumSortedBruteForce(int[] nums, int target) {
        int n = nums.Length;
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                if (nums[i] + nums[j] == target) {
                    return [i, j];
                }
            }
        }
        return [];
    }

    public static int[] PairSumSorted(int[] nums, int target) {
        int left = 0, right = nums.Length - 1;
        while (left < right) {
            int sum = nums[left] + nums[right];
            // Если сумма меньше, сдвигаем вправо левый указатель,
            // чтобы приблизиться к целевому значению.
            if (sum < target) {
                left++;
            }
            // Если сумма больше, сдвигаем влево правый указатель,
            // чтобы приблизиться к целевому значению.
            else if (sum > target) {
                right--;
            }
            // Если нашли нужную пару — возвращаем ее индексы.
            else {
                return [left, right];
            }
        }
        return [];
    }
}
