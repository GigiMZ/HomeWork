namespace Collections;

class MyStack : MyCollection
{
    public void Push(object? item)
    {
        if (ArraySize - 1 == Count)
        {
            Array.Resize(ref Items, ArraySize * 2);
        }
        Count++;
        Items[ArraySize - Count - 1] = item;
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
        return Items[Count - 1];
    }
}