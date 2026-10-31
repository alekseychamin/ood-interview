// «Паттерны Coding Interview», глава 3: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.LinkedLists;

public static class LinkedListIntersectionSolution {
    public static ListNode LinkedListIntersection(ListNode headA, ListNode headB) {
        ListNode ptrA = headA, ptrB = headB;
        // Проходим по спискам A и B с помощью указателей ptrA и ptrB, пока
        // они не встретятся.
        while (ptrA != ptrB) {
            // Обход списка A → B: если ptrA дошел до конца
            // списка A, начинаем обход с головы списка B.
            ptrA = ptrA != null ? ptrA.Next : headB;
            // Одновременно обходим список B → A.
            ptrB = ptrB != null ? ptrB.Next : headA;
        }
        // В этот момент ptrA и ptrB либо указывают на узел
        // пересечения, либо оба равны null (если пересечения нет).
        // Возвращаем любой из указателей.
        return ptrA;
    }
}
