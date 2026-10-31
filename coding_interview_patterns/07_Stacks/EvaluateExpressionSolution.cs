// «Паттерны Coding Interview», глава 7: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Stacks;

public static class EvaluateExpressionSolution {
    public static int EvaluateExpression(string s) {
        var stack = new Stack<int>();
        int currNum = 0, sign = 1, res = 0;
        foreach (char c in s) {
            if (char.IsDigit(c)) {
                currNum = currNum * 10 + (c - '0');
            }
            // Если текущий символ — оператор, добавляем
            // currNum к результату после умножения на его знак.
            else if (c == '+' || c == '-') {
                res += currNum * sign;
                // Обновляем знак и сбрасываем currNum.
                sign = c == '-' ? -1 : 1;
                currNum = 0;
            }
            // Если текущий символ — открывающая скобка,
            // начинается новое вложенное выражение.
            else if (c == '(') {
                // Сохраняем текущие значения res и sign в
                // стеке, затем сбрасываем их для вычисления
                // нового выражения.
                stack.Push(res);
                stack.Push(sign);
                res = 0;
                sign = 1;
            }
            // Если текущий символ — закрывающая скобка, вложенное
            // выражение закончилось.
            else if (c == ')') {
                // Завершаем вычисление текущего вложенного
                // выражения.
                res += sign * currNum;
                // Применяем знак вложенного выражения и добавляем
                // результат к внешнему выражению.
                res *= stack.Pop();
                res += stack.Pop();
                currNum = 0;
            }
        }
        // Завершаем вычисление всего выражения.
        return res + currNum * sign;
    }
}
