using System.Collections;

namespace Collections
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            MyQueue queue = new MyQueue();
            queue.Enqueue(4);
            queue.Enqueue(5);
            Console.WriteLine(queue.Dequeue());
            queue.Enqueue(2);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Count);
            
            // queue.Enqueue("Ana");
            // queue.Enqueue("Bacho");
            // queue.Enqueue("Dato");
            // queue.Enqueue("დათო");
            //
            // while (queue.Count > 0)
            // {
            //     object? item = queue.Dequeue();
            //     Console.WriteLine(item);
            // }

            // MyStack stack = new MyStack();
            // // stack.Push("Ana");
            // // stack.Push("Bacho");
            // // stack.Push("Dato");
            // // stack.Push("დათო");
            // stack.Push(4);
            // stack.Push(5);
            // Console.Write(stack.Count);

            // while (stack.Count > 0)
            // {
            //     object? item = stack.Peek();
            //     Console.WriteLine(item);
            // }
        }
    }

    class MyStack
    {
        private object?[] _objects = [];
        public int Count { get; private set; }

        public void Push(object? item)
        {
            Array.Resize(ref _objects, Count+1);
            Count++;
            _objects[Count - 1] = item;
        }

        public object? Pop()
        {
            if (Count == 0) throw new ArgumentException("Stack is empty");
            object? item = _objects[Count - 1];
            Array.Resize(ref _objects, Count - 1);
            Count--;
            return item;
        }

        public object? Peek()
        {
            if (Count == 0) throw new ArgumentException("Stack is empty");
            return _objects[Count - 1];
        }
    }

    class MyQueue
    {
        private object?[] _objects = [];
        public int Count { get; private set; }

        public void Enqueue(object? item)
        {
            Array.Resize(ref _objects, Count + 1);
            Count++;
            _objects[Count - 1] = item;
        }

        public object? Dequeue()
        {
            if (Count == 0) throw new ArgumentException("Queue is empty");
            object? item = _objects[0];
            Array.Reverse(_objects);
            Array.Resize(ref _objects, Count - 1);
            Array.Reverse(_objects);
            Count--;
            return item;
        }

        public object? Peek()
        {
            if (Count == 0) throw new ArgumentException("Queue is empty");
            return _objects[0];
        }
    }
}