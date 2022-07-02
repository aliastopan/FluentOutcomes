namespace FluentOutcomes.Contracts;

public interface IFailure
{
    IReturn WithError(Error error);
    IReturn WithError(Action<Error> error);
}

public interface IFailure<TValue> : IFailure
{
    new IReturn<TValue> WithError(Error error);
    new IReturn<TValue> WithError(Action<Error> error);
}