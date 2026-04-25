namespace Collections;

class MyQueue : MyCollection
{
    public void Enqueue(object? item)
    {
        if (ArraySize - 1 == Count)
        {
            Array.Resize(ref Items, ArraySize * 2);
        }
        Count++;
        Items[ArraySize - 1] = item;
    }

    public object? Dequeue()
    {
        object? item = Peek();
        Count--;
        for (int i = 0; i < Count - 1; i++)
        {
            Items[i] = Items[i + 1];
        }
        return item;
    }

    public object? Peek()
    {
        if (ArraySize == 0) throw new ArgumentException("Queue is empty");
        return Items[0];
    }
}