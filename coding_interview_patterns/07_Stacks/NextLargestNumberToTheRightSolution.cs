// «Паттерны Coding Interview», глава 7: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Stacks;

public static class NextLargestNumberToTheRightSolution {
    public static int[] NextLargestNumberToTheRight(int[] nums) {
        int[] res = new int[nums.Length];
        var stack = new Stack<int>();
        // Находим следующее наибольшее число для каждого элемента,
        // начиная с правого конца массива.
        for (int i = nums.Length - 1; i >= 0; i--) {
            // Удаляем значения с вершины стека, пока следующее
            // наибольшее число текущего значения не окажется на
            // вершине.
            while (stack.Count > 0 && stack.Peek() <= nums[i]) {
                stack.Pop();
            }
            // Записываем следующее наибольшее число для текущего значения, которое
            // находится на вершине стека. Если стек пуст, записываем -1.
            res[i] = stack.Count > 0 ? stack.Peek() : -1;
            stack.Push(nums[i]);
        }
        return res;
    }
}
