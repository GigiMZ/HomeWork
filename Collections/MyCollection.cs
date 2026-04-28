using System.Collections;

namespace Collections;

abstract class MyCollection : IEnumerable
{
    protected object?[] Items = new object?[1];
    protected int ArraySize => Items.Length;
    public int Count {get; protected set;}
    public abstract IEnumerator GetEnumerator();

}