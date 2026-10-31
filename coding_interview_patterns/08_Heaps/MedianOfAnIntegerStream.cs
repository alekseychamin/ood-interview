// «Паттерны Coding Interview», глава 8: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Heaps;

public class MedianOfAnIntegerStream {
    // Макс-куча: PriorityQueue с обратным компаратором.
    private readonly PriorityQueue<int, int> leftHalf =
        new(Comparer<int>.Create((a, b) => b.CompareTo(a)));
    // Мин-куча.
    private readonly PriorityQueue<int, int> rightHalf = new();

    public void Add(int num) {
        // Если num меньше или равен максимуму левой половины,
        // добавляем num в нее.
        if (leftHalf.Count == 0 || num <= leftHalf.Peek()) {
            leftHalf.Enqueue(num, num);
            // Перебалансируем кучи, если размер leftHalf
            // превышает размер rightHalf более чем на один
            // элемент.
            if (leftHalf.Count > rightHalf.Count + 1) {
                int moved = leftHalf.Dequeue();
                rightHalf.Enqueue(moved, moved);
            }
        }
        // В противном случае число относится к правой
        // половине.
        else {
            rightHalf.Enqueue(num, num);
        }
        // Перебалансируем кучи, если размер rightHalf
        // больше, чем у leftHalf.
        if (leftHalf.Count < rightHalf.Count) {
            int moved = rightHalf.Dequeue();
            leftHalf.Enqueue(moved, moved);
        }
    }

    public double GetMedian() {
        if (leftHalf.Count == rightHalf.Count) {
            return (leftHalf.Peek() + rightHalf.Peek()) / 2.0;
        }
        return leftHalf.Peek();
    }
}
