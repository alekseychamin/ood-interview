// «Паттерны Coding Interview», глава 16: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Greedy;

public static class JumpToTheEndSolution {
    public static bool JumpToTheEnd(int[] nums) {
        // Устанавливаем начальную цель на последний индекс
        // массива.
        int destination = nums.Length - 1;
        // Проходим по массиву в обратном порядке, чтобы
        // проверить, можно ли достичь цели с более ранних
        // индексов.
        for (int i = nums.Length - 1; i >= 0; i--) {
            // Если можно достичь цели с текущего индекса, делаем
            // его новой целью.
            if (i + nums[i] >= destination) {
                destination = i;
            }
        }
        // Если цель — индекс 0, мы можем добраться до конца с
        // индекса 0
        return destination == 0;
    }
}
