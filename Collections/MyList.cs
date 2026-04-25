using System.Collections;

namespace Collections
{
    class MyList : MyCollection, IList
    {
        public MyList()
        {
            Items = new object?[4];
            Count = 0;
            IsSynchronized = false;
            SyncRoot = new object();
            IsFixedSize = false;
            IsReadOnly = false;
        }
        
        public MyList(bool isSynchronized, bool isFixedSize, bool isReadOnly)
        {
            Items = new object?[4];
            Count = 0; 
            IsSynchronized = isSynchronized;
            SyncRoot = new object();
            IsFixedSize = isFixedSize;
            IsReadOnly = isReadOnly;
        }
        
        public int Add(object? value)
        {
            if (Count >= Items.Length) Resize();
            Items[Count] = value;
            Count++;
            return Count - 1; // Mas aq ra unda davabruno ar maxsovs
        }

        public void Insert(int index, object? value)
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

        public void Remove(object? value)
        {
            int shift = 0;
            for (int i = 0; i < Count + shift; i++)
            {
                if (Items[i] == value)
                {
                    shift++;
                    Count--;
                    Items[i] = Items[i + shift];
                }
            }
            if (Count <= ArraySize / 2) Resize(false);
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

        public void Clear()
        {
            Count = 0;
            Items = new object?[4];
        }

        public bool Contains(object? value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Items[i] == value) return true;
            }

            return false;
        }

        public int IndexOf(object? value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Items[i] == value) return i;
            }
            return -1;
        }

        public int IndexOf(object? value, int startIndex)
        {
            _index_validation(startIndex);
            for (int i = startIndex; i < Count; i++)
            {
                if (Items[i] == value) return i;
            }
            return -1;
        }

        public void CopyTo(Array array, int index)
        {
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(Items[i], index + i);
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public object? this[int index]
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

        public bool IsSynchronized { get; }
        public object SyncRoot { get; }

        public bool IsFixedSize { get; }
        public bool IsReadOnly { get; }
        
        private void Resize(bool increase = true)
        {
            object?[] newItems;
            if (increase) 
                newItems = new object?[ArraySize * 2];
            else 
                newItems = new object?[(int)MathF.Round(ArraySize / 2)];
            
            for (int i = 0; i < Count; i++)
            {
                newItems[i] = Items[i];
            }
            Items = newItems;
        }

        private void _index_validation(int index)
        {
            if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));
        }
    }
}