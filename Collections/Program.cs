using System.Collections;
using System.Diagnostics;

namespace Collections
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Stopwatch stopwatch = new Stopwatch();
            // int count = 999;
            // stopwatch.Start();
            // Stack stack = new Stack();
            // for (int i = 0; i < count; i++)
            // {
            //     stack.Push(i);
            // }
            // for (int i = 0; i < count; i++)
            // {
            //     stack.Pop();
            // }
            // stopwatch.Stop();
            // Console.WriteLine($"Stack time: {stopwatch.ElapsedTicks} ticks");
            // stopwatch.Restart();
            // Queue queue = new Queue();
            // for (int i = 0; i < count; i++)
            // {
            //     queue.Enqueue(i);
            // }
            // for (int i = 0; i < count; i++)
            // {
            //     queue.Dequeue();
            // }
            // stopwatch.Stop();
            // Console.WriteLine($"Queue time: {stopwatch.ElapsedTicks} ticks");
            // stopwatch.Restart();
            // MyStack myStack = new MyStack();
            // for (int i = 0; i < count; i++)
            // {
            //     myStack.Push(i);
            // }
            //
            // for (int i = 0; i < count; i++)
            // {
            //     myStack.Pop();
            // }
            // stopwatch.Stop();
            // Console.WriteLine($"MyStack time: {stopwatch.ElapsedTicks} ticks");
            // stopwatch.Restart();
            // MyQueue myQueue = new MyQueue();
            // for (int i = 0; i < count; i++)
            // {
            //     myQueue.Enqueue(i);
            // }
            // for (int i = 0; i < count; i++)
            // {
            //     myQueue.Dequeue();
            // }
            // stopwatch.Stop();
            // Console.WriteLine($"MyQueue time: {stopwatch.ElapsedTicks} ticks");
            // stopwatch.Restart();
            
            

            MyStack stack = new MyStack();
            // stack.Push("Ana");
            // stack.Push("Bacho");
            // stack.Push("Dato");
            // stack.Push("დათო");
            stack.Push(4);
            stack.Push(5);
            Console.Write(stack.Count);

            while (stack.Count > 0)
            {
                object? item = stack.Peek();
                Console.WriteLine(item);
            }
        }
    }

    class MyCollection
    {
        protected object?[] Objects = new object?[1];
        protected int ArraySize => Objects.Length;
        public int Count {get; protected set;}
    }
    
    class MyStack : MyCollection
    {
        public void Push(object? item)
        {
            if (ArraySize - 1 == Count)
            {
                Array.Resize(ref Objects, ArraySize * 2);
            }
            Count++;
            Objects[ArraySize - Count - 1] = item;
        }

        public object? Pop()
        {
            object? item = Peek();
            Count--;
            return item;
        }

        public object? Peek()
        {
            if (Count == 0) throw new ArgumentException("Stack is empty");
            return Objects[Count - 1];
        }
    }

    class MyQueue : MyCollection
    {
        public void Enqueue(object? item)
        {
            if (ArraySize - 1 == Count)
            {
                Array.Resize(ref Objects, ArraySize * 2);
            }
            Count++;
            Objects[ArraySize - 1] = item;
        }

        public object? Dequeue()
        {
            object? item = Peek();
            Count--;
            for (int i = 0; i < Count - 1; i++)
            {
                Objects[i] = Objects[i + 1];
            }
            return item;
        }

        public object? Peek()
        {
            if (ArraySize == 0) throw new ArgumentException("Queue is empty");
            return Objects[0];
        }
    }
}