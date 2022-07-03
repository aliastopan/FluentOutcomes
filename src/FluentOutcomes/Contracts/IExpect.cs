namespace FluentOutcomes.Contracts;

public interface IExpect
{
    IOutcome Success();
    IOutcome Failure(Error error);
    IOutcome Failure(Action<Error> error);

    ISuccess SuccessIf(bool expectation);
    IFailure FailureIf(bool expectation);
}

public interface IExpect<TValue> : IExpect
{
    IOutcome<TValue> Success(TValue value);
    IOutcome<TValue> Failure(TValue value, Error error);
    IOutcome<TValue> Failure(TValue value, Action<Error> error);

    new ISuccess<TValue> SuccessIf(bool expectation);
    new IFailure<TValue> FailureIf(bool expectation);
}