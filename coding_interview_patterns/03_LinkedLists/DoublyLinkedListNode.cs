// «Паттерны Coding Interview», глава 3: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.LinkedLists;

public class DoublyLinkedListNode {
    public int Key;
    public int Val;
    public DoublyLinkedListNode Next;
    public DoublyLinkedListNode Prev;

    public DoublyLinkedListNode(int key, int val) {
        Key = key;
        Val = val;
    }
}
