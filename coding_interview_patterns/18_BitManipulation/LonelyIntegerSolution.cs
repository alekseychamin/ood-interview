// «Паттерны Coding Interview», глава 18: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.BitManipulation;

public static class LonelyIntegerSolution {
    public static int LonelyInteger(int[] nums) {
        int res = 0;
        // XOR каждого элемента массива, чтобы дубликаты
        // обнулялись (x ^ x == 0).
        foreach (int num in nums) {
            res ^= num;
        }
        // res хранит одинокий элемент, так как он не был
        // обнулен никакими дубликатами.
        return res;
    }
}
