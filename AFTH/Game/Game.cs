using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Game
{
    class Game
    {
        public static int[] size = { 8, 8 };
        public static char[,] board = new char[size[0], size[1]];

        static void Main()
        {
            Console.Clear();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please choose:");
                Console.WriteLine("1. Play");
                Console.WriteLine("2. Highscores");
                Console.WriteLine("3. Options");
                Console.WriteLine("4. Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: Play(size[0], size[1]); break;
                    case 2: Highscores(); break;
                    case 3: size = Options(size); break;
                    case 4: ExitConfirm(); break;
                    default: Console.WriteLine("Invalid input!"); break;
                }
            }
        }

        static void Play(int width, int height)
        {
            while (true)
            {
                Console.Clear();
                char[,] board = new char[width, height];
                board = Board(board);

                for (int i = 0; i < board.GetLength(1); i++)
                {
                    for (int j = 0; j < board.GetLength(0); j++)
                    {
                        Console.Write(board[j, i]);
                    }
                    Console.WriteLine();
                }
                Thread.Sleep(1000);
            }
        }

        static void Highscores()
        {
            Console.Clear();
            Console.WriteLine("Highscores22:");
            Console.ReadLine();
        }

        static char[,] Board(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                board[i, 0] = '.';
            }
            for (int i = 0; i < board.GetLength(1); i++)
            {
                board[0, i] = '.';
                board[board.GetLength(0) - 1, i] = '.';
            }
            for (int i = 0; i < board.GetLength(0); i++)
            {
                board[i, board.GetLength(1) - 1] = '.';
            }
            return board;
        }

        static int[] Options(int[] size)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Current width: {0}", size[0]);
                Console.WriteLine("Current height: {0}", size[1]);
                Console.WriteLine();
                Console.WriteLine("1. Change width");
                Console.WriteLine("2. Change height");
                Console.WriteLine("3. Save");
                Console.WriteLine();
                Console.Write("Choice: ");
                int choice = int.Parse(Console.ReadLine());
                Console.Write("Change to: ");
                if (choice == 1)
                {
                    size[0] = int.Parse(Console.ReadLine());
                }
                else if (choice == 2)
                {
                    size[1] = int.Parse(Console.ReadLine());
                }
                else if (choice == 3)
                {
                    return size;
                }
            }
        }

        static void ExitConfirm()
        {
            Console.Clear();
            Console.WriteLine("Are you sure?");
            Console.WriteLine("1. Yes!");
            Console.WriteLine("2. No");
            Console.Write("Enter choice: ");
            int exitChoice = int.Parse(Console.ReadLine());
            if (exitChoice == 1)
            {
                Environment.Exit(0);
            }
            else if (exitChoice == 2)
            {
                return;
            }
        }
    }
}
