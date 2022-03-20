using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryGame
{
    class Dice
    {
        private int valueDice;
        
        public int RollTheDice()
        {
                Random rnd = new Random();
                valueDice = rnd.Next(1, 7);
            return valueDice;
        }
        public void PrintDice(int number)
        {
            int i = Console.CursorTop;
            Console.SetCursorPosition(Console.CursorLeft, i);
            switch (number)
            {
                case 1:
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("---------");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("|       |");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("|   #   |");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("|       |");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("---------");
                    break;
                case 2:
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("---------");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("| #     |");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("|       |");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("|     # |");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("---------");
                    break;
                case 3:
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("---------");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("| #     |");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("|   #   |");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("|     # |");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("---------");
                    break;
                case 4:
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("---------");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("| #   # |");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("|       |");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("| #   # |");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("---------");
                    Console.SetCursorPosition(1, i++);
                    break;
                case 5:
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("---------");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("| #   # |");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("|   #   |");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("| #   # |");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("---------");
                    break;
                case 6:
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("---------");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("| # # # |");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("|       |");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("| # # # |");
                    Console.SetCursorPosition(1, i++);
                    Console.WriteLine("---------");
                    break;
            }
        }
        public void PrintRoll(int fValue, int sValue, Player player)
        {
            Console.SetCursorPosition(1, 3);
            Console.WriteLine("Please click any key to roll.");
            Console.ReadKey();
            Console.Clear();
            Console.SetCursorPosition(1, 2);
            player.PrintPlayerName();

            PrintDice(fValue);
            PrintDice(sValue);
            Console.SetCursorPosition(1, Console.CursorTop);
            Console.WriteLine($"The first value of the dice: {fValue}");
            Console.SetCursorPosition(1, Console.CursorTop);
            Console.WriteLine($"The second value of the dice: {sValue}");
        }
    }
}
