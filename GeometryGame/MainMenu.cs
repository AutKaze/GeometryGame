using System;
using System.Runtime.InteropServices;

namespace GeometryGame
{
    class MainMenu
    {
        public static void Print(string[] points, int choose)
        {
            Console.Clear();

            for (int i = 0; i < points.Length; i++)
            {

                Console.WriteLine("{0} {1}", points[i], i == choose ? "" + (char)9668 : "");

            }
        }

        public static int MenuProcess(string[] points)
        {
            Console.CursorVisible = false;
            int choose = 0;
            while (true)
            {
                Print(points, choose);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow: choose--; break;
                    case ConsoleKey.DownArrow: choose++; break;
                    case ConsoleKey.Enter: Console.CursorVisible = true; return choose;
                    case ConsoleKey.Escape: return 0;
                }
                choose = (choose + points.Length) % points.Length;
            }
        }

        public static int GoToSettingsField()
        {
            string[] pointsFieldMenu = { "1) Default value of field (length(20), width(30))", 
                                         "2) Change value of field (min length(20), min width(30))",
                                         "3) Return to main menu"};
            int result = MenuProcess(pointsFieldMenu);
            return result;
        }

        public static int GoToMenu()
        {
            string[] points = { "1) Start ", "2) Выход" };
            int result = MenuProcess(points);
            return result;
        }

        public static int GoToMainWindow()
        {
            Console.CursorVisible = false;
            Console.WriteLine("*************************************************\n" +
                              "*                   Welcome                     *\n" +
                              "*                Geometry Game                  *\n" +
                              "*                 Trying win                    *\n" +
                              "*************************************************\n");
            Console.WriteLine("" +
                "" +
                "Try Esc for exit or Enter for menu page");
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter: return 1; // В меню
                    case ConsoleKey.Escape: return 0; // Выход
                }
            }
        }

        public static void Loop(int sres)
        {
            int res = sres;
            bool loop = true;
            int newres = 0;

            if (res == 1)
            {
                newres = GoToMainWindow();
            }

            while (loop)
            {
                Console.Clear();
                
                if (newres == 0)
                {
                    Console.WriteLine("Good Bye!");
                    System.Threading.Thread.Sleep(1000);
                    loop = false;
                }

                if (newres == 1)
                {
                    int menuRes;
                    Console.Clear();
                    menuRes = GoToMenu();
                    if (menuRes == 0)
                    {
                        int menuSettingsField = GoToSettingsField();
                        if (menuSettingsField == 0)
                        {
                            Console.Clear();
                            int length = 20;
                            int width = 30;
                            int step = 20;
                            Field field = new Field(length, width);
                            Game.GeometryGame(field, step);
                            loop = false;
                        }

                        if (menuSettingsField == 1)
                        {
                            Console.Clear();
                            int length = Field.ParseLengthOrWidth(true);
                            int width = Field.ParseLengthOrWidth(false);
                            int stepPlayer = Player.ParseStepPlayer();

                            Field field = new Field(length, width);

                            Game.GeometryGame(field, stepPlayer);

                            loop = false;
                        }

                        if (menuSettingsField == 2)
                        {
                                newres = 1;
                        }
                    }
                    if (menuRes == 1)
                    {
                        newres = 0;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.SetWindowSize(Console.WindowWidth, Console.WindowHeight);
            Loop(1);
        }
    }
}
