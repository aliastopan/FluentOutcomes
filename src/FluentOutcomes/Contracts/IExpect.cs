namespace FluentOutcomes.Contracts;

public interface IExpect
{
    ISuccess SuccessIf(bool expectation);
    ISuccess SuccessIfNot(bool expectation);
    IFailure FailureIf(bool expectation);
    IFailure FailureIfNot(bool expectation);
}

public interface IExpect<T>
{
    ISuccess<T> SuccessIf(bool expectation);
    ISuccess<T> SuccessIfNot(bool expectation);
    IFailure<T> FailureIf(bool expectation);
    IFailure<T> FailureIfNot(bool expectation);
}