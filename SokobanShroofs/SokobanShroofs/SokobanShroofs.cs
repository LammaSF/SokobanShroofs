using System;

namespace SokobanShroofs
{
    class SokobanShroofs
    {

        public static Coordinate Hero { get; set; }
        public static Coordinate[] Balls = new Coordinate[5];

        static void Main(string[] args)
        {
            InitGame();
            DrawLevel();
            ResizeWindow();
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
                }
            }
        }

        static void MoveHero(int x, int y, int i)
        {
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
                        Console.Write("@");

                        Hero = newHero;
                    }
                }
                else
                {
                    if (CanMove(newHero))
                    {
                        RemoveHero();

                        Console.SetCursorPosition(newHero.X, newHero.Y);
                        Console.Write("@");

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
                    Console.Write("@");

                    Hero = newHero;
                }
            }
        }
        static void MoveBall(int x, int y, int i)
        {
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
                    Console.Write("*");

                    Balls[i] = newBall;
                }
            }
        }
        static void RemoveHero()
        {
            Console.SetCursorPosition(Hero.X, Hero.Y);
            Console.Write(" ");
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
            if (c.X < 1 || c.X >= 17)
                return false;

            if (c.Y < 1 || c.Y >= 14)
                return false;

            return true;
        }
        static bool CanMoveBall(Coordinate c, int i)
        {
            if (c.X < 1 || c.X >= 17)
                return false;

            if (c.Y < 1 || c.Y >= 14)
                return false;
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
                Console.SetCursorPosition(Balls[i].X, Balls[i].Y);
                Console.Write("*");
            }
            MoveHero(0, 0, Balls.Length);
        }
        static void DrawLevel()
        {
            Console.SetCursorPosition(0, 0);
            char[,] level = new char[15, 18];
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
                    else
                    {
                        Console.SetCursorPosition(j, i + 1);
                    }
                }
            }
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

