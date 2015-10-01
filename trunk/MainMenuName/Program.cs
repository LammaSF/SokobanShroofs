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
            Console.WriteLine("{0} {1} H{2}H", new string('H', 5), new string('H', 5), new string (' ', 3) );

            Console.WriteLine("{0}     H{1}H H  H", new string('H', 1), new string(' ', 3));
            Console.WriteLine("{0} H{1}H H H", new string('H', 5), new string(' ', 3));
            Console.WriteLine("{0}{1} H{2}H H  H", new string(' ', 4), new string('H', 1), new string(' ', 3));
            Console.WriteLine("{0} {1} H   H", new string('H', 5), new string('H', 5));
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
                Console.WriteLine("Are you sure you want to quit? (Y/N)");
                ConsoleKeyInfo result = Console.ReadKey(true);
                if ((result.KeyChar == 'Y') || (result.KeyChar == 'y'))
                {
                    Process.GetCurrentProcess().Kill();
                }
                else if ((result.KeyChar == 'N') || (result.KeyChar == 'n'))
                {
                    MainMenuPrint(ref counter);
                }
            }




        }

    }
}
