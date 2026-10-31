// «Паттерны Coding Interview», глава 6: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.BinarySearch;

public static class CuttingWoodSolution {
    public static int CuttingWood(int[] heights, int k) {
        int left = 0, right = heights.Max();
        while (left < right) {
            // Смещаем середину вправо при поиске верхней границы.
            int mid = (left + right) / 2 + 1;
            if (CutsEnoughWood(mid, k, heights)) {
                left = mid;
            } else {
                right = mid - 1;
            }
        }
        return right;
    }

    // Определяет, спиливается ли при текущем значении H как минимум k метров древесины.
    private static bool CutsEnoughWood(int H, int k, int[] heights) {
        int woodCollected = 0;
        foreach (int height in heights) {
            if (height > H) {
                woodCollected += height - H;
            }
        }
        return woodCollected >= k;
    }
}
