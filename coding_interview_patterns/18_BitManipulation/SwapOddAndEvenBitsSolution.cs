// «Паттерны Coding Interview», глава 18: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.BitManipulation;

public static class SwapOddAndEvenBitsSolution {
    public static uint SwapOddAndEvenBits(uint n) {
        const uint evenMask = 0x55555555; // 01010101010101010101010101010101
        const uint oddMask = 0xAAAAAAAA;  // 10101010101010101010101010101010
        uint evenBits = n & evenMask;
        uint oddBits = n & oddMask;
        // Сдвигаем четные биты влево, нечетные биты вправо и
        // объединяем эти сдвинутые значения.
        return (evenBits << 1) | (oddBits >> 1);
    }
}
