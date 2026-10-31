// «Паттерны Coding Interview», глава 14: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Backtracking;

public static class FindAllPermutationsSolution {
    public static List<List<int>> FindAllPermutations(int[] nums) {
        var res = new List<List<int>>();
        Backtrack(nums, new List<int>(), new HashSet<int>(), res);
        return res;
    }

    private static void Backtrack(int[] nums, List<int> candidate,
                                  HashSet<int> used, List<List<int>> res) {
        // Если текущий кандидат является полной перестановкой,
        // добавляем ее в результат.
        if (candidate.Count == nums.Length) {
            res.Add(new List<int>(candidate));
            return;
        }
        foreach (int num in nums) {
            if (!used.Contains(num)) {
                // Добавляем num к текущей перестановке и
                // отмечаем как использованное.
                candidate.Add(num);
                used.Add(num);
                // Рекурсивно исследуем все ветви с обновленным
                // кандидатом.
                Backtrack(nums, candidate, used, res);
                // Возврат назад: отменяем изменения.
                candidate.RemoveAt(candidate.Count - 1);
                used.Remove(num);
            }
        }
    }
}
