using System.Collections;

namespace Collections;

class MyQueue : MyCollection
{
    public void Enqueue(object? item)
    {
        if (ArraySize == Count)
        {
            Array.Resize(ref Items, ArraySize * 2);
        }
        Count++;
        Items[Count - 1] = item;
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

    public override IEnumerator GetEnumerator()
    {
        return new MyQueueEnumerator(Items, Count);
    }
}

class MyQueueEnumerator : IEnumerator
{
    public object? Current => _items[_index];
    private readonly object?[] _items;
    private readonly int _count;
    private int _index;

    public MyQueueEnumerator(object?[] items, int count)
    {
        _items = items;
        _count = count;
        _index = _count;
    }

    public bool MoveNext()
    {
        if (_index > 0)
        {
            _index--;
            return true;
        }
        return false;
    }

    public void Reset()
    {
        _index = _count;
    }
}