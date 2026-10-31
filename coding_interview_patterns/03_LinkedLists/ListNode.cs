// «Паттерны Coding Interview», глава 3: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns;

public class ListNode {
    public int Val;
    public ListNode Next;

    public ListNode(int val, ListNode next = null) {
        Val = val;
        Next = next;
    }
}
