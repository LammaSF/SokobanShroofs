using System;
using System.Diagnostics;

namespace Sokoban
{
    class BasicMenu
    {
        public static int counter = 0;
        static void Main(string[] args)
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
            string name = new string(' ', Console.WindowWidth / 2 - 42 / 2) + new string('s', 5) + " " + new string('o', 5) + " k" + new string(' ', 3) + "k " + 
      new string('o', 5) + " " + new string('b', 4) + "   " + new string('a', 3) + "  n   n" + "\n"
                + new string(' ', Console.WindowWidth / 2 - 42 / 2) + new string('s', 1) + "     o" + new string(' ', 3) + "o k  k  o   o b   b a   a nn  n\n"
                + new string(' ', Console.WindowWidth / 2 - 42 / 2)+new string('s', 5)+" o"+new string(' ', 3)+"o kkk   o   o "+new string('b',4)+"  "+new string('a',5)+" n n n\n"
                +new string(' ', Console.WindowWidth / 2 - 42 / 2) + new string(' ', 4) + new string('s', 1) + " o" + new string(' ', 3) + "o k  k  o   o b   b a   a n  nn\n"
                + new string(' ', Console.WindowWidth / 2 - 42 / 2) + new string('s', 5) +" "+ new string('o', 5) +" k   k "+ new string('o', 5) +" "+ new string('b', 4) + "  a   a n   n";
            Console.WriteLine("{0}", name);
            //Console.WriteLine("{0} {1} k{2}k {3} {4}   {5}  n   n \n{6}     o{7}o k  k  o   o b   b a   a nn  n\n{8} o{9}o kkk   o   o {10}  {11} n n n\n{12}{13} o{14}o k  k  o   o b   b a   a n  nn\n{15} {16} k   k {17} {18}  a   a n   n", 
            //                                   new string('s', 5), new string('o', 5), new string(' ', 3), new string('o', 5), new string('b', 4), new string('a', 3),
            //                                   new string('s', 1), new string(' ', 3),
            //                                   new string('s', 5), new string(' ', 3), new string('b',4), new string('a',5),
            //                                   new string(' ', 4), new string('s', 1), new string(' ', 3),
            //                                   new string('s', 5), new string('o', 5), new string('o', 5), new string('b', 4));
            // Console.Clear();
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
                case 0:
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
            //while (true)
            //{
            //    Console.Clear();
            //    for (int i = 0; i < 4; i++)
            //    {
            //        Console.WriteLine();
            //    }
            //    string prompt = "Are you sure you want to quit? (Y/N)";
            //    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (prompt.Length / 2)) + "}", prompt);
            //    ConsoleKeyInfo answer = Console.ReadKey(true);
            //    if (answer.KeyChar == 'n') // if N or ESC then go to main menu
            //    {
            //        Console.WriteLine("main menu");
            //        MainMenuPrint(ref counter);
            //    }
            //    if (answer.KeyChar == 'y') Console.WriteLine("Exit"); //Environment.Exit(0);           //if y close program;
            //}

            while (true)        // if someone finds a way to make the "are you sure" prompt appear in the middle as in the example above without breaking the code pls do
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

    }
}