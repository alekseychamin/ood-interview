// «Паттерны Coding Interview», глава 13: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Graphs;

public class UnionFind {
    private readonly int[] parent;
    private readonly int[] size;

    public UnionFind(int size) {
        parent = new int[size];
        this.size = new int[size];
        for (int i = 0; i < size; i++) {
            parent[i] = i;
            this.size[i] = 1;
        }
    }

    public void Union(int x, int y) {
        int repX = Find(x), repY = Find(y);
        if (repX != repY) {
            // Если repX представляет более крупное
            // сообщество, соединяем с ним сообщество repY.
            if (size[repX] > size[repY]) {
                parent[repY] = repX;
                size[repX] += size[repY];
            }
            // В противном случае соединяем сообщество repX с
            // repY.
            else {
                parent[repX] = repY;
                size[repY] += size[repX];
            }
        }
    }

    public int Find(int x) {
        if (x == parent[x]) {
            return x;
        }
        // Сжатие путей.
        parent[x] = Find(parent[x]);
        return parent[x];
    }

    public int GetSize(int x) {
        return size[Find(x)];
    }
}
