// «Паттерны Coding Interview», глава 17: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.SortAndSearch;

public static class SortArraySolution {
    public static int[] SortArray(int[] nums) {
        Quicksort(nums, 0, nums.Length - 1);
        return nums;
    }

    private static void Quicksort(int[] nums, int left, int right) {
        // Базовый случай: если подмассив содержит 0 или 1
        // элемент, он уже отсортирован.
        if (left >= right) {
            return;
        }
        // Разделяем массив и получаем индекс опорного элемента.
        int pivotIndex = Partition(nums, left, right);
        // Рекурсивно вызываем Quicksort для левой и правой частей
        // массива.
        Quicksort(nums, left, pivotIndex - 1);
        Quicksort(nums, pivotIndex + 1, right);
    }

    private static int Partition(int[] nums, int left, int right) {
        int pivot = nums[right];
        int lo = left;
        // Перемещаем все числа меньше опорного влево, что
        // автоматически размещает все числа больше или равные
        // опорному справа.
        for (int i = left; i < right; i++) {
            if (nums[i] < pivot) {
                (nums[lo], nums[i]) = (nums[i], nums[lo]);
                lo++;
            }
        }
        // После разделения lo указывает на позицию, куда должен
        // встать опорный элемент. Меняем местами опорный элемент
        // и элемент на позиции lo.
        (nums[lo], nums[right]) = (nums[right], nums[lo]);
        return lo;
    }

    private static void QuicksortOptimized(int[] nums, int left, int right) {
        if (left >= right) {
            return;
        }
        // Выбираем опорный элемент случайным образом.
        int randomIndex = Random.Shared.Next(left, right + 1);
        // Меняем случайно выбранный опорный элемент с правым
        // элементом, чтобы разместить его в правом конце массива.
        (nums[randomIndex], nums[right]) = (nums[right], nums[randomIndex]);
        int pivotIndex = Partition(nums, left, right);
        QuicksortOptimized(nums, left, pivotIndex - 1);
        QuicksortOptimized(nums, pivotIndex + 1, right);
    }
}
