// «Паттерны Coding Interview», глава 1: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.TwoPointers;

public static class IsPalindromeValidSolution {
    public static bool IsPalindromeValid(string s) {
        int left = 0, right = s.Length - 1;
        while (left < right) {
            // Пропускаем символы слева, не являющиеся буквами или цифрами.
            while (left < right && !char.IsLetterOrDigit(s[left])) {
                left++;
            }
            // Пропускаем символы справа, не являющиеся буквами или цифрами.
            while (left < right && !char.IsLetterOrDigit(s[right])) {
                right--;
            }
            // Если символы не совпадают — это не палиндром.
            if (s[left] != s[right]) {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }
}
