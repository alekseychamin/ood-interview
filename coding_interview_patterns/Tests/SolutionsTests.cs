using CodingInterviewPatterns.Backtracking;
using CodingInterviewPatterns.BinarySearch;
using CodingInterviewPatterns.BitManipulation;
using CodingInterviewPatterns.DynamicProgramming;
using CodingInterviewPatterns.FastAndSlowPointers;
using CodingInterviewPatterns.Graphs;
using CodingInterviewPatterns.Greedy;
using CodingInterviewPatterns.HashMapsAndSets;
using CodingInterviewPatterns.Heaps;
using CodingInterviewPatterns.Intervals;
using CodingInterviewPatterns.LinkedLists;
using CodingInterviewPatterns.MathAndGeometry;
using CodingInterviewPatterns.PrefixSums;
using CodingInterviewPatterns.SlidingWindows;
using CodingInterviewPatterns.SortAndSearch;
using CodingInterviewPatterns.Stacks;
using CodingInterviewPatterns.Trees;
using CodingInterviewPatterns.Tries;
using CodingInterviewPatterns.TwoPointers;

namespace CodingInterviewPatterns.Tests;

// Small smoke tests for every compiled listing, using the examples from the book.
public class SolutionsTests {
    private static ListNode MakeList(params int[] values) {
        ListNode dummy = new ListNode(0);
        ListNode curr = dummy;
        foreach (int v in values) {
            curr.Next = new ListNode(v);
            curr = curr.Next;
        }
        return dummy.Next;
    }

    private static List<int> Values(ListNode head) {
        var res = new List<int>();
        for (ListNode n = head; n != null; n = n.Next) {
            res.Add(n.Val);
        }
        return res;
    }

    private static int[][] Grid(params int[][] rows) => rows;

    //        1
    //      /   \
    //     2     3
    //    / \     \
    //   4   5     6
    private static TreeNode SampleTree(out TreeNode n4, out TreeNode n5, out TreeNode n6) {
        var root = new TreeNode(1) {
            Left = new TreeNode(2) { Left = new TreeNode(4), Right = new TreeNode(5) },
            Right = new TreeNode(3) { Right = new TreeNode(6) },
        };
        n4 = root.Left.Left;
        n5 = root.Left.Right;
        n6 = root.Right.Right;
        return root;
    }

    // ---- 1. Two pointers
    [Fact]
    public void TwoPointers() {
        int[] sorted = [-5, -2, 3, 4, 6];
        Assert.Equal(new[] { 2, 3 }, PairSumSortedSolution.PairSumSorted(sorted, 7));
        Assert.Equal(new[] { 2, 3 }, PairSumSortedSolution.PairSumSortedBruteForce(sorted, 7));
        Assert.Empty(PairSumSortedSolution.PairSumSorted(sorted, 100));

        var expected = new List<List<int>> { new() { -3, 1, 2 }, new() { -1, 0, 1 } };
        Assert.Equal(expected, TripletSumSolution.TripletSum([0, -1, 2, -3, 1]));
        Assert.Equal(expected, TripletSumSolution.TripletSumBruteForce([0, -1, 2, -3, 1])
            .OrderBy(t => t[0]).ToList());
        Assert.Equal(new List<List<int>> { new() { -1, -1, 2 } }, TripletSumSolution.TripletSum([-1, 2, -1, 2]));

        Assert.True(IsPalindromeValidSolution.IsPalindromeValid("a dog! a panic in a pagoda."));
        Assert.False(IsPalindromeValidSolution.IsPalindromeValid("abc123"));

        int[] heights = [2, 7, 8, 3, 7, 6];
        Assert.Equal(24, LargestContainerSolution.LargestContainer(heights));
        Assert.Equal(24, LargestContainerSolution.LargestContainerBruteForce(heights));
    }

    // ---- 2. Hash maps and sets
    [Fact]
    public void HashMapsAndSets() {
        Assert.Equal(new[] { 0, 2 }, PairSumUnsortedSolution.PairSumUnsorted([-1, 3, 4, 2], 3));
        Assert.Equal(new[] { 0, 2 }, PairSumUnsortedSolution.PairSumUnsortedTwoPass([-1, 3, 4, 2], 3));

        int[][] board = new int[9][];
        for (int i = 0; i < 9; i++) {
            board[i] = new int[9];
        }
        board[0][0] = 5; board[1][1] = 3; board[4][4] = 7;
        Assert.True(VerifySudokuBoardSolution.VerifySudokuBoard(board));
        board[2][2] = 5; // same 3x3 subgrid as board[0][0]
        Assert.False(VerifySudokuBoardSolution.VerifySudokuBoard(board));

        int[][] Matrix() => Grid([1, 2, 3, 4, 5], [6, 0, 8, 9, 10], [11, 12, 13, 14, 15], [16, 17, 18, 19, 0]);
        int[][] expected = Grid([1, 0, 3, 4, 0], [0, 0, 0, 0, 0], [11, 0, 13, 14, 0], [0, 0, 0, 0, 0]);
        var m1 = Matrix();
        ZeroStripingSolution.ZeroStriping(m1);
        Assert.Equal(expected, m1);
        var m2 = Matrix();
        ZeroStripingSolution.ZeroStripingHashSets(m2);
        Assert.Equal(expected, m2);
    }

    // ---- 3. Linked lists
    [Fact]
    public void LinkedLists() {
        Assert.Equal(new[] { 5, 4, 3, 2, 1 }, Values(LinkedListReversalSolution.LinkedListReversal(MakeList(1, 2, 3, 4, 5))));
        Assert.Equal(new[] { 5, 4, 3, 2, 1 }, Values(LinkedListReversalSolution.LinkedListReversalRecursive(MakeList(1, 2, 3, 4, 5))));
        Assert.Equal(new[] { 1, 2, 3, 5 }, Values(RemoveKthLastNodeSolution.RemoveKthLastNode(MakeList(1, 2, 3, 4, 5), 2)));
        Assert.Equal(new[] { 1, 2 }, Values(RemoveKthLastNodeSolution.RemoveKthLastNode(MakeList(1, 2), 5)));

        ListNode shared = MakeList(8, 9);
        ListNode a = new ListNode(1, new ListNode(2, shared));
        ListNode b = new ListNode(7, shared);
        Assert.Same(shared, LinkedListIntersectionSolution.LinkedListIntersection(a, b));
        Assert.Null(LinkedListIntersectionSolution.LinkedListIntersection(MakeList(1), MakeList(2)));

        var cache = new LRUCache(3);
        cache.Put(1, 100);
        cache.Put(2, 250);
        Assert.Equal(250, cache.Get(2));
        cache.Put(4, 300);
        cache.Put(3, 200);   // evicts key 1
        Assert.Equal(300, cache.Get(4));
        Assert.Equal(-1, cache.Get(1));
    }

    // ---- 4. Fast and slow pointers
    [Fact]
    public void FastAndSlowPointers() {
        ListNode head = MakeList(0, 1, 2, 3, 4, 5);
        Assert.False(LinkedListLoopSolution.LinkedListLoop(head));
        Assert.False(LinkedListLoopSolution.LinkedListLoopNaive(head));
        ListNode tail = head;
        while (tail.Next != null) {
            tail = tail.Next;
        }
        tail.Next = head.Next.Next; // 5 -> 2
        Assert.True(LinkedListLoopSolution.LinkedListLoop(head));
        Assert.True(LinkedListLoopSolution.LinkedListLoopNaive(head));

        Assert.Equal(4, LinkedListMidpointSolution.LinkedListMidpoint(MakeList(1, 2, 3, 4, 5, 6)).Val);
        Assert.Equal(3, LinkedListMidpointSolution.LinkedListMidpoint(MakeList(1, 2, 3, 4, 5)).Val);

        Assert.True(HappyNumberSolution.HappyNumber(23));
        Assert.False(HappyNumberSolution.HappyNumber(116));
    }

    // ---- 5. Sliding windows
    [Fact]
    public void SlidingWindows() {
        Assert.Equal(2, SubstringAnagramsSolution.SubstringAnagrams("caabab", "aba"));
        Assert.Equal(3, LongestSubstringWithUniqueCharsSolution.LongestSubstringWithUniqueChars("abcba"));
        Assert.Equal(3, LongestSubstringWithUniqueCharsSolution.LongestSubstringWithUniqueChars("abcab"));
        Assert.Equal(3, LongestSubstringWithUniqueCharsSolution.LongestSubstringWithUniqueCharsOptimized("abcab"));
        Assert.Equal(5, LongestUniformSubstringAfterReplacementsSolution.LongestUniformSubstringAfterReplacements("aabcdcca", 2));
    }

    // ---- 6. Binary search
    [Fact]
    public void BinarySearch() {
        Assert.Equal(2, FindTheInsertionIndexSolution.FindTheInsertionIndex([1, 2, 4, 5, 7, 8, 9], 4));
        Assert.Equal(4, FindTheInsertionIndexSolution.FindTheInsertionIndex([1, 2, 4, 5, 7, 8, 9], 6));
        Assert.Equal(new[] { 3, 5 }, FirstAndLastOccurrencesOfANumberSolution.FirstAndLastOccurrencesOfANumber([1, 2, 3, 4, 4, 4, 5, 6, 7, 8, 9, 10, 11], 4));
        Assert.Equal(new[] { -1, -1 }, FirstAndLastOccurrencesOfANumberSolution.FirstAndLastOccurrencesOfANumber([1, 2, 3], 4));
        Assert.Equal(3, CuttingWoodSolution.CuttingWood([2, 6, 3, 8], 7));
        Assert.Equal(2, FindTheTargetInARotatedSortedArraySolution.FindTheTargetInARotatedSortedArray([8, 9, 1, 2, 3, 4, 5, 6, 7], 1));
        Assert.Equal(-1, FindTheTargetInARotatedSortedArraySolution.FindTheTargetInARotatedSortedArray([8, 9, 1, 2, 3], 10));
    }

    // ---- 7. Stacks
    [Fact]
    public void Stacks() {
        Assert.True(ValidParenthesisExpressionSolution.ValidParenthesisExpression("([]{})"));
        Assert.False(ValidParenthesisExpressionSolution.ValidParenthesisExpression("([]{)}"));
        Assert.Equal(new[] { -1, 3, 3, -1, -1 }, NextLargestNumberToTheRightSolution.NextLargestNumberToTheRight([5, 2, 1, 3, 3]));
        Assert.Equal(-4, EvaluateExpressionSolution.EvaluateExpression("18-(7+(2-4))-(17)"));
        Assert.Equal(7, EvaluateExpressionSolution.EvaluateExpression("1+(2+4)"));
    }

    // ---- 8. Heaps
    [Fact]
    public void Heaps() {
        string[] strs = ["go", "coding", "byte", "byte", "go", "interview", "go"];
        Assert.Equal(new[] { "go", "byte" }, KMostFrequentStringsMaxHeapSolution.KMostFrequentStringsMaxHeap(strs, 2));
        Assert.Equal(new[] { "go", "byte" }, KMostFrequentStringsMinHeapSolution.KMostFrequentStringsMinHeap(strs, 2));

        var merged = CombineSortedLinkedListsSolution.CombineSortedLinkedLists([MakeList(1, 6), MakeList(1, 4, 6), MakeList(3, 7)]);
        Assert.Equal(new[] { 1, 1, 3, 4, 6, 6, 7 }, Values(merged));

        var stream = new MedianOfAnIntegerStream();
        stream.Add(3);
        stream.Add(6);
        Assert.Equal(4.5, stream.GetMedian());
        stream.Add(1);
        Assert.Equal(3.0, stream.GetMedian());
    }

    // ---- 9. Intervals
    [Fact]
    public void Intervals() {
        var merged = MergeOverlappingIntervalsSolution.MergeOverlappingIntervals(
            [new(3, 4), new(7, 8), new(2, 5), new(6, 7), new(1, 4)]);
        Assert.Equal(new[] { (1, 5), (6, 8) }, merged.Select(i => (i.Start, i.End)));

        var overlaps = IdentifyAllIntervalOverlapsSolution.IdentifyAllIntervalOverlaps(
            [new(1, 4), new(5, 6), new(9, 10)], [new(2, 7), new(8, 9)]);
        Assert.Equal(new[] { (2, 4), (5, 6), (9, 9) }, overlaps.Select(i => (i.Start, i.End)));

        Assert.Equal(3, LargestOverlapOfIntervalsSolution.LargestOverlapOfIntervals(
            [new(1, 3), new(5, 7), new(2, 6), new(4, 8)]));
    }

    // ---- 10. Prefix sums
    [Fact]
    public void PrefixSums() {
        Assert.Equal(new[] { 3, 5, 9, 11 }, ComputePrefixSumsSolution.ComputePrefixSums([3, 2, 4, 2]));
        var range = new SumBetweenRange([3, -7, 6, 0, -2, 5]);
        Assert.Equal(2, range.SumRange(0, 3));
        Assert.Equal(4, range.SumRange(2, 4));
        Assert.Equal(6, range.SumRange(2, 2));
        Assert.Equal(3, KSumSubarraysSolution.KSumSubarrays([1, 2, -1, 1, 2], 3));
        Assert.Equal(3, KSumSubarraysSolution.KSumSubarraysOptimized([1, 2, -1, 1, 2], 3));
        Assert.Equal(new[] { 20, 8, 40, 10 }, ProductArrayWithoutCurrentElementSolution.ProductArrayWithoutCurrentElement([2, 5, 1, 4]));
    }

    // ---- 11. Trees
    [Fact]
    public void Trees() {
        TreeNode root = SampleTree(out TreeNode n4, out TreeNode n5, out TreeNode n6);
        Assert.True(BalancedBinaryTreeValidationSolution.BalancedBinaryTreeValidation(root));
        Assert.Equal(new[] { 1, 3, 6 }, RightmostNodesOfABinaryTreeSolution.RightmostNodesOfABinaryTree(root));
        Assert.Equal(4, WidestBinaryTreeLevelSolution.WidestBinaryTreeLevel(root));
        Assert.Same(root.Left, LowestCommonAncestorSolution.LowestCommonAncestor(root, n4, n5));
        Assert.Same(root, LowestCommonAncestorSolution.LowestCommonAncestor(root, n4, n6));
        Assert.Equal(17, MaxPathSumSolution.MaxPathSum(root)); // 5 + 2 + 1 + 3 + 6
        Assert.False(BinarySearchTreeValidationSolution.BinarySearchTreeValidation(root));

        var bst = new TreeNode(5) { Left = new TreeNode(2) { Left = new TreeNode(1) }, Right = new TreeNode(7) };
        Assert.True(BinarySearchTreeValidationSolution.BinarySearchTreeValidation(bst));

        TreeNode inverted = InvertBinaryTreeSolution.InvertBinaryTreeRecursive(SampleTree(out _, out _, out _));
        Assert.Equal(3, inverted.Left.Val);
        Assert.Equal(6, inverted.Left.Left.Val);
        TreeNode inverted2 = InvertBinaryTreeSolution.InvertBinaryTreeIterative(SampleTree(out _, out _, out _));
        Assert.Equal(5, inverted2.Right.Left.Val);

        TreeNode built = BuildBinaryTreeSolution.BuildBinaryTree([5, 9, 2, 3, 4, 7], [2, 9, 5, 4, 3, 7]);
        Assert.Equal(5, built.Val);
        Assert.Equal(9, built.Left.Val);
        Assert.Equal(2, built.Left.Left.Val);
        Assert.Equal(3, built.Right.Val);
        Assert.Equal(4, built.Right.Left.Val);
        Assert.Equal(7, built.Right.Right.Val);
    }

    // ---- 12. Tries
    [Fact]
    public void Tries() {
        var trie = new Trie();
        trie.Insert("top");
        trie.Insert("bye");
        Assert.True(trie.HasPrefix("to"));
        Assert.False(trie.Search("to"));
        trie.Insert("to");
        Assert.True(trie.Search("to"));
        Assert.False(trie.HasPrefix("bya"));

        var wild = new InsertAndSearchWordsWithWildcards();
        wild.Insert("band");
        wild.Insert("rat");
        Assert.True(wild.Search("ra."));
        Assert.False(wild.Search("b.."));
        wild.Insert("ran");
        Assert.True(wild.Search(".an"));
        Assert.False(wild.Search("..x"));

        char[][] board = [
            ['b', 'y', 's'],
            ['r', 't', 'e'],
            ['a', 'i', 'n'],
        ];
        var found = FindAllWordsOnABoardSolution.FindAllWordsOnABoard(board, ["byte", "bytes", "rat", "rain", "trait", "train"]);
        Assert.Equal(new[] { "byte", "bytes", "rain", "train" }, found.Order());
    }

    // ---- 13. Graphs
    [Fact]
    public void Graphs() {
        var n0 = new GraphNode(0);
        var n1 = new GraphNode(1);
        var n2 = new GraphNode(2);
        n0.Neighbors.AddRange([n1, n2]);
        n1.Neighbors.Add(n0);
        n2.Neighbors.Add(n0);
        GraphNode copy = GraphDeepCopySolution.GraphDeepCopy(n0);
        Assert.NotSame(n0, copy);
        Assert.Equal(2, copy.Neighbors.Count);
        Assert.Same(copy, copy.Neighbors[0].Neighbors[0]);

        Assert.Equal(2, CountIslandsSolution.CountIslands(Grid([1, 1, 0, 0], [1, 1, 0, 0], [0, 0, 1, 1], [0, 0, 0, 1])));
        Assert.Equal(3, MatrixInfectionSolution.MatrixInfection(Grid([1, 1, 1, 0], [0, 0, 2, 1], [0, 1, 1, 0])));
        Assert.Equal(-1, MatrixInfectionSolution.MatrixInfection(Grid([2, 0, 1])));

        Assert.True(BipartiteGraphValidationSolution.BipartiteGraphValidation([[1, 4], [0, 2], [1], [4], [0, 3]]));
        Assert.False(BipartiteGraphValidationSolution.BipartiteGraphValidation([[1, 2], [0, 2], [0, 1]]));

        Assert.Equal(5, LongestIncreasingPathSolution.LongestIncreasingPath(Grid([1, 5, 8], [3, 4, 4], [7, 9, 2])));

        string[] dictionary = ["red", "bed", "hat", "rod", "rad", "rat", "hit", "bad", "bat"];
        Assert.Equal(5, ShortestTransformationSequenceSolution.ShortestTransformationSequence("red", "hit", dictionary));
        Assert.Equal(5, ShortestTransformationSequenceSolution.ShortestTransformationSequenceOptimized("red", "hit", dictionary));

        var communities = new MergingCommunities(5);
        communities.Connect(0, 1);
        communities.Connect(1, 2);
        Assert.Equal(1, communities.GetCommunitySize(3));
        Assert.Equal(3, communities.GetCommunitySize(0));
        communities.Connect(3, 4);
        Assert.Equal(2, communities.GetCommunitySize(4));

        Assert.True(PrerequisitesSolution.Prerequisites(3, [[0, 1], [1, 2]]));
        Assert.False(PrerequisitesSolution.Prerequisites(3, [[0, 1], [1, 2], [2, 1]]));
    }

    // ---- 14. Backtracking
    [Fact]
    public void Backtracking() {
        var perms = FindAllPermutationsSolution.FindAllPermutations([4, 5, 6]);
        Assert.Equal(6, perms.Count);
        Assert.Equal(new[] { 4, 5, 6 }, perms[0]);
        var subsets = FindAllSubsetsSolution.FindAllSubsets([4, 5, 6]);
        Assert.Equal(8, subsets.Count);
        Assert.Contains(subsets, s => s.Count == 0);
        Assert.Equal(2, NQueensSolution.NQueens(4));
        Assert.Equal(92, NQueensSolution.NQueens(8));
    }

    // ---- 15. Dynamic programming
    [Fact]
    public void DynamicProgramming() {
        Assert.Equal(8, ClimbingStairsTopDownSolution.ClimbingStairsTopDown(5));
        Assert.Equal(8, ClimbingStairsBottomUpSolution.ClimbingStairsBottomUp(5));
        Assert.Equal(8, ClimbingStairsBottomUpSolution.ClimbingStairsBottomUpOptimized(5));

        Assert.Equal(3, MinCoinCombinationSolution.MinCoinCombinationTopDown([1, 2, 3], 7)); // 7 = 3 + 3 + 1
        Assert.Equal(3, MinCoinCombinationSolution.MinCoinCombinationBottomUp([1, 2, 3], 7));
        Assert.Equal(-1, MinCoinCombinationSolution.MinCoinCombinationBottomUp([2], 3));
        Assert.Equal(-1, MinCoinCombinationSolution.MinCoinCombinationTopDown([2], 3));

        Assert.Equal(10, MatrixPathwaysSolution.MatrixPathways(3, 4));
        Assert.Equal(10, MatrixPathwaysSolution.MatrixPathwaysOptimized(3, 4));

        Assert.Equal(400, NeighborhoodBurglarySolution.NeighborhoodBurglary([200, 300, 200, 50]));
        Assert.Equal(400, NeighborhoodBurglarySolution.NeighborhoodBurglaryOptimized([200, 300, 200, 50]));

        Assert.Equal(3, LongestCommonSubsequenceSolution.LongestCommonSubsequence("acabac", "aebab"));
        Assert.Equal(3, LongestCommonSubsequenceSolution.LongestCommonSubsequenceOptimized("acabac", "aebab"));

        Assert.Equal("abccba", LongestPalindromeInAStringSolution.LongestPalindromeInAString("abccbaba"));
        Assert.Equal("abccba", LongestPalindromeInAStringSolution.LongestPalindromeInAStringExpanding("abccbaba"));

        int[] nums = [3, 1, -6, 2, -1, 4, -9];
        Assert.Equal(5, MaximumSubarraySumSolution.MaximumSubarraySum(nums));
        Assert.Equal(5, MaximumSubarraySumSolution.MaximumSubarraySumDp(nums));
        Assert.Equal(5, MaximumSubarraySumSolution.MaximumSubarraySumDpOptimized(nums));
        Assert.Equal(-2, MaximumSubarraySumSolution.MaximumSubarraySum([-3, -2, -5]));

        Assert.Equal(90, KnapsackSolution.Knapsack(7, [5, 3, 4, 1], [70, 50, 40, 10]));
        Assert.Equal(90, KnapsackSolution.KnapsackOptimized(7, [5, 3, 4, 1], [70, 50, 40, 10]));
    }

    // ---- 16. Greedy
    [Fact]
    public void Greedy() {
        Assert.True(JumpToTheEndSolution.JumpToTheEnd([3, 2, 0, 2, 5]));
        Assert.False(JumpToTheEndSolution.JumpToTheEnd([2, 1, 0, 3]));
        Assert.Equal(1, GasStationsSolution.GasStations([2, 5, 1, 3], [3, 2, 1, 4]));
        Assert.Equal(-1, GasStationsSolution.GasStations([1, 1], [2, 2]));
        Assert.Equal(12, CandiesSolution.Candies([4, 3, 2, 4, 5, 1]));
    }

    // ---- 17. Sorting and searching
    [Fact]
    public void SortAndSearch() {
        Assert.Equal(new[] { -2, 1, 3, 3, 4, 5 }, Values(SortLinkedListSolution.SortLinkedList(MakeList(3, -2, 4, 5, 1, 3))));
        Assert.Equal(new[] { 1, 2, 3, 4, 6, 8 }, SortArraySolution.SortArray([6, 8, 4, 2, 1, 3]));
        Assert.Equal(new[] { 0, 1, 1, 2, 3, 5 }, SortArrayCountingSortSolution.SortArrayCountingSort([3, 1, 5, 2, 1, 0]));
        Assert.Equal(4, KthLargestIntegerMinHeapSolution.KthLargestIntegerMinHeap([5, 2, 4, 3, 1, 6], 3));
        Assert.Equal(4, KthLargestIntegerQuickselectSolution.KthLargestIntegerQuickselect([5, 2, 4, 3, 1, 6], 3));
    }

    // ---- 18. Bit manipulation
    [Fact]
    public void BitManipulation() {
        Assert.Equal(new[] { 0, 1, 1, 2, 1, 2, 2, 3 }, HammingWeightsOfIntegersSolution.HammingWeightsOfIntegers(7));
        Assert.Equal(new[] { 0, 1, 1, 2, 1, 2, 2, 3 }, HammingWeightsOfIntegersSolution.HammingWeightsOfIntegersDp(7));
        Assert.Equal(2, LonelyIntegerSolution.LonelyInteger([1, 3, 3, 2, 1]));
        Assert.Equal(22u, SwapOddAndEvenBitsSolution.SwapOddAndEvenBits(41u)); // 101001 -> 010110
    }

    // ---- 19. Math and geometry
    [Fact]
    public void MathAndGeometry() {
        int[][] matrix = Grid([0, 1, 2, 3, 4], [5, 6, 7, 8, 9], [10, 11, 12, 13, 14], [15, 16, 17, 18, 19]);
        Assert.Equal(new[] { 0, 1, 2, 3, 4, 9, 14, 19, 18, 17, 16, 15, 10, 5, 6, 7, 8, 13, 12, 11 },
                     SpiralMatrixSolution.SpiralMatrix(matrix));
        Assert.Equal(-15, Reverse32BitIntegerSolution.Reverse32BitInteger(-51));
        Assert.Equal(42, Reverse32BitIntegerSolution.Reverse32BitInteger(240));
        Assert.Equal(0, Reverse32BitIntegerSolution.Reverse32BitInteger(int.MaxValue)); // 7463847412 overflows
        Assert.Equal(4, MaximumCollinearPointsSolution.MaximumCollinearPoints(
            [[1, 1], [1, 3], [2, 2], [3, 1], [3, 3], [4, 4]]));
        // points on one line in both directions from the focal point share one slope key
        Assert.Equal(3, MaximumCollinearPointsSolution.MaximumCollinearPoints([[0, 0], [1, -2], [-1, 2]]));
    }
}
