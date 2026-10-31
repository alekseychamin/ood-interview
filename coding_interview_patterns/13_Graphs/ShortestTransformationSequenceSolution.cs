// «Паттерны Coding Interview», глава 13: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Graphs;

public static class ShortestTransformationSequenceSolution {
    public static int ShortestTransformationSequence(string start, string end,
                                                     string[] dictionary) {
        var dictionarySet = new HashSet<string>(dictionary);
        if (!dictionarySet.Contains(start) || !dictionarySet.Contains(end)) {
            return 0;
        }
        if (start == end) {
            return 1;
        }
        const string lowerCaseAlphabet = "abcdefghijklmnopqrstuvwxyz";
        var queue = new Queue<string>([start]);
        var visited = new HashSet<string> { start };
        int dist = 0;
        // Используем обход по уровням, чтобы найти кратчайший
        // путь от начального слова до конечного.
        while (queue.Count > 0) {
            int levelSize = queue.Count;
            for (int k = 0; k < levelSize; k++) {
                string currWord = queue.Dequeue();
                // Если мы нашли конечное слово, значит, пошли по
                // кратчайшему пути.
                if (currWord == end) {
                    return dist + 1;
                }
                // Генерация всех слов, которые отличаются на одну
                // букву.
                for (int i = 0; i < currWord.Length; i++) {
                    foreach (char c in lowerCaseAlphabet) {
                        string nextWord = currWord[..i] + c + currWord[(i + 1)..];
                        // Если слово есть в словаре и еще не
                        // посещено, добавляем его в очередь для
                        // обработки.
                        if (dictionarySet.Contains(nextWord)
                            && !visited.Contains(nextWord)) {
                            visited.Add(nextWord);
                            queue.Enqueue(nextWord);
                        }
                    }
                }
            }
            dist++;
        }
        // Если путь к конечному слову не найден, возвращаем 0.
        return 0;
    }

    public static int ShortestTransformationSequenceOptimized(
        string start, string end, string[] dictionary) {
        var dictionarySet = new HashSet<string>(dictionary);
        if (!dictionarySet.Contains(start) || !dictionarySet.Contains(end)) {
            return 0;
        }
        if (start == end) {
            return 1;
        }
        var startQueue = new Queue<string>([start]);
        var startVisited = new HashSet<string> { start };
        var endQueue = new Queue<string>([end]);
        var endVisited = new HashSet<string> { end };
        int levelStart = 0, levelEnd = 0;
        // Выполняем обход по уровням от начального слова и
        // одновременно от конечного слова.
        while (startQueue.Count > 0 && endQueue.Count > 0) {
            // Исследуем следующий уровень обхода, начинающегося с
            // начального слова. Если он встречается с другим
            // обходом, значит, найден кратчайший путь между
            // начальным и конечным словами.
            levelStart++;
            if (ExploreLevel(
                startQueue, startVisited, endVisited, dictionarySet)) {
                return levelStart + levelEnd + 1;
            }
            // Исследуем следующий уровень обхода, начинающегося с
            // конечного слова.
            levelEnd++;
            if (ExploreLevel(
                endQueue, endVisited, startVisited, dictionarySet)) {
                return levelStart + levelEnd + 1;
            }
        }
        // Если обходы так и не встретились, пути не существует.
        return 0;
    }

    // Функция обрабатывает следующий уровень в обходе по уровням
    // и проверяет, встретились ли два обхода.
    private static bool ExploreLevel(Queue<string> queue, HashSet<string> visited,
                                     HashSet<string> otherVisited,
                                     HashSet<string> dictionarySet) {
        const string lowerCaseAlphabet = "abcdefghijklmnopqrstuvwxyz";
        int levelSize = queue.Count;
        for (int k = 0; k < levelSize; k++) {
            string currentWord = queue.Dequeue();
            for (int i = 0; i < currentWord.Length; i++) {
                foreach (char c in lowerCaseAlphabet) {
                    string nextWord =
                        currentWord[..i] + c + currentWord[(i + 1)..];
                    // Если nextWord уже посещено другим
                    // обходом, значит, обходы встретились.
                    if (otherVisited.Contains(nextWord)) {
                        return true;
                    }
                    if (dictionarySet.Contains(nextWord)
                        && !visited.Contains(nextWord)) {
                        visited.Add(nextWord);
                        queue.Enqueue(nextWord);
                    }
                }
            }
        }
        // Если ни одно слово еще не посещено другим обходом,
        // обходы не встретились.
        return false;
    }
}
