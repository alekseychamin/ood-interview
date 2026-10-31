// «Паттерны Coding Interview», глава 3: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.LinkedLists;

public class LRUCache {
    private readonly int capacity;
    // Хеш-таблица, сопоставляющая ключи с узлами.
    private readonly Dictionary<int, DoublyLinkedListNode> hashmap = new();
    private readonly DoublyLinkedListNode head;
    private readonly DoublyLinkedListNode tail;

    public LRUCache(int capacity) {
        this.capacity = capacity;
        // Инициализируем фиктивные узлы head и tail
        // и связываем их друг с другом, формируя базовый
        // двусвязный список из двух узлов.
        head = new DoublyLinkedListNode(-1, -1);
        tail = new DoublyLinkedListNode(-1, -1);
        head.Next = tail;
        tail.Prev = head;
    }

    public int Get(int key) {
        if (!hashmap.TryGetValue(key, out DoublyLinkedListNode node)) {
            return -1;
        }
        // Чтобы сделать этот ключ наиболее недавно
        // использованным, удаляем его узел и повторно
        // добавляем его в хвост списка.
        RemoveNode(node);
        AddToTail(node);
        return node.Val;
    }

    public void Put(int key, int value) {
        // Если узел с таким ключом уже есть, удаляем его из
        // списка.
        if (hashmap.TryGetValue(key, out DoublyLinkedListNode existing)) {
            RemoveNode(existing);
        }
        DoublyLinkedListNode node = new DoublyLinkedListNode(key, value);
        hashmap[key] = node;
        // Если добавление нового узла приведет к
        // переполнению кэша, удаляем из него наиболее давно
        // использованный узел.
        if (hashmap.Count > capacity) {
            hashmap.Remove(head.Next.Key);
            RemoveNode(head.Next);
        }
        AddToTail(node);
    }

    private void AddToTail(DoublyLinkedListNode node) {
        DoublyLinkedListNode prevNode = tail.Prev;
        node.Prev = prevNode;
        node.Next = tail;
        prevNode.Next = node;
        tail.Prev = node;
    }

    private void RemoveNode(DoublyLinkedListNode node) {
        node.Prev.Next = node.Next;
        node.Next.Prev = node.Prev;
    }
}
