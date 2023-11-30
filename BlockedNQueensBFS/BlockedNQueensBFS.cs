namespace BlockedNQueensBFS;

public static class BlockedNQueensBFS
{
    private static bool IsValid(int[] board, int row, int col, List<Tuple<int, int>> blockedPositions)
    {
        // Check if placing a queen at board[row, col] is valid
        for (int i = 0; i < row; i++)
        {
            if (board[i] == col || board[i] - i == col - row || board[i] + i == col + row)
            {
                return false;
            }
        }

        // Check if the position is blocked
        if (blockedPositions.Any(pos => pos.Item1 == row && pos.Item2 == col))
        {
            return false;
        }

        return true;
    }

    public static void PrintSolution(int[] board)
    {
        int n = board.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(board[i] == j ? "Q " : ". ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static List<int[]> SolveBlockedNQueens(int n, List<Tuple<int, int>> blockedPositions)
    {
        List<int[]> solutions = new List<int[]>();
        Queue<Tuple<int[], int>> queue = new Queue<Tuple<int[], int>>();

        // Each state in the queue is represented as a tuple (board, row)
        // where 'board' is the current partial solution and 'row' is the next row to explore
        queue.Enqueue(new Tuple<int[], int>(new int[n], 0));

        while (queue.Count > 0)
        {
            Tuple<int[], int> state = queue.Dequeue();
            int[] board = state.Item1;
            int row = state.Item2;

            if (row == n)
            {
                // If we have placed queens in all rows, we found a solution
                solutions.Add((int[])board.Clone());
                continue;
            }

            for (int col = 0; col < n; col++)
            {
                if (IsValid(board, row, col, blockedPositions))
                {
                    // If placing a queen at (row, col) is valid, update the board and enqueue the next state
                    board[row] = col;
                    queue.Enqueue(new Tuple<int[], int>((int[])board.Clone(), row + 1));
                    // Explore other possibilities by resetting the board[row] to 0
                    board[row] = 0;
                }
            }
        }

        return solutions;
    }
}
