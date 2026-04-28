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
            // list[2] = "Keti";
            // Console.WriteLine(list.Contains("Keti"));
            // Console.WriteLine(list.Add(null));

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("------------------------------");
            
            MyStack stack = new MyStack();
            stack.Push("Giorgi");
            stack.Push("Nino");
            stack.Push("Luka");
            stack.Push("Sandro");
            stack.Push("Giorgi");
            stack.Push(null);
            // list.RemoveAt(4);
            // list[2] = "Keti";
            // Console.WriteLine(list.Contains("Keti"));
            // Console.WriteLine(list.Add(null));

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine("------------------------------");
            
            MyQueue queue = new MyQueue();
            queue.Enqueue("Giorgi");
            queue.Enqueue("Nino");
            queue.Enqueue("Luka");
            queue.Enqueue("Sandro");
            queue.Enqueue("Giorgi");
            queue.Enqueue(null);
            // list.RemoveAt(4);
            // list[2] = "Keti";
            // Console.WriteLine(list.Contains("Keti"));
            // Console.WriteLine(list.Add(null));

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }
}