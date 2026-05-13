namespace Collections;

public class MyNode<T>
{
    public MyNode() { }

    public MyNode(T? value) : this() => Value = value;

    public MyNode(T? value, MyNode<T>? next) : this(value) => Next = next;

    public T? Value { get; set; }
    public MyNode<T>? Next { get; set; }

    public override string? ToString() => Value?.ToString();
}