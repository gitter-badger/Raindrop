using System;
using System.Collections.Generic;
using System.Text;

namespace Raindrop.Apps.User
{
    public class PrgmSnake
    {
        public static string prgmVersion = "0.1";
        /* SNAKE VARS */
        public int[] matrix;
        public List<int[]> commands;
        public List<int[]> snake;
        public List<int> food;
        public int randomNumber;
        Random rnd = new Random();

        /* SNAKE FUNCS */
        public string GetSnakeScore()
        {
            if (snake.Count < 10)
            {
                return snake.Count + "   ";
            }
            else if (snake.Count < 100)
            {
                return snake.Count + "  ";
            }
            else if (snake.Count < 1000)
            {
                return snake.Count + " ";
            }
            else
            {
                return snake.Count + "";
            }
        }

        public void UpdatePosition()
        {
            List<int[]> tmp = new List<int[]>();

            foreach (int[] point in snake)
            {
                switch (point[1])
                {
                    case 1:
                        point[0] = point[0] - 1;
                        break;
                    case 2:
                        point[0] = point[0] + 80;
                        break;
                    case 3:
                        point[0] = point[0] + 1;
                        break;
                    case 4:
                        point[0] = point[0] - 80;
                        break;
                    default:
                        break;
                }
                tmp.Add(point);
            }
            snake = tmp;
        }

        public void ChangeArray()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = 0;
            }

            foreach (int[] point in snake)
            {
                matrix[point[0]] = 3;
            }

            foreach (int point in food)
            {
                matrix[point] = 2;
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                if (i <= 79 && i >= 0)
                {
                    matrix[i] = 1;
                }
                else if (i <= 1760 && i >= 1679)
                {
                    matrix[i] = 1;
                }
                else if (i % 80 == 0)
                {
                    matrix[i] = 1;
                }

                else if (i % 80 == 79)
                {
                    matrix[i] = 1;
                }
            }
        }

        public Boolean Gameover()
        {
            int head = snake[0][0];
            for (int i = 1; i < snake.Count; i++)
            {
                if (head == snake[i][0])
                {
                    return true;
                }
            }
            if (head % 80 == 79 || head % 80 == 0 || head <= 1760 && head >= 1679 || head <= 79 && head >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PrintGame()
        {
            Console.CursorVisible = false;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (Gameover() && i == 585)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("╔═════════════════════════════╗");
                    Console.ForegroundColor = ConsoleColor.White;
                    i = i + 30;
                }
                else if (Gameover() && i == 665)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("║");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    //Console.Write("#############################");
                    Console.Write("█████████████████████████████");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("║");
                    Console.ForegroundColor = ConsoleColor.White;
                    i = i + 30;
                }
                else if (Gameover() && i == 745)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("║");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    //Console.Write("###                       ###");
                    Console.Write("███                       ███");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("║");
                    Console.ForegroundColor = ConsoleColor.White;
                    i = i + 30;
                }
                else if (Gameover() && i == 825)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("║");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    //Console.Write("###       ");
                    Console.Write("███       ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("GAMEOVER");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    //Console.Write("        ###");
                    Console.Write("        ███");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("║");
                    Console.ForegroundColor = ConsoleColor.White;
                    i = i + 30;
                }
                else if (Gameover() && i == 905)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("║");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    //Console.Write("###      ");
                    Console.Write("███      ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Score: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(GetSnakeScore());
                    Console.ForegroundColor = ConsoleColor.Gray;
                    //Console.Write("      ###");
                    Console.Write("      ███");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("║");
                    Console.ForegroundColor = ConsoleColor.White;
                    i = i + 30;
                }
                else if (Gameover() && i == 985)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("║");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    //Console.Write("###                       ###");
                    Console.Write("███                       ███");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("║");
                    Console.ForegroundColor = ConsoleColor.White;
                    i = i + 30;
                }
                else if (Gameover() && i == 1065)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("║");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    //Console.Write("#############################");
                    Console.Write("█████████████████████████████");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("║");
                    Console.ForegroundColor = ConsoleColor.White;
                    i = i + 30;
                }
                else if (Gameover() && i == 1145)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("╚═════════════════════════════╝");
                    Console.ForegroundColor = ConsoleColor.White;
                    i = i + 30;
                }
                else if (matrix[i] == 1 && !Gameover())
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.Write("#");
                    Console.Write("█");
                }
                else if (matrix[i] == 1 && Gameover())
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    //Console.Write("#");
                    Console.Write("█");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (matrix[i] == 2 && !Gameover())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (matrix[i] == 2 && Gameover())
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (matrix[i] == 3 && !Gameover())
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("█");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (matrix[i] == 3 && Gameover())
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("█");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write(" ");
                }
            }

            if (!Gameover())
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("║  Current score: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(GetSnakeScore());
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("      Exit game: ESC button      Restart game: R button  ║");
                //Console.Write("################################################################################");
                //Console.Write("████████████████████████████████████████████████████████████████████████████████");
                Console.Write("╚══════════════════════════════════════════════════════════════════════════════╝");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("║  Current score: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(GetSnakeScore());
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("      Exit game: ESC button      Restart game: R button  ║");
                //Console.Write("################################################################################");
                //Console.Write("████████████████████████████████████████████████████████████████████████████████");
                Console.Write("╚══════════════════════════════════════════════════════════════════════════════╝");
            }
            Console.CursorVisible = true;
        }

        public void Delay(int time)
        {
            for (int i = 0; i < time; i++) ;
        }

        public int Xy2p(int x, int y)
        {
            return y * 80 + x;
        }

        public int RandomFood()
        {
            int rand = rnd.Next(81, 1700);
            if (rand != randomNumber)
            {
                randomNumber = rand;
                return rand;
            }
            else
            {
                return 1400;
            }
        }

        public void ConfigSnake()
        {
            matrix = new int[1760];
            commands = new List<int[]>();
            snake = new List<int[]>();
            food = new List<int>();
            randomNumber = 0;
            snake.Add(new int[2] { Xy2p(10, 10), 3 });
            ChangeArray();
            food.Add(RandomFood());
        }

        public void UpdateDirections()
        {
            List<int[]> tmp = new List<int[]>();
            foreach (int[] com in commands)
            {
                if (com[1] < snake.Count)
                {
                    snake[com[1]][1] = com[0];
                    com[1] = com[1] + 1;
                    tmp.Add(com);
                }
            }
            commands = tmp;
        }

        public void CheckIfTouchFood()
        {
            List<int> foodtmp = new List<int>();
            foreach (int pos in food)
            {
                if (snake[0][0] == pos)
                {
                    foodtmp.Add(RandomFood());
                    int tmp1 = snake[snake.Count - 1][0];
                    int tmp2 = snake[snake.Count - 1][1];
                    if (tmp2 == 1)
                    {
                        tmp1 = tmp1 + 1;
                    }
                    else if (tmp2 == 2)
                    {
                        tmp1 = tmp1 - 80;
                    }
                    else if (tmp2 == 3)
                    {
                        tmp1 = tmp1 - 1;
                    }
                    else if (tmp2 == 4)
                    {
                        tmp1 = tmp1 + 80;
                    }
                    snake.Add(new int[] { tmp1, tmp2 });
                }
                else
                {
                    foodtmp.Add(pos);
                }
            }
            food = foodtmp;
        }

        public void PrintLogo()
        {
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            /*Console.WriteLine("  #####");
            Console.WriteLine(" #     # #    #   ##   #    # ######");
            Console.WriteLine(" #       ##   #  #  #  #   #  #");
            Console.WriteLine("  #####  # #  # #    # ####   #####");
            Console.WriteLine("       # #  # # ###### #  #   #");
            Console.WriteLine(" #     # #   ## #    # #   #  #");
            Console.Write("  #####  #    # #    # #    # ######");*/
            Console.WriteLine("  █████");
            Console.WriteLine(" █     █ █    █   ██   █    █ ██████");
            Console.WriteLine(" █       ██   █  █  █  █   █  █");
            Console.WriteLine("  █████  █ █  █ █    █ ████   █████");
            Console.WriteLine("       █ █  █ █ ██████ █  █   █");
            Console.WriteLine(" █     █ █   ██ █    █ █   █  █");
            Console.Write    ("  █████  █    █ █    █ █    █ ██████");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" v" + prgmVersion);
            Console.Write("                                  by");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" Krasno");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
        }

        public void Run()
        {
            Console.CursorVisible = true;
            Console.Clear();
            PrintLogo();
            Console.Write("Welcome to Snake, write snake to start the game: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            var y = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            switch (y)
            {
                case "snake":
                    ConfigSnake();
                    ConsoleKey x;
                    while (true)
                    {
                        Console.CursorVisible = false;
                        while (Gameover())
                        {
                            PrintGame();
                            Boolean endGame = false;
                            switch (Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.R:
                                    ConfigSnake();
                                    break;
                                case ConsoleKey.Escape:
                                    endGame = true;
                                    break;
                            }

                            if (endGame)
                            {
                                break;
                            }
                        }
                        while (!Console.KeyAvailable && !Gameover())
                        {
                            UpdateDirections();

                            UpdatePosition();

                            CheckIfTouchFood();

                            Console.Clear();
                            ChangeArray();
                            PrintGame();
                            Delay(10000000);
                        }

                        x = Console.ReadKey(true).Key;

                        if (x == ConsoleKey.LeftArrow)
                        {
                            if (snake[0][1] != 3)
                            {
                                commands.Add(new int[2] { 1, 0 });
                            }
                        }
                        else if (x == ConsoleKey.UpArrow)
                        {
                            if (snake[0][1] != 2)
                            {
                                commands.Add(new int[2] { 4, 0 });
                            }
                        }
                        else if (x == ConsoleKey.RightArrow)
                        {
                            if (snake[0][1] != 1)
                            {
                                commands.Add(new int[2] { 3, 0 });
                            }
                        }
                        else if (x == ConsoleKey.DownArrow)
                        {
                            if (snake[0][1] != 4)
                            {
                                commands.Add(new int[2] { 2, 0 });
                            }
                        }
                        else if (x == ConsoleKey.Escape)
                        {
                            Console.Clear();
                            break;
                        }
                        else if (x == ConsoleKey.R)
                        {
                            ConfigSnake();
                        }
                        Console.CursorVisible = true;
                    }
                    break;
                default:
                    Console.WriteLine("Wrong option.");
                    Console.CursorVisible = true;
                    Run();
                    break;
            }
        }
    }
}
