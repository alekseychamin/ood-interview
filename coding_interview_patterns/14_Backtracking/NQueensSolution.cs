// «Паттерны Coding Interview», глава 14: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Backtracking;

public static class NQueensSolution {
    private static int res = 0;

    public static int NQueens(int n) {
        res = 0;
        Dfs(0, new HashSet<int>(), new HashSet<int>(), new HashSet<int>(), n);
        return res;
    }

    private static void Dfs(int r, HashSet<int> diagonalsSet,
                            HashSet<int> antiDiagonalsSet,
                            HashSet<int> colsSet, int n) {
        // Условие завершения: если дошли до конца строк,
        // значит, все n ферзей размещены.
        if (r == n) {
            res++;
            return;
        }
        for (int c = 0; c < n; c++) {
            int currDiagonal = r - c;
            int currAntiDiagonal = r + c;
            // Пропускаем клетку, если на текущем столбце,
            // диагонали или антидиагонали уже есть ферзь.
            if (colsSet.Contains(c) || diagonalsSet.Contains(currDiagonal) ||
                antiDiagonalsSet.Contains(currAntiDiagonal)) {
                continue;
            }
            // Размещаем ферзя, помечая текущий столбец, диагональ
            // и антидиагональ как занятые.
            colsSet.Add(c);
            diagonalsSet.Add(currDiagonal);
            antiDiagonalsSet.Add(currAntiDiagonal);
            // Рекурсивно переходим к следующей строке, продолжая
            // размещение ферзей.
            Dfs(r + 1, diagonalsSet, antiDiagonalsSet, colsSet, n);
            // Возврат к предыдущему состоянию осуществляется
            // удалением текущего столбца, диагонали и
            // антидиагонали из хеш-множеств.
            colsSet.Remove(c);
            diagonalsSet.Remove(currDiagonal);
            antiDiagonalsSet.Remove(currAntiDiagonal);
        }
    }
}
