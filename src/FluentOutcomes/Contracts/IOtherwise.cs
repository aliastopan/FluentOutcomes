namespace FluentOutcomes.Contracts;

public interface IOtherwise
{
    IReturn Otherwise();
}

public interface IOtherwise<TValue>
{
    IReturn<TValue> Otherwise();
}

