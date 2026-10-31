// «Паттерны Coding Interview», глава 3: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.LinkedLists;

public static class RemoveKthLastNodeSolution {
    public static ListNode RemoveKthLastNode(ListNode head, int k) {
        // Вспомогательный узел, чтобы гарантировать наличие узла
        // перед head, на случай если нужно удалить сам head.
        ListNode dummy = new ListNode(-1);
        dummy.Next = head;
        ListNode trailer = dummy, leader = dummy;
        // Продвигаем leader на k шагов вперед.
        for (int i = 0; i < k; i++) {
            leader = leader.Next;
            // Если k больше длины списка — удаление не требуется.
            if (leader == null) {
                return head;
            }
        }
        // Перемещаем оба указателя, пока leader не дойдет до конца.
        while (leader.Next != null) {
            leader = leader.Next;
            trailer = trailer.Next;
        }
        // Удаляем k-й узел с конца.
        trailer.Next = trailer.Next.Next;
        return dummy.Next;
    }
}
