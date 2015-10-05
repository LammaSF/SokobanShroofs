using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanShroofs
{
    class SokobanShroofs
    {

        public static Coordinate Hero { get; set; }
        public static Coordinate[] Balls = new Coordinate[5];
        public static Coordinate[] Targets = new Coordinate[5];
        public static char[,] level = new char[15, 18];
        public static int counter = 0;

        public static string name = new string(' ', Console.WindowWidth / 2 - 42 / 2)+new string('_',41)+"\n"+new string(' ', Console.WindowWidth / 2 - 42 / 2) + new string('S', 5) + "  " + new string('O', 3) + "  K" + new string(' ', 3) + "K  " +
               new string('O', 3) + "  " + new string('B', 4) + "   " + new string('A', 3) + "  N   N" + "\n"
                + new string(' ', Console.WindowWidth / 2 - 42 / 2) + new string('S', 2) + "    O" + new string(' ', 3) + "O K  K  O   O B   B A   A NN  N\n"
                + new string(' ', Console.WindowWidth / 2 - 42 / 2) + new string('S', 5) + " O" + new string(' ', 3) + "O KKK   O   O " + new string('B', 4) + "  " + new string('A', 5) + " N N N\n"
                + new string(' ', Console.WindowWidth / 2 - 42 / 2) + new string(' ', 3) + new string('S', 2) + " O" + new string(' ', 3) + "O K  K  O   O B   B A   A N  NN\n"
                + new string(' ', Console.WindowWidth / 2 - 42 / 2) + new string('S', 5) + "  " + new string('O', 3) + "  K   K  " + new string('O', 3) + "  " + new string('B', 4) + "  A   A N   N\n"
                + new string(' ', Console.WindowWidth / 2 - 42 / 2) + new string('_', 41) + "\n";

        public static string win = new string(' ', Console.WindowWidth / 2 - 30 / 2) + "WW" + new string(' ', 6) + "WW" + "    " + "II" + "    " + "NNN" + new string(' ', 4) + "NN" + "\n"
                + new string(' ', Console.WindowWidth / 2 - 30 / 2) + "WW" + new string(' ', 6) + "WW" + "    " + "II" + "    " + "NNN" + new string(' ', 4) + "NN" + "\n"
                + new string(' ', Console.WindowWidth / 2 - 30 / 2) + "WW" + new string(' ', 6) + "WW" + "    " + "II" + "    " + "NN" + new string(' ', 1) + "NN" + new string(' ', 2) + "NN" + "\n"
                + new string(' ', Console.WindowWidth / 2 - 30 / 2) + " WW" + new string(' ', 1) + "WW" + new string(' ', 1) + "WW " + "    " + "II" + "    " + "NN" + new string(' ', 2) + "NN" + new string(' ', 1) + "NN" + "\n"
                + new string(' ', Console.WindowWidth / 2 - 30 / 2) + "  WW" + new string(' ', 2) + "WW  " + "    " + "II" + "    " + "NN" + new string(' ', 4) + "NNN" + "\n";
        public static string loose = new string(' ', Console.WindowWidth / 2 - 30 / 2) + "LL     " + " " + new string('0', 3) + " " + "   " + new string('0', 3) + " " + "  " + new string('s', 5) + "  " + new string('E', 5) + "\n"
                                    + new string(' ', Console.WindowWidth / 2 - 30 / 2) + "LL     " + "O" + new string(' ', 3) + "O  " + "O" + new string(' ', 3) + "O  " + "SS" + new string(' ', 3) + "  " + "EE" + "   " + "\n"
                                    + new string(' ', Console.WindowWidth / 2 - 30 / 2) + "LL     " + "O" + new string(' ', 3) + "O  " + "O" + new string(' ', 3) + "O  " + new string('S', 5) + "  " + new string('E', 5) + "\n"
                                    + new string(' ', Console.WindowWidth / 2 - 30 / 2) + "LL     " + "O" + new string(' ', 3) + "O  " + "O" + new string(' ', 3) + "O  " + new string(' ', 3) + "SS" + "  " + "EE" + "   " + "\n"
                                    + new string(' ', Console.WindowWidth / 2 - 30 / 2) + new string('L', 5) + "  " + " " + new string('0', 3) + " " + "   " + new string('0', 3) + " " + "  " + new string('s', 5) + "  " + new string('E', 5) + "\n";

        private static void Main()
        {
            Console.CursorVisible = false;
            MainMenuPrint(ref counter);
        }
        public static int ReadKey(ConsoleKeyInfo key, ref int counter)
        {
            if (key.Key == ConsoleKey.DownArrow) return ++counter;
            if (key.Key == ConsoleKey.UpArrow) return --counter;
            if (key.Key == ConsoleKey.Enter) ExecuteEnter(ref counter);

            return counter;
        }

        public static void MainMenuPrint(ref int counter)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.CursorVisible = false;
           
          

           
               // Console.Clear();
               Console.WriteLine();
               Console.WriteLine();
               Console.WriteLine(name);
               Console.WriteLine();
               Console.WriteLine();

            string nGame = "New game";
            string hScores = "High scores";
            string options = "Options";
            string quit = "Quit";
            
            switch (counter) //we have 4 options so we have to restrain the selector to them
            {

                case 0:
                case 4:
                    //0 and 4 because we want the selector to loop and go to the first option after hitting downArrow from last
                    counter = 0;
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (nGame.Length / 2)) + "}", "-> " + nGame);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (hScores.Length / 2)) + "}", hScores);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (options.Length / 2)) + "}", options);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (quit.Length / 2)) + "}", quit);
                    break;
                case 1:
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (nGame.Length / 2)) + "}", nGame);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (hScores.Length / 2)) + "}", "-> " + hScores);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (options.Length / 2)) + "}", options);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (quit.Length / 2)) + "}", quit);
                    break;
                case 2:
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (nGame.Length / 2)) + "}", nGame);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (hScores.Length / 2)) + "}", hScores);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (options.Length / 2)) + "}", "-> " + options);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (quit.Length / 2)) + "}", quit);
                    break;
                case 3:
                case -1:
                    //3 and -1 because we want the selector to loop and go to the last option after hitting upArrow from first
                    counter = 3;
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (nGame.Length / 2)) + "}", nGame);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (hScores.Length / 2)) + "}", hScores);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (options.Length / 2)) + "}", options);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (quit.Length / 2)) + "}", "-> " + quit);
                    break;
                default:
                    counter = 0;
                    break;
            }
            while (true)                            //read keys and call menu with the selector on the new position
            {
                var key = Console.ReadKey();

                Console.Clear();
                ReadKey(key, ref counter);
                MainMenuPrint(ref counter);
            }
        }

        private static void ExecuteEnter(ref int counter)
        {
            switch (counter)
            {
                case 0: NewGame();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    QuitPrompt();
                    break;
            }

        }
        
        private static void QuitPrompt()
        {

            while (true)        
            {

                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine();
                }
                string prompt = "Are you sure you want to quit? (Y/N)";
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (prompt.Length / 2)) + "}", prompt);
                ConsoleKeyInfo result = Console.ReadKey(true);


                if (result.Key == ConsoleKey.Y)
                {
                    Environment.Exit(0);
                    break;

                }

                else if (result.Key == ConsoleKey.N)
                {
                    Console.Clear();
                    counter = 0;
                    MainMenuPrint(ref counter);

                }
            }

        }
        public static void CheckForTargets()
        {
            int counter = 0;
            for (int row = 0; row< level.GetLength(0); row++)
            {
                for (int col = 0; col < level.GetLength(1); col++)
                {
                    if (level[row, col] == 'O')
                    {
                        Targets[counter++] = new Coordinate()
                        {
                            X = col,
                            Y = row
                        };
                    }
                }
            }
            if(Targets.Length==0)
            {
                //TODO Write method to pick different level; this one has no holes for the balls => no winning condition can be achieved
            }
        }
        public static void EndGameCheck()
        {
            int counter = 0;
            for (int i = 0; i < Balls.Length; i++)
            {
                for (int j = 0; j < Targets.Length; j++)
                {
                    if (Balls[i].X == Targets[j].X && Balls[i].Y == Targets[j].Y)
                    {
                        counter++;
                        //Check if all holes are now = * 
                        break;
                    }
                }
                
            }
            if (counter == Targets.Length)
            {
                Console.Clear();

                Win(win);
                Console.WriteLine();
                Console.WriteLine();
                Console.Clear();
                Console.WriteLine(win);
                counter = 0;
                MainMenuPrint(ref counter);
                //Console.WriteLine("Level beaten!");
            }
            else
            {
                Console.Clear();

                Win(loose);
                Console.WriteLine();
                Console.WriteLine();
                Console.Clear();
                Console.WriteLine(loose);
                MainMenuPrint(ref counter);
            }
        }
        
        static void NewGame()
        {
            
            InitGame();
            DrawLevel();
            //ResizeWindow();
            CheckForTargets();
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                int ballToMove = Balls.Length;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        for (int i = 0; i < Balls.Length; i++)
                        {
                            if (BallInWay(Balls[i], 0, -1))
                            {
                                ballToMove = i;
                                break;
                            }
                        }
                        MoveHero(0, -1, ballToMove);
                        MoveBall(0, -1, ballToMove);
                        break;

                    case ConsoleKey.RightArrow:
                        for (int i = 0; i < Balls.Length; i++)
                        {
                            if (BallInWay(Balls[i], 1, 0))
                            {
                                ballToMove = i;
                                break;
                            }
                        }
                        MoveHero(1, 0, ballToMove);
                        MoveBall(1, 0, ballToMove);
                        break;

                    case ConsoleKey.DownArrow:
                        for (int i = 0; i < Balls.Length; i++)
                        {
                            if (BallInWay(Balls[i], 0, 1))
                            {
                                ballToMove = i;
                                break;
                            }
                        }
                        MoveHero(0, 1, ballToMove);
                        MoveBall(0, 1, ballToMove);
                        break;

                    case ConsoleKey.LeftArrow:
                        for (int i = 0; i < Balls.Length; i++)
                        {
                            if (BallInWay(Balls[i], -1, 0))
                            {
                                ballToMove = i;
                                break;
                            }
                        }
                        MoveHero(-1, 0, ballToMove);
                        MoveBall(-1, 0, ballToMove);
                        break;
                    case ConsoleKey.C:
                        EndGameCheck();
                        break;
                }
            }
        }


        static void MoveHero(int x, int y, int i)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Coordinate newHero = new Coordinate()
            {
                X = Hero.X + x,
                Y = Hero.Y + y
            };
            if (i != Balls.Length)
            {
                if ((Balls[i].X == Hero.X + 1 && Balls[i].Y == Hero.Y) || (Balls[i].X == Hero.X - 1 && Balls[i].Y == Hero.Y) || (Balls[i].X == Hero.X && Balls[i].Y == Hero.Y + 1) || (Balls[i].X == Hero.X && Balls[i].Y == Hero.Y - 1))
                {
                    Coordinate newBall = new Coordinate()
                    {
                        X = Balls[i].X + x,
                        Y = Balls[i].Y + y
                    };
                    if (CanMove(newHero) && CanMoveBall(newBall, i))
                    {
                        RemoveHero();

                        Console.SetCursorPosition(newHero.X, newHero.Y);
                        if (level[newHero.Y, newHero.X] == 'O')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write("@");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write("@");
                        }

                        Hero = newHero;
                    }
                }
                else
                {
                    if (CanMove(newHero))
                    {
                        RemoveHero();

                        Console.SetCursorPosition(newHero.X, newHero.Y);
                        if (level[newHero.Y, newHero.X] == 'O')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write("@");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write("@");
                        }

                        Hero = newHero;
                    }
                }
            }
            else
            {
                if (CanMove(newHero))
                {
                    RemoveHero();

                    Console.SetCursorPosition(newHero.X, newHero.Y);
                    if (level[newHero.Y, newHero.X] == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write("@");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("@");
                    }

                    Hero = newHero;
                }
            }
            Console.ResetColor();
        }
        static void MoveBall(int x, int y, int i)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            if (i != Balls.Length)
            {
                Coordinate newBall = new Coordinate()
                {
                    X = Balls[i].X + x,
                    Y = Balls[i].Y + y
                };
                if (CanMoveBall(newBall, i))
                {
                    RemoveBall(i);

                    Console.SetCursorPosition(newBall.X, newBall.Y);
                    if (level[newBall.Y, newBall.X] == 'O')
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write("*");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("*");
                    }

                    Balls[i] = newBall;
                }
            }
            Console.ResetColor();
        }
        static void RemoveHero()
        {
            if (level[Hero.Y, Hero.X] == 'O')
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(Hero.X, Hero.Y);
                Console.WriteLine("O");
                Console.ResetColor();
            }
            else
            {
                Console.SetCursorPosition(Hero.X, Hero.Y);
                Console.Write(" ");
            }
        }
        static void RemoveBall(int i)
        {
            if (Balls[i].X != Hero.X && Balls[i].Y != Hero.Y)
            {
                Console.SetCursorPosition(Balls[i].X, Balls[i].Y);
                Console.Write(" ");
            }
        }
        static bool CanMove(Coordinate c)
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 18; j++)
                {
                    if (level[i, j] == '#' && c.Y == i && c.X == j)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static bool CanMoveBall(Coordinate c, int i)
        {
            for (int m = 0; m < 15; m++)
            {
                for (int n = 0; n < 18; n++)
                {
                    if (level[m, n] == '#' && c.Y == m && c.X == n)
                    {
                        return false;
                    }
                }
            }

            for (int j = 0; j < Balls.Length; j++)
            {
                if (j == i)
                {
                    continue;
                }
                else if (c.X == Balls[j].X && c.Y == Balls[j].Y)
                {
                    return false;
                }
            }

            return true;
        }
        static bool BallInWay(Coordinate c, int x, int y)
        {
            if (c.X == Hero.X + x && c.Y == Hero.Y + y)
                return true;
            return false;
        }
        static void InitGame()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Hero = new Coordinate()
            {
                X = 1,
                Y = 1
            };
            for (int i = 0; i < Balls.Length; i++)
            {
                Balls[i] = new Coordinate()
                {
                    X = i + 2,
                    Y = i + 2
                };
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(Balls[i].X, Balls[i].Y);
                Console.Write("*");
                Console.ResetColor();
            }
            MoveHero(0, 0, Balls.Length);
        }
        static void DrawLevel()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 18; j++)
                {
                    if (i == 0 || i == 14 || j == 0 || j == 17)
                    {
                        level[i, j] = '#';
                        Console.SetCursorPosition(j, i);
                        Console.Write('#');
                    }
                }
            }
            level[8, 8] = '#';
            Console.SetCursorPosition(8, 8);
            Console.Write('#');
            level[8, 9] = '#';
            Console.SetCursorPosition(9, 8);
            Console.Write('#');
            level[8, 10] = '#';
            Console.SetCursorPosition(10, 8);
            Console.Write('#');

            level[7, 3] = '#';
            Console.SetCursorPosition(3, 7);
            Console.Write('#');
            level[8, 3] = '#';
            Console.SetCursorPosition(3, 8);
            Console.Write('#');
            level[9, 3] = '#';
            Console.SetCursorPosition(3, 9);
            Console.Write('#');

            Console.ResetColor();

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            level[9, 8] = 'O';
            Console.SetCursorPosition(8, 9);
            Console.Write('O');
            level[9, 9] = 'O';
            Console.SetCursorPosition(9, 9);
            Console.Write('O');
            level[9, 10] = 'O';
            Console.SetCursorPosition(10, 9);
            Console.Write('O');
            level[7, 2] = 'O';
            Console.SetCursorPosition(2, 7);
            Console.Write('O');
            level[8, 2] = 'O';
            Console.SetCursorPosition(2, 8);
            Console.Write('O');

            Console.ResetColor();
        }
        static void ResizeWindow()
        {
            Console.SetWindowSize(18, 15);
            Console.SetBufferSize(18, 15);
        }
        private static void WriteBlinkingText(string text, int delay, bool visible)
        {
            if (visible)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("{0," + (Console.WindowWidth / 2 - text.Length / 2) + "}", text);
            }
            else

                for (int i = 0; i < text.Length; i++)
                    Console.Write(" ");

            // Console.CursorLeft -= text.Length;
            System.Threading.Thread.Sleep(delay);

        }
        static void Win(string win)
        {

            int n = 0;
            while (n <= 2)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.CursorVisible = false;
                WriteBlinkingText(win, 1500, true);

                Console.Clear();
                Console.CursorVisible = false;
                WriteBlinkingText(win, 1500, false);
                Console.CursorVisible = false;
                Console.Clear();
                n++;

            }
           // Console.WriteLine();
           // Console.WriteLine();
           // Console.WriteLine(win);

        }
        
     }

    class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    
    
}

