// «Паттерны Coding Interview», глава 9: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Intervals;

public static class IdentifyAllIntervalOverlapsSolution {
    public static List<Interval> IdentifyAllIntervalOverlaps(
        List<Interval> intervals1, List<Interval> intervals2) {
        var overlaps = new List<Interval>();
        int i = 0, j = 0;
        while (i < intervals1.Count && j < intervals2.Count) {
            // Устанавливаем A как интервал, который начинается
            // первым, а B как второй интервал.
            Interval A, B;
            if (intervals1[i].Start <= intervals2[j].Start) {
                (A, B) = (intervals1[i], intervals2[j]);
            } else {
                (A, B) = (intervals2[j], intervals1[i]);
            }
            // Если есть пересечение, добавляем его.
            if (A.End >= B.Start) {
                overlaps.Add(new Interval(B.Start, Math.Min(A.End, B.End)));
            }
            // Сдвигаем указатель того интервала, который
            // заканчивается первым.
            if (intervals1[i].End < intervals2[j].End) {
                i++;
            } else {
                j++;
            }
        }
        return overlaps;
    }
}
