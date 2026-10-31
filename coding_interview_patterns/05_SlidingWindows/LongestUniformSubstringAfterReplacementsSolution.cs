// «Паттерны Coding Interview», глава 5: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.SlidingWindows;

public static class LongestUniformSubstringAfterReplacementsSolution {
    public static int LongestUniformSubstringAfterReplacements(string s, int k) {
        var freqs = new Dictionary<char, int>();
        int highestFreq = 0, maxLen = 0;
        int left = 0, right = 0;
        while (right < s.Length) {
            // Обновляем частоту символа на правом указателе и
            // максимальную частоту для текущего окна.
            freqs[s[right]] = freqs.GetValueOrDefault(s[right]) + 1;
            highestFreq = Math.Max(highestFreq, freqs[s[right]]);
            // Вычисляем количество замен, необходимых для
            // текущего окна.
            int numCharsToReplace = (right - left + 1) - highestFreq;
            // Сдвигаем окно, если требуемое число замен превышает
            // k. Правый указатель всегда продвигается, поэтому
            // нужно продвинуть только left.
            if (numCharsToReplace > k) {
                // Удаляем символ у левого указателя из хеш-
                // таблицы перед тем, как продвинуть левый
                // указатель.
                freqs[s[left]]--;
                left++;
            }
            // Поскольку длина текущего окна увеличивается или
            // остается прежней, присваиваем длину текущего окна
            // переменной maxLen.
            maxLen = right - left + 1;
            // Расширяем окно.
            right++;
        }
        return maxLen;
    }
}
