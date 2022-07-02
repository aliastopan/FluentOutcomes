namespace FluentOutcomes.Contracts;

public interface IReturn
{
    IOutcome Return();
}

public interface IReturn<TValue> : IReturn
{
    IOutcome<TValue> Return(TValue value);
}