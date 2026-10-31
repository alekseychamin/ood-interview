// «Паттерны Coding Interview», глава 2: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.HashMapsAndSets;

public static class PairSumUnsortedSolution {
    public static int[] PairSumUnsortedTwoPass(int[] nums, int target) {
        var numMap = new Dictionary<int, int>();
        // Первый проход: заполняем хеш-таблицу, сопоставляя
        // каждое число с его индексом.
        for (int i = 0; i < nums.Length; i++) {
            numMap[nums[i]] = i;
        }
        // Второй проход: проверяем наличие слагаемого для каждого
        // числа.
        for (int i = 0; i < nums.Length; i++) {
            int complement = target - nums[i];
            if (numMap.TryGetValue(complement, out int j) && j != i) {
                return [i, j];
            }
        }
        return [];
    }

    public static int[] PairSumUnsorted(int[] nums, int target) {
        var hashmap = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++) {
            int x = nums[i];
            if (hashmap.TryGetValue(target - x, out int j)) {
                return [j, i];
            }
            hashmap[x] = i;
        }
        return [];
    }
}
