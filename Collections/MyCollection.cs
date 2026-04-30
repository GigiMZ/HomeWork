using System.Collections;

namespace Collections;

abstract class MyCollection<T> : ICollection<T>//, IEnumerable<T>
{
    public int Count {get; protected set;}
    public bool IsReadOnly { get; }
    protected T?[] Items = new T?[1];
    protected int ArraySize => Items.Length;

    void ICollection<T>.Add(T item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        Items = new T?[1];
        Count = 0;
    }

    public bool Contains(T item)
    {
        foreach (var item1 in Items)
        {
            if (item.Equals(item1)) return true;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        for (int i = 0; i < Count; i++)
        {
            array.SetValue(Items[i], arrayIndex + i);
        }
    }

    bool ICollection<T>.Remove(T item)
    {
        throw new NotImplementedException();
    }
    
    protected void Resize(bool increase = true)
    {
        T?[] newItems;
        if (increase) 
            newItems = new T?[ArraySize * 2];
        else 
            newItems = new T?[(int)MathF.Round(ArraySize / 2)];
            
        for (int i = 0; i < Count; i++)
        {
            newItems[i] = Items[i];
        }
        Items = newItems;
    }
    
    protected void _index_validation(int index)
    {
        if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}