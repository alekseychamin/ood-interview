// «Паттерны Coding Interview», глава 19: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.MathAndGeometry;

public static class SpiralMatrixSolution {
    public static List<int> SpiralMatrix(int[][] matrix) {
        if (matrix.Length == 0) {
            return [];
        }
        var result = new List<int>();
        // Инициализация границ матрицы.
        int top = 0, bottom = matrix.Length - 1;
        int left = 0, right = matrix[0].Length - 1;
        // Обход матрицы по спирали
        while (top <= bottom && left <= right) {
            // Двигаемся слева направо вдоль верхней границы.
            for (int i = left; i <= right; i++) {
                result.Add(matrix[top][i]);
            }
            top++;
            // Двигаемся сверху вниз вдоль правой границы.
            for (int i = top; i <= bottom; i++) {
                result.Add(matrix[i][right]);
            }
            right--;
            // Проверяем, что нижняя граница не пересекла верхнюю
            // перед обходом справа налево.
            if (top <= bottom) {
                for (int i = right; i >= left; i--) {
                    result.Add(matrix[bottom][i]);
                }
                bottom--;
            }
            // Проверяем, что левая граница не пересекла правую
            // перед обходом снизу вверх.
            if (left <= right) {
                for (int i = bottom; i >= top; i--) {
                    result.Add(matrix[i][left]);
                }
                left++;
            }
        }
        return result;
    }
}
