// «Паттерны Coding Interview», глава 6: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.BinarySearch;

public static class FindTheTargetInARotatedSortedArraySolution {
    public static int FindTheTargetInARotatedSortedArray(int[] nums, int target) {
        int left = 0, right = nums.Length - 1;
        while (left < right) {
            int mid = (left + right) / 2;
            if (nums[mid] == target) {
                return mid;
            }
            // Если левый подмассив [left : mid] отсортирован,
            // проверяем, попадает ли target в этот диапазон. Если
            // да — ищем в левом подмассиве, иначе — в правом.
            else if (nums[left] <= nums[mid]) {
                if (nums[left] <= target && target < nums[mid]) {
                    right = mid - 1;
                } else {
                    left = mid + 1;
                }
            }
            // Если правый подмассив [mid : right] отсортирован,
            // проверяем, попадает ли target в этот диапазон. Если
            // да — ищем в правом подмассиве, иначе — в левом.
            else {
                if (nums[mid] < target && target <= nums[right]) {
                    left = mid + 1;
                } else {
                    right = mid - 1;
                }
            }
        }
        // Если target найден, возвращаем индекс, иначе -1.
        return nums.Length > 0 && nums[left] == target ? left : -1;
    }
}
