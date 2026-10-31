// «Паттерны Coding Interview», глава 13: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Graphs;

public class GraphNode {
    public int Val;
    public List<GraphNode> Neighbors = new();

    public GraphNode(int val) {
        Val = val;
    }
}
