// «Паттерны Coding Interview», глава 13: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Graphs;

public class MergingCommunities {
    private readonly UnionFind uf;

    public MergingCommunities(int n) {
        uf = new UnionFind(n);
    }

    public void Connect(int x, int y) {
        uf.Union(x, y);
    }

    public int GetCommunitySize(int x) {
        return uf.GetSize(x);
    }
}
