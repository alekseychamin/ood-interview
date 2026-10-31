// «Паттерны Coding Interview», глава 8: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Heaps;

public static class KMostFrequentStringsMaxHeapSolution {
    public class Pair : IComparable<Pair> {
        public string Str;
        public int Freq;

        public Pair(string str, int freq) {
            Str = str;
            Freq = freq;
        }

        // Определяем пользовательскую функцию сравнения.
        public int CompareTo(Pair other) {
            // Для строк с одинаковой частотой приоритет отдается
            // лексикографическому порядку.
            if (Freq == other.Freq) {
                return string.CompareOrdinal(Str, other.Str);
            }
            // Иначе приоритет отдается строкам с большей частотой.
            return other.Freq.CompareTo(Freq);
        }
    }

    public static List<string> KMostFrequentStringsMaxHeap(string[] strs, int k) {
        // Используем CountBy для создания хеш-таблицы с подсчетом
        // частот каждой строки.
        Dictionary<string, int> freqs = strs.CountBy(s => s).ToDictionary();
        // Создаем макс-кучу, выполняя heapify для всех пар
        // "строка — частота" (PriorityQueue строит кучу за O(n)).
        var maxHeap = new PriorityQueue<Pair, Pair>(
            freqs.Select(f => {
                var pair = new Pair(f.Key, f.Value);
                return (pair, pair);
            }));
        // Извлекаем наиболее частую строку из кучи k раз и
        // возвращаем эти k строк.
        return Enumerable.Range(0, k).Select(_ => maxHeap.Dequeue().Str).ToList();
    }
}
