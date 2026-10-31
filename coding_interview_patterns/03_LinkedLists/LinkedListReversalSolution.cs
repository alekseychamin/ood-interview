// «Паттерны Coding Interview», глава 3: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.LinkedLists;

public static class LinkedListReversalSolution {
    public static ListNode LinkedListReversal(ListNode head) {
        ListNode currNode = head, prevNode = null;
        // Разворачиваем указатели узлов, пока currNode
        // не станет null.
        while (currNode != null) {
            ListNode nextNode = currNode.Next;
            currNode.Next = prevNode;
            prevNode = currNode;
            currNode = nextNode;
        }
        // prevNode указывает на голову развернутого списка.
        return prevNode;
    }

    public static ListNode LinkedListReversalRecursive(ListNode head) {
        // Базовые случаи.
        if (head == null || head.Next == null) {
            return head;
        }
        // Рекурсивно разворачиваем подсписок, начиная со
        // следующего узла.
        ListNode newHead = LinkedListReversalRecursive(head.Next);
        // Подключаем развернутый связный список к головному узлу,
        // чтобы полностью развернуть весь список.
        head.Next.Next = head;
        head.Next = null;
        return newHead;
    }
}
