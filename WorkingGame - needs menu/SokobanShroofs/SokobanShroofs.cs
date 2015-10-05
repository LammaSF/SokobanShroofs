using System;
using System.Collections.Generic;
using System.IO;

namespace SokobanShroofs
{
    class SokobanShroofs
    {
        public static int currentLevel = 1;
        public static Coordinate Hero { get; set; }
        public static Coordinate[] Targets;
        public static char[,] level;

        static void Main(string[] args)
        {
            GetLevel(ref currentLevel);
            PrintLevel();
            ReadKey();
        }

        public static void ReadKey()
        {
            ConsoleKeyInfo keyInfo;
                while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        TryMove(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        TryMove(0, 1);
                        break;
                    case ConsoleKey.DownArrow:
                        TryMove(1,0);
                        break;
                    case ConsoleKey.LeftArrow:
                        TryMove(0, -1);
                        break;
                    case ConsoleKey.Escape:
                        //GetMenu(); get menu here
                        break;
                    case ConsoleKey.C:
                        EndGameCheck();
                        break;

                }
            }
        }
        public static void TryMove(int x, int y)
        {
            if (level[Hero.X + x, Hero.Y + y] == default(char) || level[Hero.X + x, Hero.Y + y] == 'O')      // if wanted space is \0 or O move there
            {
                level[Hero.X + x, Hero.Y + y] = level[Hero.X, Hero.Y];
                level[Hero.X, Hero.Y] = default(char);
                Hero.X += x;
                Hero.Y += y;
            }
            else if (level[Hero.X + x, Hero.Y + y] == '*')                                                  // if its * check
            {
                if (!BallInWay(new Coordinate { X = Hero.X + x, Y = Hero.Y + y }, x, y))                    // if space next to it is *; if not move
                {
                    char temp = level[Hero.X + x, Hero.Y + y];
                    level[Hero.X + x, Hero.Y + y] = level[Hero.X, Hero.Y];
                    level[Hero.X + x + x, Hero.Y + y + y] = temp;
                    level[Hero.X, Hero.Y] = default(char);
                    Hero.X += x;
                    Hero.Y += y;
                }
                           //those are the only two options when its allowed for us to move => no need to check anything else 
                
            }
            PrintLevel();
        }
        public static void EndGameCheck()
        {
            int counter = 0;
            foreach (var tar in Targets)
            {
                if (level[tar.X, tar.Y] == '*') counter++;
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
                Targets = new Coordinate[(int)Char.GetNumericValue(line[2])];   // holes = 3rd digit of first line;
                string getLine = reader.ReadLine();                         //read the first line of the playing field
                while (getLine != null)
                {
                    line = line = string.Join("", getLine.Split()).ToCharArray();
                    for (int i = 0; i <= level.GetLength(0); i++)           // for every character on a single line
                    {
                        if (line[i] == '#')                                 // if wall add to level playing field
                        {
                            level[lineNumber, i] = line[i];
                            continue;
                        }
                        if (line[i] == '*')                                 // no need to save balls coordinates;
                        {
                            ballCounter++;
                            level[lineNumber, i] = line[i];
                            continue;
                        }
                        if (line[i] == 'X')                                 // X for hero starting position
                        {
                            Hero = new Coordinate()
                            {
                                X = lineNumber,
                                Y = i
                            };
                            level[lineNumber, i] = '@';
                            continue;
                        }
                        if (line[i] == 'O')                                 // if is target then add its coordinates to Targets
                        {
                            Targets[targetCounter++] = new Coordinate()
                            {
                                X = lineNumber,
                                Y = i
                            };
                            level[lineNumber, i] = line[i];
                        }
                    }
                    getLine = reader.ReadLine();
                    lineNumber++;

                }
                currentLevel++;
                if (Targets.Length != ballCounter)
                {
                    GetLevel(ref currentLevel); // if levels ballCounter and target counter differ then get next level => this one can't be completed
                }
            }
        }
        public static bool BallInWay(Coordinate c, int x, int y)
        {
            if (level[c.X + x, c.Y + y] == '*' || level[c.X + x, c.Y + y] == '#') return true;
            return false;
        }
        public static void PrintLevel()
        {
            foreach (var tar in Targets)    // check every target X and Y to see if those coordinates are empty on the playing field
            {
                if (level[tar.X, tar.Y] == default(char))       // if so => make level[x,y] = 'O' - empty target;
                    level[tar.X, tar.Y] = 'O';
            }
            Console.Clear();
            for (int row = 0; row < level.GetLength(0); row++)
            {
                for (int col = 0; col < level.GetLength(1); col++)
                {
                    Console.Write(level[row, col]);
                }
                Console.WriteLine();
            }
        }
     }

    class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    
}

