using System;

namespace Test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Sum(5, 2).GetType());
        }

        static string Sum(int a, int b)
        {
            return (a + b).ToString();
        }
    }
}