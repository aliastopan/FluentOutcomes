namespace FluentOutcomes.Contracts;

public interface IExpect
{
    ISuccess SuccessIf(bool condition);
    ISuccess SuccessIfNot(bool condition);
    IFailure FailureIf(bool condition);
    IFailure FailureIfNot(bool condition);
}

public interface IExpect<T>
{
    ISuccess<T> SuccessIf(bool condition);
    ISuccess<T> SuccessIfNot(bool condition);
    IFailure<T> FailureIf(bool condition);
    IFailure<T> FailureIfNot(bool condition);
}