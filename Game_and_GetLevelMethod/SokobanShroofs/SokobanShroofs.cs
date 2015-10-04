using System;
using System.Collections.Generic;
using System.IO;

namespace SokobanShroofs
{
    class SokobanShroofs
    {
        public static int currentLevel = 1;
        public static Coordinate Hero { get; set; }
        public static Coordinate[] Balls = new Coordinate[5];
        public static Coordinate[] Targets = new Coordinate[5];
        public static char[,] level;

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
                        counter++;      //Check if all holes are now = * 
                        break;
                    }
                }
                
            }
            if (counter==Targets.Length)
            {
                Console.WriteLine("Level beaten!");
                currentLevel++;
            }
        }
        public static void GetLevel(ref int currentLevel)
        {

            StreamReader reader = new StreamReader(string.Format("../../Level{0}.txt",currentLevel));
            using (reader)
            {
                int lineNumber = 0;
                int ballCounter = 0;
                int targetCounter = 0;

                char[] line = string.Join("", reader.ReadLine().Split()).ToCharArray();     // get dimensions - the first line of a level text file is always dimensions
                level = new char[(int)Char.GetNumericValue(line[0]), (int)Char.GetNumericValue(line[1])];       //define the level playing field by those dimensions
                string getLine = reader.ReadLine();                         //read the first line of the playing field
                while (getLine != null)
                {
                    line = line = string.Join("", getLine.Split()).ToCharArray();
                    for (int i = 0; i <= level.GetLength(0); i++)          // for every character on a single line
                    {
                        if (line[i] == '#')                               // if wall add to level playing field
                        {
                            level[lineNumber, i] = line[i];
                            continue;
                        }
                        if (line[i] == '*')                                // if is ball then add its coordinates to Balls
                        {
                            Balls[ballCounter++] = new Coordinate()
                            {
                                X = lineNumber,
                                Y = i
                            };
                            continue;
                        }
                        if (line[i] == 'X')                         // X for hero starting position
                        {
                            Hero = new Coordinate()
                            {
                                X = lineNumber,
                                Y = i
                            };
                            continue;
                        }
                        if (line[i] == 'O')                       // if is target then add its coordinates to Targets
                        {
                            Targets[targetCounter++] = new Coordinate()
                            {
                                X = lineNumber,
                                Y = i
                            };
                        }
                    }
                    getLine = reader.ReadLine();
                    lineNumber++;

                }
                currentLevel++;
                if (Targets.Length != Balls.Length)
                {
                    GetLevel(ref currentLevel); // if levels ball and target count differ then get next level => this one can't be completed
                }
            }
            MoveHero(0, 0, Balls.Length);
        }
        static void Main(string[] args)
        {
            GetLevel(ref currentLevel);
            //DrawLevel();
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
            //Hero = new Coordinate()       //redundant because of GetLevel()
            //{
            //    X = 1,
            //    Y = 1
            //};
            //for (int i = 0; i < Balls.Length; i++)
            //{
            //    Balls[i] = new Coordinate()
            //    {
            //        X = i + 2,
            //        Y = i + 2
            //    };
            //    Console.ForegroundColor = ConsoleColor.DarkCyan;
            //    Console.SetCursorPosition(Balls[i].X, Balls[i].Y);
            //    Console.Write("*");
            //    Console.ResetColor();
            //}
            //MoveHero(0, 0, Balls.Length);
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
        
     }

    class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    
}

