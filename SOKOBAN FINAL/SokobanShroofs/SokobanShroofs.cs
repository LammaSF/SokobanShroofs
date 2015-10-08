using System;
using System.IO;

using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace SokobanShroofs    // HighScore>CheckScore think of a way to make this check
{
    class BasicMenu
    {
        private static void resetGame()
        {
            SokobanShroofs.score = 0;
            SokobanShroofs.currentLevel = 1;
            SokobanShroofs.levelBeaten = true;
        }
        public static int counter = 0;
        static void Main()
        {
            Console.CursorVisible = false;
            MenuPrint(ref counter);
        }
        public static int ReadKey(ConsoleKeyInfo key, ref int counter)
        {
            if (key.Key == ConsoleKey.DownArrow) return ++counter;
            if (key.Key == ConsoleKey.UpArrow) return --counter;
            if (key.Key == ConsoleKey.Enter) ExecuteEnter(ref counter);
            if (key.Key == ConsoleKey.Escape)
                if (SokobanShroofs.levelBeaten) QuitPrompt();
                else
                {
                    resetGame();
                    MenuPrint(ref counter);
                }

            return counter;
        }
        private static void MMenuPrint(ref int counter)
        {
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
        }
        private static void PMenuPrint(ref int counter)
        {
            string nGame = "Resume game";
            string resetGame = "Restart level";
            string hScores = "High scores";
            string options = "Options";
            string quit = "Main menu";
            switch (counter) //we have 4 options so we have to restrain the selector to them
            {

                case 0:
                case 5:
                    //0 and 4 because we want the selector to loop and go to the first option after hitting downArrow from last
                    counter = 0;
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (nGame.Length / 2)) + "}", "-> " + nGame);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (nGame.Length / 2)) + "}", resetGame);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (hScores.Length / 2)) + "}", hScores);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (options.Length / 2)) + "}", options);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (quit.Length / 2)) + "}", quit);
                    break;
                case 1:
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (nGame.Length / 2)) + "}", nGame);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (nGame.Length / 2)) + "}", "-> " + resetGame);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (hScores.Length / 2)) + "}", hScores);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (options.Length / 2)) + "}", options);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (quit.Length / 2)) + "}", quit);
                    break;
                case 2:
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (nGame.Length / 2)) + "}", nGame);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (nGame.Length / 2)) + "}", resetGame);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (hScores.Length / 2)) + "}", "-> " + hScores);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (options.Length / 2)) + "}", options);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (quit.Length / 2)) + "}", quit);
                    break;
                case 3:
                    //3 and -1 because we want the selector to loop and go to the last option after hitting upArrow from first
                    counter = 3;
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (nGame.Length / 2)) + "}", nGame);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (nGame.Length / 2)) + "}", resetGame);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (hScores.Length / 2)) + "}", hScores);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (options.Length / 2)) + "}", "-> " + options);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (quit.Length / 2)) + "}", quit);
                    break;
                case 4:
                case -1:
                    counter = 4;
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (nGame.Length / 2)) + "}", nGame);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (nGame.Length / 2)) + "}", resetGame);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (hScores.Length / 2)) + "}", hScores);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (options.Length / 2)) + "}", options);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (quit.Length / 2)) + "}", "-> " + quit);
                    break;
                default:
                    counter = 0;
                    break;
            }
        }
        public static void MenuPrint(ref int counter)
        {
            Console.Clear();

            Console.CursorVisible = false;
            Console.WriteLine();
            Console.WriteLine();
            using (var reader = new StreamReader("../../using/Name.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (line.Length / 2)) + "}", line);

                    line = reader.ReadLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            if (SokobanShroofs.levelBeaten) MMenuPrint(ref counter);    //if current level is not beaten(game has not started yet) get Main menu
            else PMenuPrint(ref counter);                               //else get Pause menu

            Console.CursorVisible = false;

            while (true)                            //read keys and call menu with the selector on the new position
            {
                var key = Console.ReadKey();

                Console.Clear();
                ReadKey(key, ref counter);
                MenuPrint(ref counter);
            }
        }
        private static void ExecuteEnter(ref int counter)
        {

            Console.CursorVisible = false;
            if (SokobanShroofs.levelBeaten)
            {
                switch (counter)
                {
                    case 0:
                        SokobanShroofs.StartGame_GetNextLevel();
                        break;
                    case 1:
                        HighScore.PrintHighScore();
                        break;
                    case 2:
                        Options.PrintOptions(ref Options.counterMoves);
                        break;
                    case 3:
                        QuitPrompt();
                        break;
                }
            }
            else
            {
                switch (counter)
                {
                    case 0:
                        SokobanShroofs.StartGame_GetNextLevel();
                        break;
                    case 1:
                        SokobanShroofs.ResetPrompt();
                        break;
                    case 2:
                        HighScore.PrintHighScore();
                        break;
                    case 3:
                        Options.PrintOptions(ref Options.counterMoves);
                        break;
                    case 4:
                        if(SokobanShroofs.score!=0)
                        {
                            HighScore.WriteNewHS();
                        }
                        BasicMenu.resetGame();
                        BasicMenu.MenuPrint(ref BasicMenu.counter);
                        break;
                }
            }
            

        }
        private static void QuitPrompt()
        {

            while (true)
            {
                Console.Clear();

                Console.CursorVisible = false;

                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine();
                }
                string prompt = "Are you sure you want to quit? (Y/N)";
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (prompt.Length / 2)) + "}", prompt);
                ConsoleKeyInfo result = Console.ReadKey(true);

                switch (result.Key)
                {
                    case ConsoleKey.Y:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.N:
                    case ConsoleKey.Escape:
                        Console.Clear();
                        MenuPrint(ref counter);
                        break;
                }
                break;
            }
        }
    }    
    class SokobanShroofs
    {
        public static int score = 0;
        public static int currentLevel = 1;
        public static bool levelBeaten = true;
        public static Coordinate Hero { get; set; }
        public static Coordinate[] Targets;
        private static char[,] level;
        public static void StartGame_GetNextLevel()
        {

            try
            {
                GetLevel(ref currentLevel);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Level{0} does not exist.", currentLevel);
                Console.Write("Select level to be loaded:");
                currentLevel = int.Parse(Console.ReadLine());
                levelBeaten = true;
                GetLevel(ref currentLevel);
            }
            PrintLevel();
            ReadKey();
        }

        private static void ReadKey()
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
                    case ConsoleKey.R:
                        ResetPrompt();
                        break;
                    case ConsoleKey.Escape:
                        BasicMenu.MenuPrint(ref BasicMenu.counter);
                        break;

                }
            }
        }
        public static void ResetPrompt()
        {
            while (true)
            {
                Console.Clear();

                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine();
                }
                string prompt = "Are you sure you want to reset the level? (Y/N)";
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (prompt.Length / 2)) + "}", prompt);
                ConsoleKeyInfo result = Console.ReadKey(true);
                switch (result.Key)
                { 
                    case ConsoleKey.Y:
                    LevelReset();
                    break;
                case ConsoleKey.N: case ConsoleKey.Escape:
                    PrintLevel();
                    break;
                }
                break;
            }
        }
        private static void LevelReset()
        {

            BasicMenu.counter = 0;
            levelBeaten = true;
            GetLevel(ref SokobanShroofs.currentLevel);
            HighScore.WriteNewHS();
            BasicMenu.MenuPrint(ref BasicMenu.counter);
        }
        private static void TryMove(int x, int y)
        {
            if (level[Hero.X + x, Hero.Y + y] == default(char) || level[Hero.X + x, Hero.Y + y] == 'O')      // if wanted space is \0 or O move there
            {
                level[Hero.X + x, Hero.Y + y] = level[Hero.X, Hero.Y];
                level[Hero.X, Hero.Y] = default(char);
                Hero.X += x;
                Hero.Y += y;
                score++;
            }
            else if (level[Hero.X + x, Hero.Y + y] == '*')                                                  // if its * check
            {
                if (!BallInWay(new Coordinate { X = Hero.X + x, Y = Hero.Y + y }, x, y))                    // if space next to it is *; if not move
                {
                    //for (int i = 0; i < Balls.Length; i++)
                    //{
                    //    if ((Balls[i].X == Hero.X + x) && (Balls[i].Y == Hero.Y + y))                       //find ball in Balls and change its coordinates
                    //    {
                    //        Balls[i].X = Hero.X + x+x;
                    //        Balls[i].Y = Hero.Y + y+y;
                    //    }
                    //}
                    char temp = level[Hero.X + x, Hero.Y + y];
                    level[Hero.X + x, Hero.Y + y] = level[Hero.X, Hero.Y];
                    level[Hero.X + x + x, Hero.Y + y + y] = temp;
                    level[Hero.X, Hero.Y] = default(char);
                    Hero.X += x;
                    Hero.Y += y;
                    score++;
                }
                //those are the only two options when its allowed for us to move => no need to check anything else 

            }
            PrintLevel();
        }
        private static void EndGameCheck()
        {
            //foreach (var tar in Targets)      //cant find a way do this check :C
            //{
            //    bool ballIsOnTarget = false;
            //    foreach (var ball in Balls)
            //    {
            //        if ((ball.X == tar.X) && (ball.Y == tar.Y))
            //        {
            //            ballIsOnTarget = true;
            //            break;
            //        }
            //    }
            //    if(ballIsOnTarget)
            //    {
            //        if (((level[Balls[i].X - 1, Balls[i].Y] == '#') || (level[Balls[i].X + 1, Balls[i].Y] == '#') &&        //if cell ontop or below ball is # AND cell on either side is #:
            //            ((level[Balls[i].X, Balls[i].Y - 1] == '#') || (level[Balls[i].X, Balls[i].Y + 1] == '#')))
            //        || ((level[Balls[i].X, Balls[i].Y + 1] == '#') && ((level[Balls[i].X - 1, Balls[i].Y] == '#') || (level[Balls[i].X + 1, Balls[i].Y] == '#'))))   // or if cell next to it is # and cell ontop or above it is
            //        {
            //            Console.WriteLine("game lost;");
            //            break; // game lost;
            //        }
            //    }
            //}     // if ball is on target : game could be won => no need to end it;
            
            int counter = 0;
            foreach (var tar in Targets)
            {
                if (level[tar.X, tar.Y] == '*') counter++;
            }
            if (counter==Targets.Length)
            {

                Console.WriteLine();
                Console.WriteLine("Level beaten!");
                currentLevel++;
                levelBeaten = true;
                Thread.Sleep(1500);

                Console.WriteLine("Level beaten!");
                currentLevel++;
                levelBeaten = true;

                EndScreen.Win();
                SokobanShroofs.StartGame_GetNextLevel();
            }
        }
        private static void GetLevel(ref int currentLevel)
        {
            if (!levelBeaten) return;
            levelBeaten = false;
            StreamReader reader = new StreamReader(string.Format("../../using/Level{0}.txt",currentLevel));
            using (reader)
            {
                int lineNumber = 0;
                int ballCounter = 0;
                int targetCounter = 0;

                string[] line = reader.ReadLine().Split();     // get dimensions - the first line of a level text file is always dimensions
                level = new char[int.Parse(line[0]), int.Parse(line[1])];       //define the level playing field by those dimensions
                //Balls = new Coordinate[(int)Char.GetNumericValue(line[2])];     // balls = 3rd digit of first line;
                Targets = new Coordinate[int.Parse(line[2])];   // holes = 3rd digit of first line;
                string getLine = reader.ReadLine();                         //read the first line of the playing field
                while (getLine != null)
                {
                    line = getLine.Split();
                    for (int i = 0; i < line.Length; i++)           // for every character on a single line
                    {
                        if (line[i] == "#")                                 // if wall add to level playing field
                        {
                            level[lineNumber,i] = line[i][0];    
                            continue;
                        }
                        if (line[i] == "*")                                 //if ball add to Balls
                        {
                            //Balls[ballCounter++] = new Coordinate()
                            //{
                            //    X = lineNumber,
                            //    Y = i
                            //};
                            ballCounter++;
                            level[lineNumber, i] = line[i][0];
                            continue;
                        }
                        if (line[i] == "X")                                 // X for hero starting position
                        {
                            Hero = new Coordinate()
                            {
                                X = lineNumber,
                                Y = i
                            };
                            level[lineNumber, i] = '@';
                            continue;
                        }
                        if (line[i] == "O")                                 // if is target then add its coordinates to Targets
                        {
                            Targets[targetCounter++] = new Coordinate()
                            {
                                X = lineNumber,
                                Y = i
                            };
                            level[lineNumber, i] = line[i][0];
                        }
                    }
                    getLine = reader.ReadLine();
                    lineNumber++;

                }
                if (Targets.Length != ballCounter)
                {
                    GetLevel(ref currentLevel); // if levels ballCounter and target counter differ then get next level => this one can't be completed
                }
            }
        }
        private static bool BallInWay(Coordinate c, int x, int y)
        {
            if (level[c.X + x, c.Y + y] == '*' || level[c.X + x, c.Y + y] == '#') return true;
            return false;
        }
        private static void PrintLevel()
        {
            foreach (var tar in Targets)    // check every target X and Y to see if those coordinates are empty on the playing field
            {
                if (level[tar.X, tar.Y] == default(char))       // if so => make level[x,y] = 'O' - empty target;
                    level[tar.X, tar.Y] = 'O';
            }
            Console.Clear();
            for (int row = 0; row < level.GetLength(0); row++)
            {
                string line = "";                               // so as to not flicker that much when you move
                for (int col = 0; col < level.GetLength(1); col++)
                {
                    line += level[row, col];
                }
                Console.WriteLine(line);
            }
            EndGameCheck();
        }
     }
    class HighScore
    {
        public static List<player> highScores = new List<player>();
        public struct player
        {
            public string name;
            public int score;

            public player(string name, int score)
            {
                this.name = name;
                this.score = score;
            }
        }
        public static string TitleHighScore =       //this is ridiculous
            new string(' ', Console.WindowWidth / 2 - 42 / 2) + "h" + new string(' ', 3) + "h" + " " + new string('i', 5) + " " + new string('g', 5) + " " +
            "h" + new string(' ', 3) + "h" + " " + "\n" +
            new string(' ', Console.WindowWidth / 2 - 42 / 2) + "h" + new string(' ', 3) + "h" + " " + new string(' ', 2) + "i" + new string(' ', 2) + " " + "g" + new string(' ', 3) + "g" + " " + "h" + new string(' ', 3) + "h" + "\n" +
            new string(' ', Console.WindowWidth / 2 - 42 / 2) + new string('h', 5) + " " + new string(' ', 2) + "i" + new string(' ', 2) + " " + "g" + new string(' ', 4) + " " + new string('h', 5) + "\n" +
            new string(' ', Console.WindowWidth / 2 - 42 / 2) + "h" + new string(' ', 3) + "h" + " " + new string(' ', 2) + "i" + new string(' ', 2) + " " + "g" + " " + new string('g', 3) + " " + "h" + new string(' ', 3) + "h" + "\n" +
            new string(' ', Console.WindowWidth / 2 - 42 / 2) + "h" + new string(' ', 3) + "h" + " " + new string('i', 5) + " " + new string('g', 5) + " " + "h" + new string(' ', 3) + "h" + "\n" +
            new string(' ', Console.WindowWidth / 2 + 2) + new string('s', 5) + " " + new string('c', 5) + " " + new string('o', 5) + " " +
            new string('r', 5) + " " + new string('e', 5) + "\n" +
            new string(' ', Console.WindowWidth / 2 + 2) + "s" + new string(' ', 4) + " " + "c" + new string(' ', 3) + "c" + " " + "o" + new string(' ', 3) + "o" + " " + "r" + new string(' ', 3) + "r" + " " + "e" + new string(' ', 4) + "\n" +
            new string(' ', Console.WindowWidth / 2 + 2) + new string('s', 5) + " " + "c" + new string(' ', 4) + " " + "o" + new string(' ', 3) + "o" + " " + "r" + new string('r', 4) + " " + new string('e', 5) + "\n" +
            new string(' ', Console.WindowWidth / 2 + 2) + new string(' ', 4) + "s" + " " + "c" + new string(' ', 3) + "c" + " " + "o" + new string(' ', 3) + "o" + " " + "r" + " " + "r" + new string(' ', 3) + "e" + new string(' ', 4) + "\n" +
            new string(' ', Console.WindowWidth / 2 + 2) + new string('s', 5) + " " + new string('c', 5) + " " + new string('o', 5) + " " + "r" + new string(' ', 3) + "r" + " " + new string('e', 5);

        public static void WriteNewHS()
        {
            
            using (var reader = new StreamReader("../../using/Score.txt"))      //get highscores from file to list<struct>
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] score = line.Split();
                    highScores.Add(new player(score[0], int.Parse(score[1])));
                    line = reader.ReadLine();
                }
            }
            highScores.Add(new player(GetName(), SokobanShroofs.score));         //add current player's score
            using (var writer = new StreamWriter("../../using/Score.txt"))
            {
                for (int i = 0; i < highScores.Count- 1; i++)
                {
                    int j = i + 1;

                    while (j > 0)
                    {
                        if (highScores[j - 1].score > highScores[j].score)
                        {
                            player swapPlayer = highScores[j - 1];
                            highScores[j - 1] = highScores[j];
                            highScores[j]= swapPlayer;

                        }
                        j--;
                    }
                }
                foreach (var element in highScores)
                {
                    writer.WriteLine(element.name + " " + element.score);
                }
            }


        }
        public static string GetName()
        {
            Console.Write("Pick a name between 4 and 10 characters:");
            string name = Console.ReadLine();
            while(name.Length<4||name.Length>10)
            {
                Console.Write("Pick name between 4 and 10 characters:");
                name = Console.ReadLine();
            }
            return name;
        }
        public static void PrintHighScore()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                string TitleHighScore = String.Empty;
                using (var reader = new StreamReader(@"../../using/HighScore.txt"))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        TitleHighScore += line + "\n";
                        line = reader.ReadLine();
                    }
                }
                Console.WriteLine(TitleHighScore);
                Console.WriteLine();
                string nameScore = "\tName\tScore";
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (nameScore.Length / 2)) + "}", nameScore);

                using (var reader = new StreamReader("../../using/Score.txt"))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {

                        
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (line.Length / 2)) + "}", line);


                        line = reader.ReadLine();
                    }
                }
                string prompt = "Pres ESC for main manu.";
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (prompt.Length / 2)) + "}", prompt);
                ConsoleKeyInfo result = Console.ReadKey(true);

                if (result.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    BasicMenu.MenuPrint(ref BasicMenu.counter);

                }
            }
        }
    }
    class EndScreen
    {
        public static int counter = 0;
        

        
        public static string loose = new string(' ', Console.WindowWidth / 2 - 30 / 2) + "LL     " + " " + new string('0', 3) + " " + "  " + new string('s', 5) + "  " + new string('E', 5) + "\n"
                                    + new string(' ', Console.WindowWidth / 2 - 30 / 2) + "LL     " + "O" + new string(' ', 3) + "O  " + "SS" + new string(' ', 3) + "  " + "EE" + "   " + "\n"
                                    + new string(' ', Console.WindowWidth / 2 - 30 / 2) + "LL     " + "O" + new string(' ', 3) + "O  " + new string('S', 5) + "  " + new string('E', 5) + "\n"
                                    + new string(' ', Console.WindowWidth / 2 - 30 / 2) + "LL     " + "O" + new string(' ', 3) + "O  " + new string(' ', 3) + "SS" + "  " + "EE" + "   " + "\n"
                                    + new string(' ', Console.WindowWidth / 2 - 30 / 2) + new string('L', 5) + "  " + " " + new string('0', 3) + " " + "  " + new string('S', 5) + "  " + new string('E', 5) + "\n";

        public static void Win()
        {
            Console.Clear();
            string win = String.Empty;
            using (var reader = new StreamReader(@"../../using/Win.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    win += "\n" + new string(' ', Console.WindowWidth / 2 - 30 / 2) + line;
                    line = reader.ReadLine();
                }
            }
            int n = 0;
            while (n <= 1)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.CursorVisible = false;
                WriteBlinkingText(win, 1000, true);

                Console.Clear();
                Console.CursorVisible = false;
                WriteBlinkingText(win, 1000, false);
                Console.CursorVisible = false;
                Console.Clear();
                n++;

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(win);

        }
        public static void WriteBlinkingText(string text, int delay, bool visible)
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
    }

    class Options
    {
        public static int counterMoves = 0;

        public static int OptionsReadKey(ConsoleKeyInfo key, ref int counterMoves)
        {
            if (key.Key == ConsoleKey.DownArrow) return ++counterMoves;
            if (key.Key == ConsoleKey.UpArrow) return --counterMoves;
            if (key.Key == ConsoleKey.Enter) OptionsEnter(ref counterMoves);
            if (key.Key == ConsoleKey.Escape) BasicMenu.MenuPrint(ref BasicMenu.counter);

            return counterMoves;
        }

        private static void OptionsEnter(ref int counterMoves)
        {
            switch (counterMoves)
            {
                case 0:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 1:
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 2:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 3:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case 4:
                    BasicMenu.MenuPrint(ref BasicMenu.counter);
                    break;
            }
        }

        public static void PrintOptions(ref int counterMoves)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine();
            Console.WriteLine();
            string options = String.Empty;
            using (var reader = new StreamReader(@"../../using/Options.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    options += new string(' ', Console.WindowWidth / 2 - 58 / 2) + line + "\n";
                    line = reader.ReadLine();
                }
            }
            Console.WriteLine("{0}", options);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();
            string redColor = "Red Background";
            string cyanColor = "Cyan Background";
            string blackColor = "Black Background";
            string whiteColor = "White Background";
            string mMenu = "Main menu";
            switch (counterMoves) //we have 5 options so we have to restrain the selector to them
            {

                case 0:
                case 5:
                    //0 and 4 because we want the selector to loop and go to the first option after hitting downArrow from last
                    counterMoves = 0;
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (redColor.Length / 2)) + "}", "-> " + redColor);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (cyanColor.Length / 2)) + "}", cyanColor);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (blackColor.Length / 2)) + "}", blackColor);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (whiteColor.Length / 2)) + "}", whiteColor);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (mMenu.Length / 2)) + "}", mMenu);
                    break;
                case 1:
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (redColor.Length / 2)) + "}", redColor);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (cyanColor.Length / 2)) + "}", "-> " + cyanColor);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (blackColor.Length / 2)) + "}", blackColor);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (whiteColor.Length / 2)) + "}", whiteColor);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (mMenu.Length / 2)) + "}", mMenu);
                    break;
                case 2:
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (redColor.Length / 2)) + "}", redColor);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (cyanColor.Length / 2)) + "}", cyanColor);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (blackColor.Length / 2)) + "}", "-> " + blackColor);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (whiteColor.Length / 2)) + "}", whiteColor);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (mMenu.Length / 2)) + "}", mMenu);
                    break;
                case 3:
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (redColor.Length / 2)) + "}", redColor);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (cyanColor.Length / 2)) + "}", cyanColor);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (blackColor.Length / 2)) + "}", blackColor);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (whiteColor.Length / 2)) + "}", "-> " + whiteColor);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (mMenu.Length / 2)) + "}", mMenu);
                    break;
                case 4:
                case -1:

                    //4 and -1 because we want the selector to loop and go to the last option after hitting upArrow from first
                    counterMoves = 4;
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (redColor.Length / 2)) + "}", redColor);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (cyanColor.Length / 2)) + "}", cyanColor);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (blackColor.Length / 2)) + "}", blackColor);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (whiteColor.Length / 2)) + "}",  whiteColor);
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (mMenu.Length / 2)) + "}", "-> " + mMenu);
                    break;

                default:
                    counterMoves = 0;
                    break;
            }
            while (true)                            //read keys and call menu with the selector on the new position
            {
                var key = Console.ReadKey();

                Console.Clear();
                OptionsReadKey(key, ref counterMoves);
                PrintOptions(ref counterMoves);

            }

        }

    }
    class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}

