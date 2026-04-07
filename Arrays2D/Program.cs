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
            // Generating islands
            int[,] sea = new int[Random.Shared.Next(10, 20), Random.Shared.Next(10, 20)];
            Islands.GenerateIslands(sea);
            Islands.PrintIslands(sea);
            
            // countedLand contains land coordinates
            int[,] countedLand = new int[0, 2];
            // islandCount counts unique islands
            int islandCount = 0;
            for (int i = 0; i < sea.GetLength(0); i++)
            {
                for (int j = 0; j < sea.GetLength(1); j++)
                {
                    // if land with coordinates i and j is water or is in countedLand we skip
                    if (sea[i, j] == 0 || Contains(countedLand, i, j)) continue;
                    // if not we save the coordinates in countedLand
                    AddLand(ref countedLand, i, j);
                    islandCount++;
                    // CountLand counts all land that is connected in some way with i, j land
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
                int newX = x + everyDirectionChange[i, 0];
                int newY = y + everyDirectionChange[i, 1];
                if (!AreCoordinatesValid(newX, newY, sea)) continue;
                if (sea[newX, newY] == 0 || Contains(countedLand, newX, newY)) continue;
                AddLand(ref countedLand, newX, newY);
                CountLand(newX, newY, sea, ref countedLand);
            }
        }

        static bool AreCoordinatesValid(int x, int y, int[,] sea)
        {
            if (x < 0 || y < 0) return false;
            return x < sea.GetLength(0) && y < sea.GetLength(1);
        }
    }
}