namespace Collections;

class MyCollection
{
    protected object?[] Items = new object?[1];
    protected int ArraySize => Items.Length;
    public int Count {get; protected set;}
}