// «Паттерны Coding Interview», глава 1: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.TwoPointers;

public static class LargestContainerSolution {
    public static int LargestContainerBruteForce(int[] heights) {
        int n = heights.Length;
        int maxWater = 0;
        // Находим максимальную площадь между всеми парами
        // линий.
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                int water = Math.Min(heights[i], heights[j]) * (j - i);
                maxWater = Math.Max(maxWater, water);
            }
        }
        return maxWater;
    }

    public static int LargestContainer(int[] heights) {
        int maxWater = 0;
        int left = 0, right = heights.Length - 1;
        while (left < right) {
            // Вычисляем площадь между текущей парой линий.
            int water = Math.Min(heights[left], heights[right]) * (right - left);
            maxWater = Math.Max(maxWater, water);
            // Сдвигаем указатели внутрь.
            // Всегда сдвигаем тот, который указывает на более
            // короткую линию. Если линии равны — сдвигаем оба.
            if (heights[left] < heights[right]) {
                left++;
            } else if (heights[left] > heights[right]) {
                right--;
            } else {
                left++;
                right--;
            }
        }
        return maxWater;
    }
}
