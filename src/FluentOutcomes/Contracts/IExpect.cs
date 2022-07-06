namespace FluentOutcomes.Contracts;

public interface IExpect
{
    ISuccess SuccessIf(bool condition);
    ISuccess SuccessIfNot(bool condition);
    ISuccess SuccessIf(Func<bool> condition);
    ISuccess SuccessIfNot(Func<bool> condition);
    IFailure FailureIf(bool condition);
    IFailure FailureIfNot(bool condition);
    IFailure FailureIf(Func<bool> condition);
    IFailure FailureIfNot(Func<bool> condition);
}

public interface IExpect<T>
{
    ISuccess<T> SuccessIf(bool condition);
    ISuccess<T> SuccessIfNot(bool condition);
    ISuccess<T> SuccessIf(Func<bool> condition);
    ISuccess<T> SuccessIfNot(Func<bool> condition);
    IFailure<T> FailureIf(bool condition);
    IFailure<T> FailureIfNot(bool condition);
    IFailure<T> FailureIf(Func<bool> condition);
    IFailure<T> FailureIfNot(Func<bool> condition);
}