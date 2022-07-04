namespace FluentOutcomes.Contracts;

public interface IReturn
{
    IOutcome Return();
}

public interface IReturn<T> : IReturn
{
    IOutcome<T> Return(T value);
}