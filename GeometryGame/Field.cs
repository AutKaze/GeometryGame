using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryGame
{
    class Field
    {
        private int length;
        private int width;

        public Field(int lengthField, int widthField)
        {
            this.length = lengthField;
            this.width = widthField;

            if (lengthField < 20)
            {
                throw new ArgumentException("The minimum length must be greater than or equal to 20");
            }

            if (widthField < 30)
            {
                throw new ArgumentException("the minimum width must be greater than or equal to 30");
            }
        }

        public int Length { get => length; }

        public int Width { get { return width; } }

        public int[,] CreateArray()
        {
            int length = this.length;
            int width = this.width;
            int[,] array = new int[width, length];
            return array;
        }

        public void PrintArray(int[,] array)
        {
            int top = 5;
            int left = 44;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(40, top);
                Console.WriteLine(i.ToString(), Console.ForegroundColor);
                
                Console.SetCursorPosition(44, top);
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.SetCursorPosition(left, top);
                    if (array[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(array[i,j].ToString(), Console.ForegroundColor);
                    }
                    else if (array[i, j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(array[i, j].ToString(), Console.ForegroundColor);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(array[i, j].ToString(), Console.ForegroundColor);
                    }

                    left += 3;
                }
                left = 44;
                top++;
                Console.WriteLine("");
            }

            for (int k = 0; k < array.GetLength(1); k++)
            {
                Console.SetCursorPosition(left, 4);
                Console.Write(k.ToString(), Console.ForegroundColor);

                left += 3;
            }
        }

        public bool CheckAllArray(int[,] array, int firstValue, int secondValue)
        {
            bool IsCheckAllArray = false;
            bool checkCol = false;
            int colCoor = 0;
            int count = 0;
            int countCol = 0;
            int countRow = 0;
            for (int i = 0; i <= array.GetLength(0) - ((secondValue - 1) * 2); i++)
            {
                if (array[i, (array.GetLength(1) - (secondValue - 1) - 1)] == 0 || array[i, (secondValue-1)] == 0)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if ((j + 1) >= array.GetLength(1))
                        {
                            count = 0;
                            break;
                        }
                        if (array[i, j] == 0 && array[i, j + 1] == 0)
                        {
                            count++;
                            if (count == secondValue)
                            {
                                colCoor = j - (secondValue - 1);

                                int rowCoor = i;

                                for (int k = 0; k < secondValue; k++)
                                {
                                    if (array[rowCoor, colCoor] != 0)
                                    {
                                        j = colCoor;
                                        checkCol = false;
                                        countCol = 0;
                                        count = 0;
                                        break;
                                    }
                                    else
                                    {
                                        countRow++;
                                        if ((rowCoor + 1) < array.GetLength(0))
                                        {
                                            rowCoor++;
                                        }
                                        if (countRow == (firstValue))
                                        {
                                            k = -1;
                                            rowCoor = i;
                                            colCoor++;
                                            checkCol = true;
                                            countRow = 0;
                                            IsCheckAllArray = true;
                                            countCol++;
                                            if (countCol == firstValue)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }

                                if (checkCol == true)
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            count = 0;
                        }
                    }

                    if (checkCol == true)
                    {
                        break;
                    }
                    
                }
            }
            
            return IsCheckAllArray;
        }

        public bool CheckArray(int[,] array, int firstValue, int secondValue, int coorOne, int coorTwo, bool check)
        {
            if (array[coorOne, coorTwo] != 1 && array[coorOne, coorTwo] != 2)
            {
                for (int i = 0; i < secondValue; i++)
                {
                    for (int j = 0; j < firstValue; j++)
                    {
                        if ((j + coorTwo) < array.GetLength(1) && array[i + coorOne, j + coorTwo] != 1 && array[i + coorOne, j + coorTwo] != 2)
                        {
                            check = true;
                        }
                        else
                        {
                            check = false;
                            break;
                        }
                    }
                    if (check == false)
                    {
                        break;
                    }
                }
            }

            return check;
        }

        public void FillSquare(int[,] array, int firstValue, int secondValue, int coorOne, int coorTwo, int number)
        {
            for (int i = 0; i < firstValue; i++)
            {
                for (int j = 0; j < secondValue; j++)
                {
                    array[i + coorOne, j + coorTwo] = number;
                }
            }
        }

        public int WriteCoor(int[,] array, int value, int rowOrColumn)
        {
            int coor;
            int numberCoor = rowOrColumn + 1;
            while (true)
            {
                Console.SetCursorPosition(1, Console.CursorTop);
                if (numberCoor == 1)
                {
                    Console.WriteLine($"Please enter coordinate {numberCoor}: ");
                    Console.SetCursorPosition(1, Console.CursorTop);
                    Console.WriteLine($"Please enter in the range 0-{this.Width}");
                    Console.SetCursorPosition(1, Console.CursorTop);
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine($"Please enter coordinate {numberCoor}: ");
                    Console.SetCursorPosition(1, Console.CursorTop);
                    Console.WriteLine($"Please enter in the range 0-{this.Length}");
                    Console.SetCursorPosition(1, Console.CursorTop);
                    Console.WriteLine("");
                }
                Console.SetCursorPosition(1, Console.CursorTop);
                string inputRow = Console.ReadLine();
                bool rowSuccessParse = int.TryParse(inputRow, out int rowCoor);

                if (rowSuccessParse && (array.GetLength(rowOrColumn) - rowCoor) >= (value) && rowCoor >= 0)
                {
                    Console.SetCursorPosition(1, Console.CursorTop);
                    
                        Console.WriteLine($"Coordinate {numberCoor}: {rowCoor}.");
                    coor = rowCoor;
                    break;
                }
                else
                {
                    Console.SetCursorPosition(1, Console.CursorTop);
                    if (numberCoor == 1)
                    {
                        Console.WriteLine($"Incorrect coordinate {numberCoor}.");
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect coordinate {numberCoor}.");
                    }

                }
            }

            return coor;
        }

        public static int ParseLengthOrWidth(bool lengthOrWidth)
        {
            while (true)
            {
                
                if (lengthOrWidth)
                {
                    Console.WriteLine("Please enter the length: ");
                    


                    bool lengthSuccessParse = int.TryParse(Console.ReadLine(), out int lengths);
                    if (lengthSuccessParse && lengths >= 20)
                    {
                        if (Console.BufferWidth < ((lengths * 3) + 47))
                        {
                            Console.WriteLine($"The length of the field is larger than your console window, please enter a number less than: {(Console.BufferWidth - 46) / 3} ");
                            continue;
                        }

                        int length = lengths;
                        return length;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect field length. Please enter a number more than: {lengths} ");
                        continue;
                    }
                }
                else
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.WriteLine("Please enter the width: ");

                    bool lengthSuccessParse = int.TryParse(Console.ReadLine(), out int widths);
                    if (lengthSuccessParse && widths >= 30)
                    {
                        if (Console.BufferHeight <= widths - 6)
                        {
                            Console.WriteLine($"The width of the field is larger than your console window, please enter a number less than: {Console.BufferHeight - 5}");
                            continue;
                        }

                        int width = widths;
                        return width;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect field width. Please enter a number more than: {widths} ");
                        continue;
                    }
                }
            }
        }

        public void PrinSumAndTotalSum(int sumPlayer, string namePlayer, bool firstOrSecondPlayer, int totalEmptySpaces)
        {
            int leng = Length;
            if (leng <= 39)
            {
                leng = 39;
            }

            for (int j = 0; j < 4; j++)
            {
                Console.SetCursorPosition(83, j);
                Console.BackgroundColor = ConsoleColor.White;
                ConsoleColor current = Console.BackgroundColor;
                Console.Write(" ", current);
            }

            for (int i = 40; i < (leng + 44); i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                ConsoleColor current = Console.BackgroundColor;
                Console.Write(" ", current);
            }

            for (int k = 0; k < (Width + 5); k++)
            {
                Console.SetCursorPosition(39, k);
                Console.BackgroundColor = ConsoleColor.White;
                ConsoleColor current = Console.BackgroundColor;
                Console.Write(" ", current);
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(41, 1);
            Console.WriteLine($"Total available empty cells: {totalEmptySpaces}");

            if (firstOrSecondPlayer)
            {
                Console.SetCursorPosition(41, 2);
                Console.WriteLine($"Score {namePlayer}: {sumPlayer}");
            }
            else
            {
                Console.SetCursorPosition(41, 3);

                Console.WriteLine($"Score {namePlayer}: {sumPlayer}");
            }
        }
    }
}
