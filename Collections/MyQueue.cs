namespace Collections;

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