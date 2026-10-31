// «Паттерны Coding Interview», глава 9: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Intervals;

public static class LargestOverlapOfIntervalsSolution {
    public static int LargestOverlapOfIntervals(List<Interval> intervals) {
        var points = new List<(int Time, char Type)>();
        foreach (Interval interval in intervals) {
            points.Add((interval.Start, 'S'));
            points.Add((interval.End, 'E'));
        }
        // Сортировка в хронологическом порядке. Если несколько
        // точек совпадают по времени, обеспечиваем приоритет
        // конечных точек перед начальными ('E' < 'S').
        points.Sort();
        int activeIntervals = 0;
        int maxOverlaps = 0;
        foreach (var (time, pointType) in points) {
            if (pointType == 'S') {
                activeIntervals++;
            } else {
                activeIntervals--;
            }
            maxOverlaps = Math.Max(maxOverlaps, activeIntervals);
        }
        return maxOverlaps;
    }
}
