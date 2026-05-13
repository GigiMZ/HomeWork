namespace Collections
{
    internal class Program
    {
        static void Main()
        {
            MyNode<string> node1 = new MyNode<string>("Giorgi");
            MyNode<string> node2 = new MyNode<string>("Guka");
            MyNode<string> node3 = new MyNode<string>("Giorgi P");
            MyNode<string> node4 = new MyNode<string>("Nika");
            MyNode<string> node5 = new MyNode<string>("Ana");

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;

            Print(node1);

            LinkedList<string> list = new LinkedList<string>();
        }

        static void Print(MyNode<string>? node)
        {
            while (node != null)
            {
                Console.WriteLine(node);
                node = node.Next;
            }
        }
    }
}