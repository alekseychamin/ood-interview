// «Паттерны Coding Interview», глава 1: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.TwoPointers;

public static class TripletSumSolution {
    public static List<List<int>> TripletSumBruteForce(int[] nums) {
        int n = nums.Length;
        // Используем множество, чтобы избежать повторений.
        var triplets = new HashSet<(int, int, int)>();
        // Перебираем индексы всех возможных троек.
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                for (int k = j + 1; k < n; k++) {
                    if (nums[i] + nums[j] + nums[k] == 0) {
                        // Сортируем тройку перед добавлением в
                        // множество.
                        int[] t = [nums[i], nums[j], nums[k]];
                        Array.Sort(t);
                        triplets.Add((t[0], t[1], t[2]));
                    }
                }
            }
        }
        return triplets.Select(t => new List<int> { t.Item1, t.Item2, t.Item3 })
                       .ToList();
    }

    public static List<List<int>> TripletSum(int[] nums) {
        var triplets = new List<List<int>>();
        Array.Sort(nums);
        for (int i = 0; i < nums.Length; i++) {
            // Оптимизация: тройки, состоящие только из
            // положительных чисел, не могут в сумме давать 0.
            if (nums[i] > 0) {
                break;
            }
            // Чтобы избежать повторяющихся троек, пропускаем "a",
            // если оно совпадает с предыдущим числом.
            if (i > 0 && nums[i] == nums[i - 1]) {
                continue;
            }
            // Находим все пары, сумма которых равна -a (-nums[i]).
            List<List<int>> pairs = PairSumSortedAllPairs(nums, i + 1, -nums[i]);
            foreach (List<int> pair in pairs) {
                triplets.Add([nums[i], .. pair]);
            }
        }
        return triplets;
    }

    public static List<List<int>> PairSumSortedAllPairs(int[] nums,
                                                        int start, int target) {
        var pairs = new List<List<int>>();
        int left = start, right = nums.Length - 1;
        while (left < right) {
            int sum = nums[left] + nums[right];
            if (sum == target) {
                pairs.Add([nums[left], nums[right]]);
                left++;
                // Чтобы избежать дубликатов пар [b, c],
                // пропускаем "b", если оно такое же, как предыдущее.
                while (left < right && nums[left] == nums[left - 1]) {
                    left++;
                }
            } else if (sum < target) {
                left++;
            } else {
                right--;
            }
        }
        return pairs;
    }
}
