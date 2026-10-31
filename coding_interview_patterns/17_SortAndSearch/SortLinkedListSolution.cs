// «Паттерны Coding Interview», глава 17: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.SortAndSearch;

public static class SortLinkedListSolution {
    public static ListNode SortLinkedList(ListNode head) {
        // Если связный список пуст или содержит только один
        // элемент, он уже отсортирован.
        if (head == null || head.Next == null) {
            return head;
        }
        // Разделяем связный список на две половины с помощью
        // техники медленного и быстрого указателей.
        ListNode secondHead = SplitList(head);
        // Рекурсивно сортируем обе половины.
        ListNode firstHalfSorted = SortLinkedList(head);
        ListNode secondHalfSorted = SortLinkedList(secondHead);
        // Объединяем отсортированные подсписки.
        return Merge(firstHalfSorted, secondHalfSorted);
    }

    private static ListNode SplitList(ListNode head) {
        ListNode slow = head, fast = head;
        while (fast.Next != null && fast.Next.Next != null) {
            slow = slow.Next;
            fast = fast.Next.Next;
        }
        ListNode secondHead = slow.Next;
        slow.Next = null;
        return secondHead;
    }

    private static ListNode Merge(ListNode l1, ListNode l2) {
        ListNode dummy = new ListNode(0);
        // Этот указатель используется для добавления узлов в
        // конец объединенного списка.
        ListNode tail = dummy;
        // Постепенно добавляем узлы с меньшим значением из
        // каждого связного списка в объединенный список, пока один из
        // связных списков не закончится.
        while (l1 != null && l2 != null) {
            if (l1.Val < l2.Val) {
                tail.Next = l1;
                l1 = l1.Next;
            } else {
                tail.Next = l2;
                l2 = l2.Next;
            }
            tail = tail.Next;
        }
        // Один из списков может содержать оставшиеся узлы.
        // Добавляем их в конец объединенного списка.
        tail.Next = l1 ?? l2;
        return dummy.Next;
    }
}
