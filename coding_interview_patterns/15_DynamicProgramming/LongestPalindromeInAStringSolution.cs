// «Паттерны Coding Interview», глава 15: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.DynamicProgramming;

public static class LongestPalindromeInAStringSolution {
    public static string LongestPalindromeInAString(string s) {
        int n = s.Length;
        if (n == 0) {
            return "";
        }
        bool[][] dp = Enumerable.Range(0, n).Select(_ => new bool[n]).ToArray();
        int maxLen = 1;
        int startIndex = 0;
        // Базовый случай: один символ всегда палиндром
        for (int i = 0; i < n; i++) {
            dp[i][i] = true;
        }
        // Базовый случай: подстрока длиной два символа —
        // палиндром, если оба символа одинаковые.
        for (int i = 0; i < n - 1; i++) {
            if (s[i] == s[i + 1]) {
                dp[i][i + 1] = true;
                maxLen = 2;
                startIndex = i;
            }
        }
        // Поиск палиндромных подстрок длиной от 3 и больше.
        for (int substringLen = 3; substringLen <= n; substringLen++) {
            // Перебираем каждую подстроку длиной substringLen.
            for (int i = 0; i < n - substringLen + 1; i++) {
                int j = i + substringLen - 1;
                // Если первый и последний символы совпадают
                // и внутренняя подстрока является палиндромом,
                // то текущая подстрока тоже палиндром.
                if (s[i] == s[j] && dp[i + 1][j - 1]) {
                    dp[i][j] = true;
                    maxLen = substringLen;
                    startIndex = i;
                }
            }
        }
        return s.Substring(startIndex, maxLen);
    }

    public static string LongestPalindromeInAStringExpanding(string s) {
        int n = s.Length;
        int start = 0, maxLen = 0;
        for (int center = 0; center < n; center++) {
            // Проверка палиндромов нечетной длины.
            var (oddStart, oddLength) = ExpandPalindrome(center, center, s);
            if (oddLength > maxLen) {
                start = oddStart;
                maxLen = oddLength;
            }
            // Проверка палиндромов четной длины.
            if (center < n - 1 && s[center] == s[center + 1]) {
                var (evenStart, evenLength) = ExpandPalindrome(
                    center, center + 1, s
                );
                if (evenLength > maxLen) {
                    start = evenStart;
                    maxLen = evenLength;
                }
            }
        }
        return s.Substring(start, maxLen);
    }

    // Расширение от центра базового случая для нахождения
    // начального индекса и длины палиндрома.
    private static (int Start, int Length) ExpandPalindrome(int left, int right,
                                                            string s) {
        while (left > 0 && right < s.Length - 1 && s[left - 1] == s[right + 1]) {
            left--;
            right++;
        }
        return (left, right - left + 1);
    }
}
