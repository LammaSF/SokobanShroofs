using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.;

namespace EndScreen
{
    class EndScreen
    {
        public static int counter = 0;
        public static string name = new string(' ', Console.WindowWidth / 2 - 42 / 2) + new string('s', 5) + "  " + new string('o', 3) + "  k" + new string(' ', 3) + "k  " +
               new string('o', 3) + "  " + new string('b', 4) + "   " + new string('a', 3) + "  n   n" + "\n"
                + new string(' ', Console.WindowWidth / 2 - 42 / 2) + new string('s', 2) + "    o" + new string(' ', 3) + "o k  k  o   o b   b a   a nn  n\n"
                + new string(' ', Console.WindowWidth / 2 - 42 / 2) + new string('s', 5) + " o" + new string(' ', 3) + "o kkk   o   o " + new string('b', 4) + "  " + new string('a', 5) + " n n n\n"
                + new string(' ', Console.WindowWidth / 2 - 42 / 2) + new string(' ', 3) + new string('s', 2) + " o" + new string(' ', 3) + "o k  k  o   o b   b a   a n  nn\n"
                + new string(' ', Console.WindowWidth / 2 - 42 / 2) + new string('s', 5) + "  " + new string('o', 3) + "  k   k  " + new string('o', 3) + "  " + new string('b', 4) + "  a   a n   n";

        public static string win = new string(' ', Console.WindowWidth / 2 - 30 / 2) + "WW" + new string(' ', 6) + "WW" + "    " + "II" + "    " + "NNN" + new string(' ', 4) + "NN" + "\n"
                + new string(' ', Console.WindowWidth / 2 - 30 / 2) + "WW" + new string(' ', 6) + "WW" + "    " + "II" + "    " + "NNN" + new string(' ', 4) + "NN" + "\n"
                + new string(' ', Console.WindowWidth / 2 - 30 / 2) + "WW" + new string(' ', 6) + "WW" + "    " + "II" + "    " + "NN" + new string(' ', 1) + "NN" + new string(' ', 2) + "NN" + "\n"
                + new string(' ', Console.WindowWidth / 2 - 30 / 2) + " WW" + new string(' ', 1) + "WW" + new string(' ', 1) + "WW " + "    " + "II" + "    " + "NN" + new string(' ', 2) + "NN" + new string(' ', 1) + "NN" + "\n"
                + new string(' ', Console.WindowWidth / 2 - 30 / 2) + "  WW" + new string(' ', 2) + "WW  " + "    " + "II" + "    " + "NN" + new string(' ', 4) + "NNN" + "\n";
        public static string loose = new string(' ', Console.WindowWidth / 2 - 30 / 2) + "LL     " + " " + new string('0', 3) + " " + "   " + new string('0', 3) + " "+"  "+new string('s', 5)+"  "+new string('E',5)+"\n"
                                     + new string(' ', Console.WindowWidth / 2 - 30 / 2)+"LL     " +"O"+ new string(' ',3)+"O  "+"O"+ new string(' ',3)+"O  "+"SS"+new string(' ',3)+"  "+"EE"+"   "+"\n"
                                     + new string(' ', Console.WindowWidth / 2 - 30 / 2)+"LL     " +"O"+ new string(' ',3)+"O  "+"O"+ new string(' ',3)+"O  "+new string('S',5)+"  "+new string('E',5)+"\n"
                                     + new string(' ', Console.WindowWidth / 2 - 30 / 2)+"LL     " +"O"+ new string(' ',3)+"O  "+"O"+ new string(' ',3)+"O  "+new string(' ',3)+"SS"+"  "+"EE"+"   "+"\n"
                                     + new string(' ', Console.WindowWidth / 2 - 30 / 2) + new string('L', 5) + "  " + " " + new string('0', 3) + " " + "   " + new string('0', 3) + " " + "  " + new string('s', 5) + "  " + new string('E', 5) + "\n";
        
        static void Main(string[] args)
        {
            
          Win();
            
           MainMenuPrint(ref counter);
            
            
           
        }
        static void Win()
        {
           
            int n=0;
            while (n<=2)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.CursorVisible = false;
                WriteBlinkingText(win, 500, true);

                Console.Clear();
                Console.CursorVisible = false;
                WriteBlinkingText(win, 500, false);
                Console.CursorVisible = false;
                Console.Clear();
                n++;
               
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(win);
           
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
               Console.WriteLine(win);
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
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(name.ToUpper());
            while (true)                            //read keys and call menu with the selector on the new position
            {
                Console.WriteLine();
                Console.WriteLine();

              
                var key = Console.ReadKey();
                
               Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                
                
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
