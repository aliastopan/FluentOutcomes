namespace FluentOutcomes.Contracts;

public interface IFailure
{
    IReturn Otherwise();
    IOtherwise WithError(Error error);
    IOtherwise WithError(Action<Error> error);
}

public interface IFailure<T> : IFailure
{
    new IReturn<T> Otherwise();
    new IOtherwise<T> WithError(Error error);
    new IOtherwise<T> WithError(Action<Error> error);
}