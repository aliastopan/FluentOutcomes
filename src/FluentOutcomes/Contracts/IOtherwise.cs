namespace FluentOutcomes.Contracts;

public interface IOtherwise
{
    IReturn Otherwise();
}

public interface IOtherwise<T>
{
    IReturn<T> Otherwise();
}

