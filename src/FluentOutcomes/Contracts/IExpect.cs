namespace FluentOutcomes.Contracts;

public interface IExpect
{
    IOutcome Success();
    IOutcome Failure(Error error);
    IOutcome Failure(Action<Error> error);

    ISuccess SuccessIf(bool expectation);
    ISuccess SuccessIfNot(bool expectation);
    IFailure FailureIf(bool expectation);
    IFailure FailureIfNot(bool expectation);
}

public interface IExpect<T> : IExpect
{
    IOutcome<T> Success(T value);
    IOutcome<T> Failure(T value, Error error);
    IOutcome<T> Failure(T value, Action<Error> error);

    new ISuccess<T> SuccessIf(bool expectation);
    new ISuccess<T> SuccessIfNot(bool expectation);
    new IFailure<T> FailureIf(bool expectation);
    new IFailure<T> FailureIfNot(bool expectation);
}