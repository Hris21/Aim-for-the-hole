using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;


namespace Game
{
    class Game
    {
        const string highScoresFile = @"..\..\HighScores.txt";
        static int[] size = { 35, 20 }; // size[0] - width; size[1] - height
        static char[,] board = new char[size[0], size[1]]; //main game board
        static int x = size[0] / 2; // player x
        static int y = size[1] - 2; // player y
        static int updateRate = 10; // The rate of update of lines and bonuses
        static int updateLineCount = 0; //update counter for the lines
        static int updateBonusesCount = 0; //update counter of the bonus points
        static int[] playerPosition = { x, y }; // Player coordinates
        static int currentScore = 0; // The current score of the player
        static int lineHeight = 0; // Line position according to the player
        static bool gameNotOver = true; // Checks if the game is over
        static int[] bonusPosition = { 1, size[1] / 2 }; // Position of the bonus
        static int level = 0; // Default level of the game
        static char bonusSymbol = '+';

        static void Main() //Main menu of the game
        {
            Console.BufferHeight = Console.WindowHeight; //remove the buffer (scrollbar)
            Console.BufferWidth = Console.WindowWidth; 

            Console.Title = "Aim For The Hole";
            Console.Clear();

            while (true)
            {
                ResetGame();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                for (int i = 0; i < 5; i++)                //If this for was missing
                {
                    Console.WriteLine();
                }

                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Play"));        //Using basic formating, to be sure that everything is..
                Console.WriteLine();                                                                    //..in the center.
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Highscores"));
                Console.WriteLine();
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Options"));
                Console.WriteLine();
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Exit"));
                int startCol = 43;
                int positionUpDown = 5;  //I just had to guess the right cordinates for the pointer.I've written them on one row so you know that these are the coordinates.
                char arrowForMenu = (char)17; //The arrow for the menu.
                while (true)
                {
                    Console.CursorVisible = false; //This here is making sure that the arrow wont be flashin
                    Console.SetCursorPosition(startCol, positionUpDown);
                    Console.WriteLine(arrowForMenu);
                    Console.SetCursorPosition(startCol, positionUpDown);
                    ConsoleKeyInfo MenuArrowPosition = Console.ReadKey();
                    if (positionUpDown > 5 || positionUpDown <= 12)
                    {

                        if (MenuArrowPosition.Key == ConsoleKey.UpArrow)              //If up arrow is pressed the pointer goes down.
                        {
                            Console.SetCursorPosition(startCol, positionUpDown);
                            Console.WriteLine(" ");

                            positionUpDown -= 2;
                        }
                        else if (MenuArrowPosition.Key == ConsoleKey.DownArrow)       //If down arrow is pressed the pointer goes down.
                        {
                            Console.SetCursorPosition(startCol, positionUpDown);
                            Console.WriteLine(" ");
                            positionUpDown += 2;
                        }
                    }
                    if (positionUpDown < 5)  //Making sure that the arrow will not get too high.
                    {
                        positionUpDown = 11;
                    }
                    if (positionUpDown > 12) //Making sure that the arrow will not get too low.
                    {
                        positionUpDown = 5;
                    }
                    if (MenuArrowPosition.Key == ConsoleKey.Enter)   //This break here is making sure that we break to switch .
                    {
                        break;
                    }
                }

                try
                {

                    switch (positionUpDown - 4)
                    {
                        case 1:
                            Play(size[0], size[1]);
                            break;
                        case 3:
                            Highscores();
                            break;
                        case 5:
                            size = Options(size);
                            break;
                        case 7:
                            ExitConfirm();
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
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
                bonusPosition = BonusPosition(bonusPosition);
                char[,] board = new char[width, height];
                board = Board(board, line, playerPosition, bonusPosition);
                PlayerPosition(playerPosition);
                Level();
                StringBuilder renderer = new StringBuilder("");
                for (int i = 0; i < board.GetLength(1); i++)
                {
                    for (int j = 0; j < board.GetLength(0); j++)
                    {
                        renderer.Append(board[j, i]);

                    }


                    if (i == size[1] / 2 - 1)
                    {
                        if (gameNotOver)
                        {
                            renderer.Append("  Score: "); // Draws the score
                            renderer.Append(currentScore);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            renderer.Append("  GAME OVER!!!"); // Game over message
                        }

                    }
                    if (i == size[1] / 2 + 1)
                    {
                        if (gameNotOver)
                        {
                            renderer.Append("  Level: "); // Draws the level
                            renderer.Append(level);
                        }
                    }
                    renderer.Append("\n");
                }
               


                Console.Clear();
                Console.WriteLine(renderer);
                if (gameNotOver == false)
                {
                    WriteScores();
                    while (true)
                    {
                        ConsoleKeyInfo userInput = Console.ReadKey();
                        if (userInput.Key == ConsoleKey.Enter)
                        {
                            return;
                        }
                    }
                }
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
            if (player[1] == lineHeight) // Check the position of the player according to the line 
            {
                currentScore++;
            }
            if (player[0] == bonusPosition[0] && player[1] == bonusPosition[1]) // Update score when hitted bonus position
            {
                bonusSymbol = ' ';
                currentScore += 10;
                //bonusPosition[1] = 1; // Removes the bonus from the board and initilizes a new bonus ot the top of the field
                //bonusPosition[0] = rnd.Next(1, size[0] - 2);
                //if (bonusPosition[1] == lineHeight)
                //{
                //    bonusPosition[1]--;
                //}

            }
        }

        static void Highscores() // Menu of the highscores
        {
            Console.Clear();
            Console.WriteLine("Highscores:");
            //WriteScores();
            ReadScores();
            Console.ReadLine();
        }

        static char[,] Board(char[,] board, int[] line, int[] playerPosition, int[] bonusPosition) //Fills the game board
        {
            char characterFace = (char)1;
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
                board[playerPosition[0], playerPosition[1]] = characterFace;
                board[bonusPosition[0], bonusPosition[1]] = bonusSymbol;
                lineHeight = line[1]; // Check the position of the player according to the line
                if (playerPosition[1] == line[1] && playerPosition[0] != line[0]) //The death
                {
                    gameNotOver = false;
                 }
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
            if (updateLineCount == updateRate)
            {

                line[1]++;
                if (line[1] > size[1] - 2)
                {
                    line[1] = 1;
                    line[0] = rnd.Next(1, size[0] - 2);
                }
                updateLineCount = 0;
            }
            else
                updateLineCount++;
            return line;
        }

        static int[] BonusPosition(int[] bonusPosition) // Returns the position of bonus points
        {
            if (updateBonusesCount == updateRate)
            {
                bonusPosition[1]++;
                if (bonusPosition[1] > size[1] - 2)
                {
                    bonusSymbol = '+';
                    bonusPosition[1] = 1;
                    bonusPosition[0] = rnd.Next(1, size[0] - 2);
                }
                updateBonusesCount = 0;
            }
            else
                updateBonusesCount++;
            return bonusPosition;
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
                try
                {
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
                        x = size[0] / 2;
                        y = size[1] - 2;
                        playerPosition[0] = x;
                        playerPosition[1] = y;
                        bonusPosition[1] = size[1] / 2;
                        return size;
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
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

        public static void WriteScores()
        {
            const int maxRecordedScores = 10;
            //currentScore = 300;
            List<long> highScores = GetHighScores();
            if (highScores.Count < maxRecordedScores || currentScore > highScores.Last())
            {
                highScores.Add(currentScore);
                highScores.Sort();
                highScores.Reverse();

                if (highScores.Count > maxRecordedScores)
                {
                    highScores.RemoveAt(highScores.Count - 1);
                }

                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(File.Open(highScoresFile, FileMode.OpenOrCreate)))
                {
                    foreach (var item in highScores)
                    {
                        file.WriteLine(item);
                    }
                }
            }

        }

        public static void ReadScores()
        {
            List<long> highScores = GetHighScores();
            int count = 1;
            foreach (var item in highScores)
            {
                Console.WriteLine(string.Format("{0}. {1}", count, item));
                count++;
            }
        }

        public static List<long> GetHighScores()
        {
            string line;
            List<long> highScores = new List<long>();
            using (System.IO.StreamReader file =
                new System.IO.StreamReader(File.Open(highScoresFile, FileMode.OpenOrCreate)))
            {
                while ((line = file.ReadLine()) != null)
                {

                    highScores.Add(long.Parse(line));
                }
            }
            return highScores;
        }

        static void Level()
        {
            level = currentScore / 1000;
            if (level > 5)
            {
                level = 5;
            }
            updateRate = 10 - level;
        }
        static void ResetGame()
        {
            board = new char[size[0], size[1]];
            x = size[0] / 2;
            y = size[1] - 2;
            updateRate = 10;
            updateLineCount = 0;
            updateBonusesCount = 0;
            playerPosition[0] = x;
            playerPosition[1] = y;
            currentScore = 0;
            lineHeight = 0;
            gameNotOver = true;
            bonusPosition[1] = size[1] / 2;
            bonusPosition[0] = 1;
            level = 0;
            bonusSymbol = '+';
        }
    }
}
