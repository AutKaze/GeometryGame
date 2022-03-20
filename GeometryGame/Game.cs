using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryGame
{
    class Game
    {
        public static void GeometryGame(Field field, int step)
        {
            int[,] arrayField = field.CreateArray();
            string nameFirstPlayer = Player.InputPlayerInfo();
            string nameSecondPlayer = Player.InputPlayerInfo();
            int stepPlayer = 20;
            int stepCurrent = 0;
            int scoreFirst = 0;
            int scoreSecond = 0;
            int stepCurrentFirst = 1;
            int stepCurrentSecond = 1;
            int totalEmptySpaces = field.Length * field.Width;
            int countRoll = 0;

            Player fPlayer = new Player(nameFirstPlayer, stepPlayer);
            Player sPlayer = new Player(nameSecondPlayer, stepPlayer);
            Console.Clear();

            while (stepPlayer >= stepCurrent)
            {
                field.PrintArray(arrayField);
                int numberPlayer, firstValue, secondValue;
                Dice dice = new Dice();
                firstValue = dice.RollTheDice();
                secondValue = dice.RollTheDice();

                bool ckeckArray = field.CheckAllArray(arrayField, firstValue, secondValue);

                if (ckeckArray == false)
                {
                    if (countRoll == 1)
                    {
                        countRoll = 0;
                        stepCurrent++;
                        continue;
                    }
                    countRoll++;
                    continue;
                }

                if (stepCurrent % 2 == 1)
                {
                    field.PrinSumAndTotalSum(scoreSecond, nameSecondPlayer, false, totalEmptySpaces);
                    field.PrinSumAndTotalSum(scoreFirst, nameFirstPlayer, true, totalEmptySpaces);

                    fPlayer.PrintPlayerName();
                    numberPlayer = 1;

                    scoreFirst += fPlayer.Square(firstValue, secondValue);

                    int sumFirstPlayer = fPlayer.Square(firstValue, secondValue);

                    if (totalEmptySpaces >= sumFirstPlayer)
                    {
                        totalEmptySpaces -= sumFirstPlayer;
                    }
                    else
                    {
                        totalEmptySpaces = 0;
                    }

                    dice.PrintRoll(firstValue, secondValue, fPlayer);

                    Console.SetCursorPosition(1, 1);
                    Console.WriteLine($"Step: {stepCurrentFirst}");

                    field.PrintArray(arrayField);

                    field.PrinSumAndTotalSum(scoreSecond, nameSecondPlayer, false, totalEmptySpaces);
                    field.PrinSumAndTotalSum(scoreFirst, nameFirstPlayer, true, totalEmptySpaces);

                    stepCurrentFirst++;
                }
                else
                {
                    field.PrinSumAndTotalSum(scoreFirst, nameFirstPlayer, true, totalEmptySpaces);
                    field.PrinSumAndTotalSum(scoreSecond, nameSecondPlayer, false, totalEmptySpaces);
                    
                    sPlayer.PrintPlayerName();

                    numberPlayer = 2;

                    scoreSecond += sPlayer.Square(firstValue, secondValue);

                    int sumSecondPlayet = sPlayer.Square(firstValue, secondValue);

                    if (totalEmptySpaces >= sumSecondPlayet)
                    {
                        totalEmptySpaces -= sumSecondPlayet;
                    }
                    else
                    {
                        totalEmptySpaces = 0;
                    }

                    dice.PrintRoll(firstValue, secondValue, sPlayer);

                    Console.SetCursorPosition(1, 1);
                    Console.WriteLine($"Step: {stepCurrentSecond}");

                    field.PrintArray(arrayField);

                    field.PrinSumAndTotalSum(scoreFirst, nameFirstPlayer, true, totalEmptySpaces);
                    field.PrinSumAndTotalSum(scoreSecond, nameSecondPlayer, false, totalEmptySpaces);
                    stepCurrentSecond++;
                }

                

                Console.SetCursorPosition(1, 18);
                while (true)
                {
                    bool check = false;

                    int rowCoor = field.WriteCoor(arrayField, secondValue, 0);
                    int colCoor = field.WriteCoor(arrayField, firstValue, 1);

                    bool checkDouble = field.CheckArray(arrayField, firstValue, secondValue, rowCoor, colCoor, check);

                    if (checkDouble)
                    {
                        field.FillSquare(arrayField, secondValue, firstValue, rowCoor, colCoor, numberPlayer);
                        stepCurrent++;
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(1, Console.CursorTop);
                        Console.WriteLine("Incorrect coordiante");
                    }
                }

                Console.SetCursorPosition(1, Console.CursorTop);
                Console.WriteLine("Press any key to continue");

                field.PrintArray(arrayField);

                Console.ReadKey();

                if (totalEmptySpaces <= 0 || (stepCurrent + 1) > stepPlayer)
                {
                    Player.PrintWinner(scoreFirst, scoreSecond, nameFirstPlayer, nameSecondPlayer);
                    break;
                }

                Console.Clear();
            }
        }
    }
}
