// «Паттерны Coding Interview», глава 6: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.BinarySearch;

public static class FindTheInsertionIndexSolution {
    public static int FindTheInsertionIndex(int[] nums, int target) {
        int left = 0, right = nums.Length;
        while (left < right) {
            int mid = (left + right) / 2;
            // Если значение в середине больше либо равно target,
            // нижняя граница находится либо в середине, либо левее.
            if (nums[mid] >= target) {
                right = mid;
            }
            // Значение в середине меньше target,
            // значит, нижняя граница где-то справа.
            else {
                left = mid + 1;
            }
        }
        return left;
    }
}
