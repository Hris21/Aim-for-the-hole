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
        static int[] size = { 8, 8 };
        static char[,] board = new char[size[0], size[1]];
        static int x = size[0] / 2;
        static int y = size[1] - 2;
        static int updateRate = 0;
        static int[] playerPosition = { x, y };

        static void Main()
        {
            Console.Clear();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please choose23:");
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
            int[] line = { 1, 1 };
            int[] player = { x, y };

            while (true)
            {
                line = FallingLines(line);
                char[,] board = new char[width, height];
                board = Board(board, line, playerPosition);
                PlayerPosition(playerPosition);
                StringBuilder renderer = new StringBuilder("");
                for (int i = 0; i < board.GetLength(1); i++)
                {
                    for (int j = 0; j < board.GetLength(0); j++)
                    {
                        renderer.Append(board[j, i]);
                    }
                    if (i == 0) renderer.Append("Highscore");
                    renderer.Append("\n");
                }
                Console.Clear();
                Console.WriteLine(renderer);
                Thread.Sleep(20);
            }
        }

        static void PlayerPosition(int[] player)
        {
            int[] newPlayerPosition = player;
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.LeftArrow)
                {
                    player[0]--;
                    if (player[0] < 1) player[0]++;

                }
                if (userInput.Key == ConsoleKey.RightArrow)
                {
                    player[0]++;
                    if (player[0] > size[0] - 2) player[0]--;
                }
                if (userInput.Key == ConsoleKey.UpArrow)
                {
                    player[1]--;
                    if (player[1] < 1) player[1]++;
                }
                if (userInput.Key == ConsoleKey.DownArrow)
                {
                    player[1]++;
                    if (player[1] > size[1] - 2) player[1]--;
                }
            }
        }

        static void Highscores()
        {
            Console.Clear();
            Console.WriteLine("Highscores:");
            Console.ReadLine();
        }

        static char[,] Board(char[,] board, int[] line, int[] playerPosition)
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
            for (int i = 1; i < board.GetLength(0) - 1; i++)
            {
                board[i, line[1]] = 'X';
            }
            board[line[0], line[1]] = ' ';
            board[playerPosition[0], playerPosition[1]] = '@';
            return board;
        }

        static Random rnd = new Random();

        static int[] FallingLines(int[] line)
        {
            if (updateRate == 10)
            {

                line[1]++;
                if (line[1] > size[1] - 2)
                {
                    line[1] = 1;
                    line[0] = rnd.Next(1, size[1] - 2);
                }
                updateRate = 0;
            }
            else updateRate++;
            return line;
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
            Console.WriteLine("2. No!");
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
