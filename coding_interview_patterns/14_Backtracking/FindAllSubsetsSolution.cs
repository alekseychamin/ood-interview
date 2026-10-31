// «Паттерны Coding Interview», глава 14: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Backtracking;

public static class FindAllSubsetsSolution {
    public static List<List<int>> FindAllSubsets(int[] nums) {
        var res = new List<List<int>>();
        Backtrack(0, new List<int>(), nums, res);
        return res;
    }

    private static void Backtrack(int i, List<int> currSubset, int[] nums,
                                  List<List<int>> res) {
        // Базовый случай: если рассмотрены все элементы,
        // добавляем текущее подмножество currSubset в результат.
        if (i == nums.Length) {
            res.Add(new List<int>(currSubset));
            return;
        }
        // Включаем текущий элемент и рекурсивно исследуем все
        // ветви, исходящие из этого подмножества.
        currSubset.Add(nums[i]);
        Backtrack(i + 1, currSubset, nums, res);
        // Исключаем текущий элемент и рекурсивно исследуем все
        // ветви, исходящие из этого подмножества.
        currSubset.RemoveAt(currSubset.Count - 1);
        Backtrack(i + 1, currSubset, nums, res);
    }
}
