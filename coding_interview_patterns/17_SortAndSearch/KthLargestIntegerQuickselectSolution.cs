// «Паттерны Coding Interview», глава 17: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.SortAndSearch;

public static class KthLargestIntegerQuickselectSolution {
    public static int KthLargestIntegerQuickselect(int[] nums, int k) {
        return Quickselect(nums, 0, nums.Length - 1, k);
    }

    private static int Quickselect(int[] nums, int left, int right, int k) {
        int n = nums.Length;
        if (left >= right) {
            return nums[left];
        }
        int randomIndex = Random.Shared.Next(left, right + 1);
        (nums[randomIndex], nums[right]) = (nums[right], nums[randomIndex]);
        int pivotIndex = Partition(nums, left, right);
        // Если опорный элемент находится перед индексом n - k,
        // (n - k)-й наименьший элемент находится справа.
        // Выполняем Quickselect для правой части.
        if (pivotIndex < n - k) {
            return Quickselect(nums, pivotIndex + 1, right, k);
        }
        // Если опорный элемент находится после индекса n - k,
        // (n - k)-й наименьший элемент находится слева.
        // Выполняем Quickselect для левой части.
        else if (pivotIndex > n - k) {
            return Quickselect(nums, left, pivotIndex - 1, k);
        }
        // Если опорный элемент находится на индексе n - k,
        // это и есть (n - k)-й наименьший элемент.
        else {
            return nums[pivotIndex];
        }
    }

    private static int Partition(int[] nums, int left, int right) {
        int pivot = nums[right];
        int lo = left;
        for (int i = left; i < right; i++) {
            if (nums[i] < pivot) {
                (nums[lo], nums[i]) = (nums[i], nums[lo]);
                lo++;
            }
        }
        (nums[lo], nums[right]) = (nums[right], nums[lo]);
        return lo;
    }
}
