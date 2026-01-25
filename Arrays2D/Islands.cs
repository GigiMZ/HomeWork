using System;

namespace Arrays2D
{

    public class Islands
    {
        public static void PrintIslands(int[,] sea)
        {
            for (int i = 0; i < sea.GetLength(0); i++)
            {
                for (int j = 0; j < sea.GetLength(1); j++)
                {
                    if (sea[i, j] == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }

                    Console.Write($"{sea[i, j]} ");
                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }

        public static void GenerateIslands(int[,] sea)
        {
            for (int i = 0; i < sea.GetLength(0); i++)
            {
                for (int j = 0; j < sea.GetLength(1); j++)
                {
                    sea[i, j] = Random.Shared.Next(10) > 7 ? 1 : 0;
                }
            }
        }
    }
}