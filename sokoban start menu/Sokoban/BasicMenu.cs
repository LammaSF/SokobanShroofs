using System;

namespace Sokoban
{
    class BasicMenu
    {
        public static void MenuPrint(ref int counter)
        {
            switch (counter) //we have 4 options so we have to restrain the selector to them
            {
                case 0:
                case 4:
                    //0 and 4 because we want the selector to loop and go to the first option after hitting downArrow from last
                    counter = 0;
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "=> New game"));
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "High scores"));
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Options"));
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Quit"));
                    break;
                case 1:
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "New game"));
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "=> High scores"));
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Options"));
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Quit"));
                    break;
                case 2:
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "New game"));
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "High scores"));
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "=> Options"));
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Quit"));
                    break;
                case 3:
                case -1:
                    //3 and -1 because we want the selector to loop and go to the last option after hitting upArrow from first
                    counter = 3;
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "New game"));
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "High scores"));
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Options"));
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "=> Quit"));
                    break;
                default:
                    counter = 0;
                    break;
            }
        }
        public static int ReadKey(ConsoleKeyInfo key, ref int counter)
        {
            if (key.Key == ConsoleKey.DownArrow) return ++counter;
            if (key.Key == ConsoleKey.UpArrow)   return --counter;
            return counter;
        }
        static void Main(string[] args)
        {
            int counter = 0;
            MenuPrint(ref counter);
            while (true)
            {
                var key = Console.ReadKey();
                Console.Clear();
                ReadKey(key, ref counter);
                MenuPrint(ref counter);

            }
        }
    }
}
