using System;

namespace SokobanShroofs
{
    class SokobanShroofs
    {

        public static Coordinate Hero { get; set; }
        public static Coordinate Ball { get; set; }

        static void Main(string[] args)
        {
            InitGame();
            DrawLevel();
            ResizeWindow();
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveHero(0, -1);
                        if (BallInWay(Ball))
                        {
                            MoveBall(0, -1);
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        MoveHero(1, 0);
                        if (BallInWay(Ball))
                        {
                            MoveBall(1, 0);
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        MoveHero(0, 1);
                        if (BallInWay(Ball))
                        {
                            MoveBall(0, 1);
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        MoveHero(-1, 0);
                        if (BallInWay(Ball))
                        {
                            MoveBall(-1, 0);
                        }
                        break;
                }
            }
        }

        static void MoveHero(int x, int y)
        {
            Coordinate newHero = new Coordinate()
            {
                X = Hero.X + x,
                Y = Hero.Y + y
            };

            if ((Ball.X == Hero.X + 1 && Ball.Y == Hero.Y) || (Ball.X == Hero.X - 1 && Ball.Y == Hero.Y) || (Ball.X == Hero.X && Ball.Y == Hero.Y + 1) || (Ball.X == Hero.X && Ball.Y == Hero.Y - 1))
            {
                Coordinate newBall = new Coordinate()
                {
                    X = Ball.X + x,
                    Y = Ball.Y + y
                };
                if (CanMove(newHero) && CanMove(newBall))
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
        static void MoveBall(int x, int y)
        {
            Coordinate newBall = new Coordinate()
            {
                X = Ball.X + x,
                Y = Ball.Y + y
            };
            if (CanMove(newBall))
            {
                RemoveBall();

                Console.SetCursorPosition(newBall.X, newBall.Y);
                Console.Write("*");

                Ball = newBall;
            }
        }
        static void RemoveHero()
        {
            Console.SetCursorPosition(Hero.X, Hero.Y);
            Console.Write(" ");
        }
        static void RemoveBall()
        {
            if (Ball.X != Hero.X && Ball.Y != Hero.Y)
            {
                Console.SetCursorPosition(Ball.X, Ball.Y);
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
        static bool BallInWay(Coordinate c)
        {
            if (c.X == Hero.X && c.Y == Hero.Y)
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
            Ball = new Coordinate()
            {
                X = 3,
                Y = 3
            };
            MoveHero(0, 0);
            MoveBall(0, 0);
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

