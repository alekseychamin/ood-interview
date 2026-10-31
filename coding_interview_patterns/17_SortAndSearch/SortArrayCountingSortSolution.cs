// «Паттерны Coding Interview», глава 17: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.SortAndSearch;

public static class SortArrayCountingSortSolution {
    public static List<int> SortArrayCountingSort(int[] nums) {
        if (nums.Length == 0) {
            return [];
        }
        var res = new List<int>();
        // Подсчет количества вхождений каждого элемента в nums.
        int[] counts = new int[nums.Max() + 1];
        foreach (int num in nums) {
            counts[num]++;
        }
        // Построение отсортированного массива путем добавления
        // каждого индекса i ровно counts[i] раз.
        for (int i = 0; i < counts.Length; i++) {
            res.AddRange(Enumerable.Repeat(i, counts[i]));
        }
        return res;
    }
}
