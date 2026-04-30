using System.Collections;

namespace Collections
{
    class MyList<T> : MyCollection<T>, IList<T> where T : new()
    {
        public bool IsSynchronized { get; }
        public T SyncRoot { get; }

        public bool IsFixedSize { get; }
        public bool IsReadOnly { get; }
        public MyList()
        {
            Items = new T?[4];
            Count = 0;
            IsSynchronized = false;
            SyncRoot = new T();
            IsFixedSize = false;
            IsReadOnly = false;
        }
        
        public MyList(bool isSynchronized, bool isFixedSize, bool isReadOnly)
        {
            Items = new T?[4];
            Count = 0; 
            IsSynchronized = isSynchronized;
            SyncRoot = new T();
            IsFixedSize = isFixedSize;
            IsReadOnly = isReadOnly;
        }
        
        public int Add(T? value)
        {
            if (Count >= Items.Length) Resize();
            Items[Count] = value;
            Count++;
            return Count - 1;
        }

        public void Insert(int index, T? value)
        {
            _index_validation(index);
            if (Count + 1 >= ArraySize) Resize();
            for (int i = Count - 1; i >= index; i--)
            {
                Items[i + 1] = Items[i];
            }
            Items[index] = value;
            Count++;
        }

        public bool Remove(T value)
        {
            int shift = 0;
            bool removed = false;
            for (int i = 0; i < Count + shift; i++)
            {
                if (Items[i].Equals(value))
                {
                    shift++;
                    Count--;
                    Items[i] = Items[i + shift];
                    removed = true;
                }
            }
            if (Count <= ArraySize / 2) Resize(false);
            return removed;
        }

        public void RemoveAt(int index)
        {
            _index_validation(index);
            if (Count <= ArraySize / 2) Resize(false);
            for (int i = index; i < Count; i++)
            {
                Items[i] = Items[i + 1];
            }
            Count--;
        }

        public int IndexOf(T? value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Items[i].Equals(value)) return i;
            }
            return -1;
        }

        public int IndexOf(T? value, int startIndex)
        {
            _index_validation(startIndex);
            for (int i = startIndex; i < Count; i++)
            {
                if (Items[i].Equals(value)) return i;
            }
            return -1;
        }

        // public override IEnumerator GetEnumerator()
        // {
        //     return new  MyListEnumerator(Items, Count);
        // }

        public T? this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                return Items[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                Items[index] = value;
            }
        }
    }
    
    class MyListEnumerator : IEnumerator
    {
        public object? Current => _items[_index];
        private readonly object?[] _items;
        private readonly int _count;
        private int _index = -1;

        public MyListEnumerator(object?[] items, int count)
        {
            _items = items;
            _count = count;
        }
        
        public bool MoveNext()
        {
            if (_index + 1 < _count)
            {
                _index++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _index = -1;
        }
    }
}