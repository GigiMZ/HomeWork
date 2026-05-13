using System.Collections;

namespace Collections;

public class MyLinkedList<T> : ICollection<T>
{
    private MyNode<T>? _first;
    public int Count { get; private set; }
    public bool IsReadOnly => false;

    public MyNode<T> AddFirst(T value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        var newNode = new MyNode<T>(value, _first);
        AddFirst(newNode);
        return newNode;
    }

    public void AddFirst(MyNode<T> node)
    {
        ArgumentNullException.ThrowIfNull(node, nameof(node));

        node.Next = _first;
        _first = node;
        Count++;
    }

    public MyNode<T> AddLast(T value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        
        var newNode = new MyNode<T>(value);
        AddLast(newNode);
        return newNode;
    }

    public void AddLast(MyNode<T> node)
    {
        ArgumentNullException.ThrowIfNull(node, nameof(node));
        var beforeLastNode = _first;
        do
        {
            if (beforeLastNode?.Next == null)
            {
                beforeLastNode?.Next = node;
                break;
            }
            beforeLastNode = beforeLastNode.Next;
        } while (beforeLastNode.Next != null);

        Count++;
    }

    public MyNode<T> AddAfter(MyNode<T> node, T value)
    {
        if (Count == 0) return null;
        ArgumentNullException.ThrowIfNull(node, nameof(node));
        ArgumentNullException.ThrowIfNull(value, nameof(node));
        AddAfter(node, new MyNode<T>(value));
        return node.Next;
    }

    public void AddAfter(MyNode<T> node, MyNode<T> newNode)
    {
        if (Count == 0) return;
        ArgumentNullException.ThrowIfNull(node, nameof(node));
        ArgumentNullException.ThrowIfNull(newNode, nameof(node));
        var nextNode = node.Next;
        newNode.Next = nextNode;
        node.Next = newNode;
        Count++;
    }

    public MyNode<T> AddBefore(MyNode<T> node, T value)
    {
        if (Count == 0) return null;
        ArgumentNullException.ThrowIfNull(node, nameof(node));
        var newNode = new MyNode<T>(value);
        AddBefore(node, newNode);
        return newNode;
    }

    public void AddBefore(MyNode<T> node, MyNode<T> newNode)
    {
        if (Count == 0) return;
        ArgumentNullException.ThrowIfNull(node, nameof(node));
        ArgumentNullException.ThrowIfNull(newNode, nameof(node));
        var currentNode = _first;
        for (int i = 0; i < Count; i++)
        {
            if (currentNode.Next.Equals(node))
            {
                newNode.Next = node;
                currentNode.Next = newNode;
                break;
            }
            currentNode = currentNode.Next;
        }
        Count++;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        var node = new  MyNode<T>(value);
        var beforeRemove = Count;
        Remove(node);
        if (beforeRemove != Count - 1) return false;
        return true;
    }

    public void Remove(MyNode<T> node)
    {
        if (Count == 0) return;
        ArgumentNullException.ThrowIfNull(node, nameof(node));
        var currentNode = _first;
        for (int i = 0;  i < Count; i++)
        {
            if (i == 0)
            {
                if (currentNode.Equals(node))
                {
                    RemoveFirst();
                    return;
                }
            }
            if (currentNode.Next.Equals(node))
            {
                currentNode.Next = node.Next;
                break;
            }
            currentNode = currentNode.Next;
        }
        Count--;
    }

    public void RemoveFirst()
    {
        if (Count == 0) return;
        _first = _first.Next;
        Count--;
    }

    public void RemoveLast()
    {
        var currentNode = _first;
        for (int i = 0; i < Count; i++)
        {
            if (i == Count - 1)
            {
                currentNode.Next = null;
            }
            currentNode = currentNode.Next;
        }
    }

    public MyNode<T>? Find(T value)
    {
        if (_first == null) return null;
        var currentNode = _first;
        for (int i = 0; i < Count; i++)
        {
            if (currentNode.Value.Equals(value)) return currentNode;
            currentNode = currentNode.Next;
        }
        return null;
    }

    public MyNode<T>? FindLast(T value)
    {
        if (_first == null) return null;
        var currentNode = _first;
        MyNode<T> lastFoundNode = null;
        for (int i = 0; i < Count; i++)
        {
            if (currentNode.Value.Equals(value)) lastFoundNode = currentNode;
            currentNode = currentNode.Next;
        }
        return lastFoundNode;
    }

    void ICollection<T>.Add(T item)
    {
        AddLast(item);
    }

    public void Clear()
    {
        _first = null;
        Count = 0;
    }

    public bool Contains(T value)
    {
        if (Count == 0) return false;
        foreach (var nodeValue in this)
        {
            if (nodeValue.Equals(value)) return true;
        }
        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new MyLinkedListEnumerator<T>(_first!);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class MyLinkedListEnumerator<T> : IEnumerator<T>
{
    public MyLinkedListEnumerator(MyNode<T> first)
    {
        _first = first;
        _currentNode = _first;
    }
    
    private readonly MyNode<T>? _first;
    private MyNode<T>? _currentNode;
    private T? Current => _currentNode!.Value;

    public bool MoveNext()
    {
        if (_currentNode?.Next == null) return false;
        _currentNode = _currentNode.Next;
        return true;
    }

    public void Reset()
    {
        _currentNode = _first;
    }

    T IEnumerator<T>.Current => Current;

    object? IEnumerator.Current => Current;

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}