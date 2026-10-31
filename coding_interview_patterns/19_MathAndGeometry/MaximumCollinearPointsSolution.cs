// «Паттерны Coding Interview», глава 19: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.MathAndGeometry;

public static class MaximumCollinearPointsSolution {
    public static int MaximumCollinearPoints(int[][] points) {
        int res = 0;
        // Рассматриваем каждую точку как опорную и определяем
        // максимальное количество точек, которые лежат на одной
        // прямой с этой опорной точкой. Наибольшее из этих
        // значений и будет ответом.
        for (int i = 0; i < points.Length; i++) {
            res = Math.Max(res, MaxPointsFromFocalPoint(i, points));
        }
        return res;
    }

    private static int MaxPointsFromFocalPoint(int focalPointIndex, int[][] points) {
        var slopesMap = new Dictionary<(int, int), int>();
        int maxPoints = 0;
        // Для текущей опорной точки вычисляем наклон между ней и
        // каждой другой точкой. Это позволяет сгруппировать
        // точки, которые имеют одинаковый наклон.
        for (int j = 0; j < points.Length; j++) {
            if (j != focalPointIndex) {
                var currSlope = GetSlope(points[focalPointIndex], points[j]);
                slopesMap[currSlope] = slopesMap.GetValueOrDefault(currSlope) + 1;
                // Обновляем максимум для текущей опорной точки.
                maxPoints = Math.Max(maxPoints, slopesMap[currSlope]);
            }
        }
        // Добавляем 1 для учета самой опорной точки.
        return maxPoints + 1;
    }

    private static (int, int) GetSlope(int[] p1, int[] p2) {
        int rise = p2[1] - p1[1];
        int run = p2[0] - p1[0];
        // Обрабатываем вертикальные линии отдельно, чтобы
        // избежать деления на 0.
        if (run == 0) {
            return (1, 0);
        }
        // Сокращаем дробь с помощью НОД.
        int gcdVal = Gcd(rise, run);
        return (rise / gcdVal, run / gcdVal);
    }

    // Алгоритм Евклида.
    private static int Gcd(int a, int b) {
        while (b != 0) {
            (a, b) = (b, a % b);
        }
        return a;
    }
}
