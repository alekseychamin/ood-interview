// «Паттерны Coding Interview», глава 19: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.MathAndGeometry;

public static class Reverse32BitIntegerSolution {
    public static int Reverse32BitInteger(int n) {
        const int IntMax = int.MaxValue;  // 2^31 - 1
        const int IntMin = int.MinValue;  // -2^31
        int reversedN = 0;
        // Продолжаем цикл, пока все цифры числа n не будут
        // добавлены в reversedN в обратном порядке.
        while (n != 0) {
            // В C# операторы % и / для целых чисел округляют
            // к нулю, поэтому math.fmod и int(n / 10) не нужны.
            int digit = n % 10;
            n /= 10;
            // Проверяем переполнение или отрицательное переполнение для целого
            // числа.
            if (reversedN > IntMax / 10 || reversedN < IntMin / 10) {
                return 0;
            }
            // Добавляем текущую цифру в reversedN
            reversedN = reversedN * 10 + digit;
        }
        return reversedN;
    }
}
