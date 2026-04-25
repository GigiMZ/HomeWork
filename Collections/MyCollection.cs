namespace Collections;

class MyCollection
{
    protected object?[] Objects = new object?[1];
    protected int ArraySize => Objects.Length;
    public int Count {get; protected set;}
}