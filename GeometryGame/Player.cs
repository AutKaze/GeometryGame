using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryGame
{
    public class Player
    {
        private string namePlayer;
        private int stepPlayer;
        
        public Player (string nameOfPlayer, int stepOfPlayer)
        {
            this.namePlayer = nameOfPlayer;
            this.stepPlayer = stepOfPlayer;

            if (string.IsNullOrWhiteSpace(namePlayer))
            {
                throw new ArgumentNullException(nameof(namePlayer), "Name can't be null");
            }

            if (string.IsNullOrEmpty(namePlayer))
            {
                throw new ArgumentException("Name can't be empty");
            }

            if (stepPlayer < 20)
            {
                throw new ArgumentException("Minimum number of steps shouldn't be less than 20");
            }
        }

        public string NamePlayer { get; }
        public int StepPlayer { get; }

        public int Square(int a, int b)
        {
            int c = a * b;
            return c;
        }

        public static string InputPlayerInfo()
        {
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter name first player: ");
                string namePlayer = Console.ReadLine();
                if (!string.IsNullOrEmpty(namePlayer) && !string.IsNullOrWhiteSpace(namePlayer))
                {
                    return namePlayer;
                }
                else
                {
                    Console.WriteLine("You entered the wrong name. Please click any key to continue.");
                    Console.ReadKey();
                    continue;
                }
            }
        }

        public void PrintPlayerName()
        {
            for (int i = 0; i < 39; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                ConsoleColor current = Console.BackgroundColor;
                Console.Write(" ", current);
                Console.SetCursorPosition(i, 15);
                Console.Write(" ", current);
            }

            for (int j = 0; j < 16; j++)
            {
                Console.SetCursorPosition(0, j);
                Console.BackgroundColor = ConsoleColor.Gray;
                ConsoleColor current = Console.BackgroundColor;
                Console.Write(" ", current);
                Console.SetCursorPosition(39, j);
                Console.Write(" ", current);
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(1, 2);
            Console.WriteLine($"Player name: {namePlayer}");
        }

        public static void PrintWinner(int sumFirst, int sumSecond, string namePlayerFirst, string namePlayerSecond)
        {
            if (sumFirst > sumSecond)
            {
                Console.Clear();
                Console.WriteLine($"The winner is the player {namePlayerFirst}");
                Console.ReadKey();
            }
            else if (sumSecond > sumFirst)
            {
                Console.Clear();
                Console.WriteLine($"The winner is the player {namePlayerSecond}");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"DRAW");
                Console.ReadKey();
            }
        }

        public static int ParseStepPlayer()
        {
            while (true)
            {
                Console.WriteLine("Please enter the step: ");

                bool stepSuccesParse = int.TryParse(Console.ReadLine(), out int stepPlayer);
                if (stepSuccesParse && stepPlayer >= 20)
                {
                    Console.WriteLine("Correct step: " + stepPlayer);
                    int step = stepPlayer;
                    return step;
                }
                else
                {
                    Console.WriteLine($"Wrong number of steps. Please enter greater than or equal to 20");
                    continue;
                }
            }
        }
    }
}
