// «Паттерны Coding Interview», глава 8: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Heaps;

public static class KMostFrequentStringsMinHeapSolution {
    public class Pair : IComparable<Pair> {
        public string Str;
        public int Freq;

        public Pair(string str, int freq) {
            Str = str;
            Freq = freq;
        }

        // Так как это функция сравнения для мин-кучи, можно использовать
        // ту же функцию сравнения, что и для макс-кучи, но изменить
        // знаки неравенства, чтобы инвертировать приоритет.
        public int CompareTo(Pair other) {
            if (Freq == other.Freq) {
                return string.CompareOrdinal(other.Str, Str);
            }
            return Freq.CompareTo(other.Freq);
        }
    }

    public static List<string> KMostFrequentStringsMinHeap(string[] strs, int k) {
        Dictionary<string, int> freqs = strs.CountBy(s => s).ToDictionary();
        var minHeap = new PriorityQueue<Pair, Pair>();
        foreach (var (str, freq) in freqs) {
            var pair = new Pair(str, freq);
            minHeap.Enqueue(pair, pair);
            // Если размер кучи превышает k, извлекаем строку с
            // наименьшей частотой, чтобы куча содержала только
            // k самых частых слов на данный момент.
            if (minHeap.Count > k) {
                minHeap.Dequeue();
            }
        }
        // Возвращаем k самых частых строк, извлекая оставшиеся
        // k строк из кучи. Поскольку используется мин-куча,
        // после извлечения элементов нужно обратить порядок
        // массива, чтобы самые частые строки оказались первыми.
        List<string> res = Enumerable.Range(0, k)
            .Select(_ => minHeap.Dequeue().Str).ToList();
        res.Reverse();
        return res;
    }
}
