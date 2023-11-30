namespace BlockedNQueensBFS;

public class Program
{
    static void Main()
    {
        int n = 8;
        List<Tuple<int, int>> blockedPositions = new List<Tuple<int, int>>
        {
            new Tuple<int, int>(2, 3),
            new Tuple<int, int>(4, 1),
            new Tuple<int, int>(5, 7)
        };

        List<int[]> solutions = BlockedNQueensBFS.SolveBlockedNQueens(n, blockedPositions);

        for (int i = 0; i < solutions.Count; i++)
        {
            Console.WriteLine($"Solution {i + 1}:");
            BlockedNQueensBFS.PrintSolution(solutions[i]);
        }
    }
}