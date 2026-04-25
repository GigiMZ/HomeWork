namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList list = new MyList();
            list.Add("Giorgi");
            list.Add("Nino");
            list.Add("Luka");
            list.Add("Sandro");
            list.Add("Giorgi");
            list.Add(null);
            // list.RemoveAt(4);
            list[2] = "Keti";
            Console.WriteLine(list.Contains("Keti"));
            Console.WriteLine(list.Add(null));

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"Element at index {i}: {list[i]}");
            }
            Console.WriteLine(list.Count);

            // int index = list.IndexOf("Giorgi");
            // while (index != -1)
            // {
            //     Console.WriteLine($"Giorgi found at index: {index}");
            //     index = list.IndexOf("Giorgi", index + 1);
            // }
        }
    }
}