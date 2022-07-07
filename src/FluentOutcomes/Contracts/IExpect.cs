using System;

namespace FluentOutcomes.Contracts
{
    public interface IExpect
    {
        ISuccess SuccessIf(bool condition);
        ISuccess SuccessIf(Func<bool> evaluate);
        ISuccess SuccessIfNot(bool condition);
        ISuccess SuccessIfNot(Func<bool> evaluate);
        IFailure FailureIf(bool condition);
        IFailure FailureIf(Func<bool> condition);
        IFailure FailureIfNot(bool condition);
        IFailure FailureIfNot(Func<bool> condition);
    }

    public interface IExpect<T>
    {
        ISuccess<T> SuccessIf(bool condition);
        ISuccess<T> SuccessIf(Func<bool> evaluate);
        ISuccess<T> SuccessIfNot(bool condition);
        ISuccess<T> SuccessIfNot(Func<bool> evaluate);
        IFailure<T> FailureIf(bool condition);
        IFailure<T> FailureIf(Func<bool> evaluate);
        IFailure<T> FailureIfNot(bool condition);
        IFailure<T> FailureIfNot(Func<bool> evaluate);
    }
}