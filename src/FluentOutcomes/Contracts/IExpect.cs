namespace FluentOutcomes.Contracts;

public interface IExpect
{
    IOutcome Success();
    ISuccess SuccessIf(bool expectation);
    ISuccess SuccessIfNot(bool expectation);
    IOutcome Failure(Error error);
    IOutcome Failure(Action<Error> error);
    IFailure FailureIf(bool expectation);
    IFailure FailureIfNot(bool expectation);
}

public interface IExpect<T>
{
    IOutcome<T> Success(T value);
    ISuccess<T> SuccessIf(bool expectation);
    ISuccess<T> SuccessIfNot(bool expectation);
    IOutcome<T> Failure(T value);
    IOutcome<T> Failure(T value, Error error);
    IOutcome<T> Failure(T value, Action<Error> error);
    IFailure<T> FailureIf(bool expectation);
    IFailure<T> FailureIfNot(bool expectation);
}