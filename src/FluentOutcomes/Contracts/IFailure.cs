namespace FluentOutcomes.Contracts;

public interface IFailure
{
    IOtherwise WithError(Error error);
    IOtherwise WithError(Action<Error> error);
}

public interface IFailure<TValue> : IFailure
{
    new IOtherwise<TValue> WithError(Error error);
    new IOtherwise<TValue> WithError(Action<Error> error);
}