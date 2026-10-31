// «Паттерны Coding Interview», глава 4: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.FastAndSlowPointers;

public static class LinkedListMidpointSolution {
    public static ListNode LinkedListMidpoint(ListNode head) {
        ListNode slow = head, fast = head;
        // Когда быстрый указатель достигнет конца списка,
        // медленный указатель окажется на его середине.
        while (fast != null && fast.Next != null) {
            slow = slow.Next;
            fast = fast.Next.Next;
        }
        return slow;
    }
}
