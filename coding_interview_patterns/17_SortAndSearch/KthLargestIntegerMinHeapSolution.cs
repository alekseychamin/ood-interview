// «Паттерны Coding Interview», глава 17: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.SortAndSearch;

public static class KthLargestIntegerMinHeapSolution {
    public static int KthLargestIntegerMinHeap(int[] nums, int k) {
        var minHeap = new PriorityQueue<int, int>();
        foreach (int num in nums) {
            // Убедимся, что в куче есть как минимум k
            // элементов.
            if (minHeap.Count < k) {
                minHeap.Enqueue(num, num);
            }
            // Если num больше наименьшего элемента в куче,
            // удаляем его и добавляем num.
            else if (num > minHeap.Peek()) {
                minHeap.Dequeue();
                minHeap.Enqueue(num, num);
            }
        }
        return minHeap.Peek();
    }
}
