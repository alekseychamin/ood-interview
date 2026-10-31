// «Паттерны Coding Interview», глава 9: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Intervals;

public static class MergeOverlappingIntervalsSolution {
    public static List<Interval> MergeOverlappingIntervals(
        List<Interval> intervals) {
        intervals.Sort((x, y) => x.Start.CompareTo(y.Start));
        var merged = new List<Interval> { intervals[0] };
        foreach (Interval B in intervals.Skip(1)) {
            Interval A = merged[^1];
            // Если A и B не пересекаются, добавляем B в массив
            // merged.
            if (A.End < B.Start) {
                merged.Add(B);
            }
            // Если они пересекаются, объединяем A и B.
            else {
                merged[^1] = new Interval(A.Start, Math.Max(A.End, B.End));
            }
        }
        return merged;
    }
}
