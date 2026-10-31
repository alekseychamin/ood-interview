// «Паттерны Coding Interview», глава 5: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.SlidingWindows;

public static class SubstringAnagramsSolution {
    public static int SubstringAnagrams(string s, string t) {
        int lenS = s.Length, lenT = t.Length;
        if (lenT > lenS) {
            return 0;
        }
        int count = 0;
        int[] expectedFreqs = new int[26], windowFreqs = new int[26];
        // Заполняем expectedFreqs частотами символов строки t.
        foreach (char c in t) {
            expectedFreqs[c - 'a']++;
        }
        int left = 0, right = 0;
        while (right < lenS) {
            // Добавляем символ у правого указателя в
            // windowFreqs перед сдвигом окна.
            windowFreqs[s[right] - 'a']++;
            // Если окно достигло фиксированной длины lenT,
            // сдвигаем оба указателя.
            if (right - left + 1 == lenT) {
                if (windowFreqs.SequenceEqual(expectedFreqs)) {
                    count++;
                }
                // Удаляем символ у левого указателя из
                // windowFreqs перед сдвигом влево.
                windowFreqs[s[left] - 'a']--;
                left++;
            }
            right++;
        }
        return count;
    }
}
