// «Паттерны Coding Interview», глава 6: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.BinarySearch;

public static class FirstAndLastOccurrencesOfANumberSolution {
    public static int[] FirstAndLastOccurrencesOfANumber(int[] nums,
                                                         int target) {
        int lowerBound = LowerBoundBinarySearch(nums, target);
        int upperBound = UpperBoundBinarySearch(nums, target);
        return [lowerBound, upperBound];
    }

    private static int LowerBoundBinarySearch(int[] nums, int target) {
        int left = 0, right = nums.Length - 1;
        while (left < right) {
            int mid = (left + right) / 2;
            if (nums[mid] > target) {
                right = mid - 1;
            } else if (nums[mid] < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return nums.Length > 0 && nums[left] == target ? left : -1;
    }

    private static int UpperBoundBinarySearch(int[] nums, int target) {
        int left = 0, right = nums.Length - 1;
        while (left < right) {
            // В поиске верхней границы смещаем mid вправо.
            int mid = (left + right) / 2 + 1;
            if (nums[mid] > target) {
                right = mid - 1;
            } else if (nums[mid] < target) {
                left = mid + 1;
            } else {
                left = mid;
            }
        }
        // Если target отсутствует в массиве, возможно, что
        // операция left = mid + 1 переместит указатель left за
        // пределы массива, когда mid == n - 1. Поэтому в
        // операторе return мы используем указатель right.
        return nums.Length > 0 && nums[right] == target ? right : -1;
    }
}
