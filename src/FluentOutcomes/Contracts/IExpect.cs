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
    new ISuccess<TValue> SuccessIf(bool expectation);
    new IFailure<TValue> FailureIf(bool expectation);
}