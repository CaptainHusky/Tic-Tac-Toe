using System;

class Program
{
    static char[] board = new char[10];
    static char current;

    static void Main()
    {
        bool play = true;
        while (play)
        {
            ResetBoard();
            PlayOneGame();

            Console.Write("\nPlay again? (y/n): ");
            string ans = Console.ReadLine()?.Trim().ToLower() ?? "n";
            play = ans.StartsWith("y");
        }
        Console.WriteLine("Thanks for playing! 👋");
    }

    static void PlayOneGame()
    {
        current = 'X';
        for (int turn = 0; turn < 9; turn++)
        {
            DrawBoard();
            Console.Write($"\n{current}'s move (1-9): ");

            if (!int.TryParse(Console.ReadLine(), out int cell) ||
                cell < 1 || cell > 9 || !char.IsDigit(board[cell]))
            {
                Console.WriteLine("Invalid move. Press Enter...");
                Console.ReadLine();
                turn--;
                continue;
            }

            board[cell] = current;

            if (HasWinner())
            {
                DrawBoard();
                Console.WriteLine($"\n🏆 {current} wins!");
                Console.ReadLine();
                return;
            }

            current = (current == 'X') ? 'O' : 'X';
        }

        DrawBoard();
        Console.WriteLine("\nIt's a draw! 😶");
        Console.ReadLine();
    }

    static void ResetBoard()
    {
        board[0] = ' '; // unused
        for (int i = 1; i <= 9; i++) board[i] = (char)('0' + i);
    }

    static bool HasWinner()
    {
        int[,] lines = new int[,]
        {
            {1,2,3},{4,5,6},{7,8,9},
            {1,4,7},{2,5,8},{3,6,9},
            {1,5,9},{3,5,7}
        };
        for (int i = 0; i < lines.GetLength(0); i++)
        {
            int a = lines[i, 0], b = lines[i, 1], c = lines[i, 2];
            if (board[a] == board[b] && board[b] == board[c] && !char.IsDigit(board[a]))
                return true;
        }
        return false;
    }

    static void DrawBoard()
    {
        Console.Clear();
        Console.WriteLine("Tic Tac Toe\n");
        Console.WriteLine($" {board[1]} | {board[2]} | {board[3]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[4]} | {board[5]} | {board[6]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[7]} | {board[8]} | {board[9]} ");
    }
}
