namespace Collections;

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