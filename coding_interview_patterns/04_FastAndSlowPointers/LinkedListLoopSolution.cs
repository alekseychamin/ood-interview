// «Паттерны Coding Interview», глава 4: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.FastAndSlowPointers;

public static class LinkedListLoopSolution {
    public static bool LinkedListLoopNaive(ListNode head) {
        var visited = new HashSet<ListNode>();
        ListNode curr = head;
        while (curr != null) {
            // Цикл обнаружен, если текущий узел уже был посещен ранее.
            if (visited.Contains(curr)) {
                return true;
            }
            visited.Add(curr);
            curr = curr.Next;
        }
        return false;
    }

    public static bool LinkedListLoop(ListNode head) {
        ListNode slow = head, fast = head;
        // Проверяем и fast, и fast.Next, чтобы избежать
        // ошибок при обращении к fast.Next и fast.Next.Next.
        while (fast != null && fast.Next != null) {
            slow = slow.Next;
            fast = fast.Next.Next;
            if (fast == slow) {
                return true;
            }
        }
        return false;
    }
}
