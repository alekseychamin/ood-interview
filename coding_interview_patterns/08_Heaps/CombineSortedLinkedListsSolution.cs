// «Паттерны Coding Interview», глава 8: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Heaps;

public static class CombineSortedLinkedListsSolution {
    public static ListNode CombineSortedLinkedLists(List<ListNode> lists) {
        // Приоритетом узла в мин-куче служит его значение, поэтому
        // куча приоритизирует узлы с меньшими значениями.
        var heap = new PriorityQueue<ListNode, int>();
        // Добавляем в кучу головные узлы каждого связного списка.
        foreach (ListNode head in lists) {
            if (head != null) {
                heap.Enqueue(head, head.Val);
            }
        }
        // Создаем указатель для прохода по объединенному связному
        // списку по мере добавления в него узлов.
        ListNode dummy = new ListNode(-1);
        // Указатель для прохода по объединенному списку.
        ListNode curr = dummy;
        while (heap.Count > 0) {
            // Извлекаем узел с наименьшим значением из кучи и
            // добавляем его в список.
            ListNode smallestNode = heap.Dequeue();
            curr.Next = smallestNode;
            curr = curr.Next;
            // Если у извлеченного узла есть следующий, добавляем
            // его в кучу.
            if (smallestNode.Next != null) {
                heap.Enqueue(smallestNode.Next, smallestNode.Next.Val);
            }
        }
        return dummy.Next;
    }
}
