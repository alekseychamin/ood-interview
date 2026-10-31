// «Паттерны Coding Interview», глава 7: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Stacks;

public static class ValidParenthesisExpressionSolution {
    public static bool ValidParenthesisExpression(string s) {
        var parenthesesMap = new Dictionary<char, char> {
            ['('] = ')', ['{'] = '}', ['['] = ']'
        };
        var stack = new Stack<char>();
        foreach (char c in s) {
            // Если текущий символ — открывающая скобка, добавляем
            // ее в стек.
            if (parenthesesMap.ContainsKey(c)) {
                stack.Push(c);
            }
            // Если текущий символ — закрывающая скобка,
            // проверяем, закрывает ли она открывающую скобку,
            // находящуюся на вершине стека.
            else {
                if (stack.Count > 0 && parenthesesMap[stack.Peek()] == c) {
                    stack.Pop();
                } else {
                    return false;
                }
            }
        }
        // Если стек пуст, все открывающие скобки успешно закрыты.
        return stack.Count == 0;
    }
}
