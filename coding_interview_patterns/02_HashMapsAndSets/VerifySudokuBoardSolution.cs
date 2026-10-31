// «Паттерны Coding Interview», глава 2: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.HashMapsAndSets;

public static class VerifySudokuBoardSolution {
    public static bool VerifySudokuBoard(int[][] board) {
        // Создаем хеш-наборы для каждых строки, столбца и
        // блока, чтобы отслеживать уже встречавшиеся числа.
        HashSet<int>[] rowSets =
            Enumerable.Range(0, 9).Select(_ => new HashSet<int>()).ToArray();
        HashSet<int>[] colSets =
            Enumerable.Range(0, 9).Select(_ => new HashSet<int>()).ToArray();
        HashSet<int>[][] subgridSets = Enumerable.Range(0, 3)
            .Select(_ => Enumerable.Range(0, 3)
                                   .Select(_ => new HashSet<int>()).ToArray())
            .ToArray();
        for (int r = 0; r < 9; r++) {
            for (int c = 0; c < 9; c++) {
                int num = board[r][c];
                if (num == 0) {
                    continue;
                }
                // Проверяем, встречалось ли число num ранее
                // в текущих строке, столбце или блоке.
                if (rowSets[r].Contains(num)) {
                    return false;
                }
                if (colSets[c].Contains(num)) {
                    return false;
                }
                if (subgridSets[r / 3][c / 3].Contains(num)) {
                    return false;
                }
                // Если число прошло все вышеуказанные проверки,
                // помечаем его как уже проверенное, добавляя в
                // соответствующие хеш-множества.
                rowSets[r].Add(num);
                colSets[c].Add(num);
                subgridSets[r / 3][c / 3].Add(num);
            }
        }
        return true;
    }
}
