// «Паттерны Coding Interview», глава 4: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.FastAndSlowPointers;

public static class HappyNumberSolution {
    public static bool HappyNumber(int n) {
        int slow = n, fast = n;
        while (true) {
            slow = GetNextNum(slow);
            fast = GetNextNum(GetNextNum(fast));
            if (fast == 1) {
                return true;
            }
            // Если быстрый и медленный указатели встретились,
            // значит, обнаружен цикл.
            // Следовательно, число n не является счастливым.
            else if (fast == slow) {
                return false;
            }
        }
    }

    private static int GetNextNum(int x) {
        int nextNum = 0;
        while (x > 0) {
            // Извлекаем последнюю цифру числа x.
            int digit = x % 10;
            // Убираем последнюю цифру числа x,
            // используя целочисленное деление.
            x /= 10;
            // Добавляем квадрат извлеченной цифры к сумме.
            nextNum += digit * digit;
        }
        return nextNum;
    }
}
