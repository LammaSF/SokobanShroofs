using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Sokoban
{
    internal class BasicMenu
    {
        public static int counter = 0;

        private static void Main(string[] args)
        {

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
            Console.WriteLine();
            Console.WriteLine();
            string name = new string(' ', Console.WindowWidth / 2 - 42 / 2) + new string('s', 5) + " " + new string('o', 5) +
                          " k" + new string(' ', 3) + "k " +
                          new string('o', 5) + " " + new string('b', 4) + "   " + new string('a', 3) + "  n   n" + "\n"
                          + new string(' ', Console.WindowWidth / 2 - 42 / 2) + new string('s', 1) + "     o" +
                          new string(' ', 3) + "o k  k  o   o b   b a   a nn  n\n"
                          + new string(' ', Console.WindowWidth / 2 - 42 / 2) + new string('s', 5) + " o" +
                          new string(' ', 3) + "o kkk   o   o " + new string('b', 4) + "  " + new string('a', 5) +
                          " n n n\n"
                          + new string(' ', Console.WindowWidth / 2 - 42 / 2) + new string(' ', 4) + new string('s', 1) +
                          " o" + new string(' ', 3) + "o k  k  o   o b   b a   a n  nn\n"
                          + new string(' ', Console.WindowWidth / 2 - 42 / 2) + new string('s', 5) + " " +
                          new string('o', 5) + " k   k " + new string('o', 5) + " " + new string('b', 4) +
                          "  a   a n   n";
            Console.WriteLine("{0}", name);
            
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
            while (true) //read keys and call menu with the selector on the new position
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
                case 0:
                    break;
                case 1:
                    PrintHighScore();
                    break;
                case 2:
                    GetNameAndScore();
                    break;
                case 3:
                    QuitPrompt();
                    break;
            }

        }

        private static void QuitPrompt()
        {
           
            while (true)
            // if someone finds a way to make the "are you sure" prompt appear in the middle as in the example above without breaking the code pls do
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
                    MainMenuPrint(ref counter);

                }
            }





        }

        public static string TitleHighScore =

            new string(' ', Console.WindowWidth / 2 - 42 / 2) + "h" + new string(' ', 3) + "h" + " " + new string('i', 5) + " " + new string('g', 5) + " " +
            "h" + new string(' ', 3) + "h" + " " + "\n" +
            new string(' ', Console.WindowWidth / 2 - 42 / 2) + "h" + new string(' ', 3) + "h" + " " + new string(' ', 2) + "i" + new string(' ', 2) + " " + "g" + new string(' ', 3) + "g" + " " + "h" + new string(' ', 3) + "h" + "\n" +
            new string(' ', Console.WindowWidth / 2 - 42 / 2) + new string('h', 5) + " " + new string(' ', 2) + "i" + new string(' ', 2) + " " + "g" + new string(' ', 4) + " " + new string('h', 5) + "\n" +
            new string(' ', Console.WindowWidth / 2 - 42 / 2) + "h" + new string(' ', 3) + "h" + " " + new string(' ', 2) + "i" + new string(' ', 2) + " " + "g" + " " + new string('g', 3) + " " + "h" + new string(' ', 3) + "h" + "\n" +
            new string(' ', Console.WindowWidth / 2 - 42 / 2) + "h" + new string(' ', 3) + "h" + " " + new string('i', 5) + " " + new string('g', 5) + " " + "h" + new string(' ', 3) + "h" + "\n" +
            Environment.NewLine +
            new string(' ', Console.WindowWidth / 2 + 2) + new string('s', 5) + " " + new string('c', 5) + " " + new string('o', 5) + " " +
             new string('r', 5) + " " + new string('e', 5) + "\n" +
            new string(' ', Console.WindowWidth / 2 + 2) + "s" + new string(' ', 4) + " " + "c" + new string(' ', 3) + "c" + " " + "o" + new string(' ', 3) + "o" + " " + "r" + new string(' ', 3) + "r" + " " + "e" + new string(' ', 4) + "\n" +
            new string(' ', Console.WindowWidth / 2 + 2) + new string('s', 5) + " " + "c" + new string(' ', 4) + " " + "o" + new string(' ', 3) + "o" + " " + "r" + new string('r', 4) + " " + new string('e', 5) + "\n" +
            new string(' ', Console.WindowWidth / 2 + 2) + new string(' ', 4) + "s" + " " + "c" + new string(' ', 3) + "c" + " " + "o" + new string(' ', 3) + "o" + " " + "r" + " " + "r" + new string(' ', 3) + "e" + new string(' ', 4) + "\n" +
            new string(' ', Console.WindowWidth / 2 + 2) + new string('s', 5) + " " + new string('c', 5) + " " + new string('o', 5) + " " + "r" + new string(' ', 3) + "r" + " " + new string('e', 5);

        public static void PrintHighScore()
        {

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(TitleHighScore);

            while (true)
            {

                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine();
                }
                string nameScore = "\tName\tScore";
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (nameScore.Length / 2)) + "}", nameScore);

                using (var reader = new StreamReader("../../Score.txt"))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (line.Length / 2)) + "}", line);

                        line = reader.ReadLine();
                    }
                }

                string prompt = "Pres Enter for main manu. ";
                Console.WriteLine();
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (prompt.Length / 2)) + "}", prompt);
                ConsoleKeyInfo result = Console.ReadKey(true);

                if (result.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    MainMenuPrint(ref counter);

                }
            }
        }

        public static void GetNameAndScore()
        {
            int score = int.Parse(Console.ReadLine());
            counter = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }
            string textScore = "Your score are:";
            string textName = "Please enter your name: ";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (textScore.Length / 2)) + "} {1}", textScore, score);
            Console.WriteLine();
            Console.Write("{0," + ((Console.WindowWidth / 2) + (textScore.Length / 2)) + "}", textName);
            string name = Console.ReadLine();

           // Dictionary<string,Dictionary<string, string>> newScore=new Dictionary<string, Dictionary<string, string>>();
            string[] newScore = new string[10];
          
            using (var reader = new StreamReader("../../Score.txt"))
            {
                string lineScore = "";
                string currLine = "";

                for(int i = 0; i < 10; i++)
                {
                    currLine = File.ReadLines("../../Score.txt").Skip(i).Take(1).First();
                    string[] words = currLine.Split('\t');
                    if (score < int.Parse(words[2]))
                    {
                        for (int j = 9; j > i; j--)
                        {
                            currLine =  File.ReadLines("../../Score.txt").Skip(j - 1).Take(1).First();
                            words = currLine.Split('\t');
                            string[] tempWords = File.ReadLines("../../Score.txt").Skip(j).Take(1).First().Split('\t');
                            words[0] = tempWords[0];
                            lineScore = words[0] + "\t" + words[1] + "\t" + words[2];
                            newScore[j] = lineScore;
                        }
                        words[2] = score.ToString().PadLeft(3,'0');
                        words[1] = name;
                        lineScore = words[0] + "\t" + words[1] + "\t" + words[2];
                        newScore[i] = lineScore;
                        break;
                    }
                    else
                    {
                        newScore[i] = currLine;
                    }
                }
            }
            using (var writer=new StreamWriter("../../Score.txt"))
            {
                foreach (var line in newScore)
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}
