using System.Collections;

namespace Collections;

class MyStack<T> : MyCollection<T>
{
    public void Push(T? item)
    {
        if (ArraySize == Count)
        {
            Array.Resize(ref Items, ArraySize * 2);
        }
        Items[Count] = item;
        Count++;
    }

    public T? Pop()
    {
        T? item = Peek();
        Count--;
        return item;
    }

    public T? Peek()
    {
        if (Count == 0) throw new ArgumentException("Stack is empty");
        return Items[Count - 1];
    }

    // public override IEnumerator GetEnumerator()
    // {
    //     return new MyStackEnumerator(Items, Count);
    // }
}

class MyStackEnumerator : IEnumerator
{
    public object? Current => _items[_count - _index];
    private readonly object?[] _items;
    private readonly int _count;
    private int _index;
    
    public MyStackEnumerator(object?[] items, int count)
    {
        _items = items;
        _count = count;
        _index = count;
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