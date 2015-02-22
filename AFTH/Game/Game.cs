﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Game
{
    class Game
    {
        static int[] size = { 8, 8 }; // size[0] - width; size[1] - height
        static char[,] board = new char[size[0], size[1]]; //main game board
        static int x = size[0] / 2; // player x
        static int y = size[1] - 2; // player y
        static int updateRate = 0; // The updating rate of the lines position
        static int[] playerPosition = { x, y }; // Player coordinates

        static void Main() //Main menu of the game
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
                    case 1:
                        Play(size[0], size[1]);
                        break;
                    case 2:
                        Highscores();
                        break;
                    case 3:
                        size = Options(size);
                        break;
                    case 4:
                        ExitConfirm();
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }
        }

        static void Play(int width, int height) //Starts the game
        {
            int[] line = { 1, 1 }; // line {place of the hole, row of the line}
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
                    if (i == 0)
                        renderer.Append("Highscore");
                    renderer.Append("\n");
                }

                Console.Clear();
                Console.WriteLine(renderer);
                Thread.Sleep(20);
            }
        }

        static void PlayerPosition(int[] player) //Check for pressed key and changes player position
        {
            int[] newPlayerPosition = player;
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.LeftArrow)
                {
                    player[0]--;
                    if (player[0] < 1)
                        player[0]++;

                }
                if (userInput.Key == ConsoleKey.RightArrow)
                {
                    player[0]++;
                    if (player[0] > size[0] - 2)
                        player[0]--;
                }
                if (userInput.Key == ConsoleKey.UpArrow)
                {
                    player[1]--;
                    if (player[1] < 1)
                        player[1]++;
                }
                if (userInput.Key == ConsoleKey.DownArrow)
                {
                    player[1]++;
                    if (player[1] > size[1] - 2)
                        player[1]--;
                }
            }
        }

        static void Highscores() // Menu of the highscores
        {
            Console.Clear();
            Console.WriteLine("Highscores:");
            Console.ReadLine();
        }

        static char[,] Board(char[,] board, int[] line, int[] playerPosition) //Fills the game board
        {
            try
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
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Your given position is outside the bounds of the game field.");
                return null;
            }

            return board;
        }

        static Random rnd = new Random();

        static int[] FallingLines(int[] line) //Creates line position
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
            else
                updateRate++;
            return line;
        }

        static int[] Options(int[] size) //Game configuration options
        {
            //using to check if not correct data was entered
            bool isOutOfRange = false;

            while (true)
            {
                Console.Clear();
                if (isOutOfRange)
                {
                    Console.WriteLine("The provided width/height was not correct");
                }

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
                    int newWidth = int.Parse(Console.ReadLine());
                    // checking if the new width is in the range of the console
                    if (newWidth <= Console.WindowWidth && newWidth >= 0)
                    {
                        isOutOfRange = false;
                        size[0] = newWidth;
                    }
                    else
                    {
                        isOutOfRange = true;
                    }

                }
                else if (choice == 2)
                {
                    int newHeight = int.Parse(Console.ReadLine());
                    // checking if the new height is in the range of the console
                    if (newHeight <= Console.WindowHeight && newHeight >= 0)
                    {
                        isOutOfRange = false;
                        size[1] = newHeight;
                    }
                    else
                    {
                        isOutOfRange = true;
                    }
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
