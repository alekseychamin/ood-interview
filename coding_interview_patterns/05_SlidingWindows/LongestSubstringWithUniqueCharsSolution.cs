// «Паттерны Coding Interview», глава 5: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.SlidingWindows;

public static class LongestSubstringWithUniqueCharsSolution {
    public static int LongestSubstringWithUniqueChars(string s) {
        int maxLen = 0;
        var hashSet = new HashSet<char>();
        int left = 0, right = 0;
        while (right < s.Length) {
            // Если в окне встречается дубликат, сужаем окно,
            // пока в нем дубликатов не останется.
            while (hashSet.Contains(s[right])) {
                hashSet.Remove(s[left]);
                left++;
            }
            // Когда дубликатов больше нет, обновляем maxLen,
            // если текущее окно стало больше.
            maxLen = Math.Max(maxLen, right - left + 1);
            hashSet.Add(s[right]);
            // Расширяем окно.
            right++;
        }
        return maxLen;
    }

    public static int LongestSubstringWithUniqueCharsOptimized(string s) {
        int maxLen = 0;
        var prevIndexes = new Dictionary<char, int>();
        int left = 0, right = 0;
        while (right < s.Length) {
            // Если индекс предыдущего вхождения текущего символа
            // попадает в текущее окно, значит, этот символ
            // является дубликатом в окне.
            if (prevIndexes.TryGetValue(s[right], out int prevIndex)
                && prevIndex >= left) {
                // Сужаем окно, чтобы исключить предыдущее
                // вхождение этого символа.
                left = prevIndex + 1;
            }
            // Обновляем maxLen, если текущее окно больше
            // предыдущего максимального.
            maxLen = Math.Max(maxLen, right - left + 1);
            prevIndexes[s[right]] = right;
            // Расширяем окно.
            right++;
        }
        return maxLen;
    }
}
