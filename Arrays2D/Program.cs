using System;

namespace Arrays2D
{
    internal class Arrays2D
    {
        static int[,] everyDirectionChange =
        {
            { -1, -1 },
            { -1, 0 },
            { -1, 1 },
            { 0, -1 },
            { 0, 1 },
            { 1, -1 },
            { 1, 0 },
            { 1, 1 }
        };
        
        static void Main(string[] args)
        {
            int[,] sea = new int[Random.Shared.Next(10, 20), Random.Shared.Next(10, 20)];
            Islands.GenerateIslands(sea);
            Islands.PrintIslands(sea);
            
            int[,] countedLand = new int[0, 2];
            int islandCount = 0;
            for (int i = 0; i < sea.GetLength(0); i++)
            {
                for (int j = 0; j < sea.GetLength(1); j++)
                {
                    if (sea[i, j] == 0 || Contains(countedLand, i, j)) continue;
                    AddLand(ref countedLand, i, j);
                    islandCount++;
                    CountLand(i, j, sea, ref countedLand);
                }
            }
            Console.WriteLine(islandCount);
        }
        
        static void Resize2D(ref int[,] array)
        {
            int[,] newArray = new int[array.GetLength(0)+1, 2];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    newArray[i, j] = array[i, j];
                }
            }
            array = newArray;
        }

        static bool Contains(int[,] array, int x, int y)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (array[i, 0] == x && array[i, 1] == y) return true;
            }
            return false;
        }

        static void AddLand(ref int[,] array, int x, int y)
        {
            Resize2D(ref array);
            array[array.GetLength(0)-1, 0] = x;
            array[array.GetLength(0)-1, 1] = y;
        }

        static void CountLand(int x, int y, int[,] sea, ref int[,] countedLand)
        {
            for (int i = 0; i < 8; i++)
            {
                int a = x + everyDirectionChange[i, 0];
                int b = y + everyDirectionChange[i, 1];
                if (!areCoordinatesValid(a, b, sea)) continue;
                if (sea[a, b] == 0 || Contains(countedLand, a, b)) continue;
                AddLand(ref countedLand, a, b);
                CountLand(a, b, sea, ref countedLand);
            }
        }

        static bool areCoordinatesValid(int x, int y, int[,] sea)
        {
            if (x < 0 || y < 0) return false;
            if (x >= sea.GetLength(0) || y >= sea.GetLength(1)) return false;
            return true;
        }
    }
}