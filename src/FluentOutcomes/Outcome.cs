using FluentOutcomes.Contracts;

namespace FluentOutcomes;

public class Outcome : IOutcome, IExpect, ISuccess, IFailure, IOtherwise, IReturn
{
    public bool IsSuccess { get; protected set; }
    public bool IsFailure => !IsSuccess;
    public Error? Error { get; protected set; }
    public string Verdict => Error is null ? "OK" : Error.Exception.Message;

    protected Outcome()
    {

    }

    public static IExpect Expect()
    {
        return new Outcome();
    }

    public static IExpect<T> Expect<T>()
    {
        return new Outcome<T>();
    }

    public IOutcome Success()
    {
        this.IsSuccess = true;
        return this;
    }

    public IOutcome Failure(Error error)
    {
        this.IsSuccess = false;
        this.Error = error;
        return this;
    }

    public IOutcome Failure(Action<Error> error)
    {
        this.IsSuccess = false;
        Error err = new();
        error?.Invoke(err);
        this.Error = err;

        return this;
    }

    public ISuccess SuccessIf(bool expectation)
    {
        this.IsSuccess = expectation;
        return this;
    }

    public IFailure FailureIf(bool expectation)
    {
        this.IsSuccess = !expectation;
        return this;
    }

    public IReturn Otherwise()
    {
        if(IsSuccess)
            return this;

        this.Error = new();
        return this;
    }

    public IReturn Otherwise(Error error)
    {
        this.Error = error;
        return this;
    }

    public IReturn Otherwise(Action<Error> error)
    {
        Error err = new();
        error?.Invoke(err);

        this.Error = err;
        return this;
    }

    public IOtherwise WithError(Error error)
    {
        this.Error = error;
        return this;
    }

    public IOtherwise WithError(Action<Error> error)
    {
        Error err = new();
        error?.Invoke(err);
        this.Error = err;

        return this;
    }

    public IOutcome Return()
    {
        return this;
    }

    ISuccess ILogic<ISuccess>.Or(bool condition)
    {
        this.IsSuccess = IsSuccess || condition;
        return this;
    }

    ISuccess ILogic<ISuccess>.And(bool condition)
    {
        this.IsSuccess = IsSuccess && condition;
        return this;
    }

    IFailure ILogic<IFailure>.Or(bool condition)
    {
        this.IsSuccess = !(IsFailure || condition);
        return this;
    }

    IFailure ILogic<IFailure>.And(bool condition)
    {
        this.IsSuccess = !(IsFailure || condition);
        return this;
    }
}

internal class Outcome<T> : Outcome, IOutcome<T>, IExpect<T>, ISuccess<T>, IFailure<T>, IOtherwise<T>, IReturn<T>
{
    public T Value { get; private set; } = default!;

    protected internal Outcome()
    {

    }

    public IOutcome<T> Success(T value)
    {
        this.IsSuccess = true;
        this.Value = value;
        return this;
    }

    public IOutcome<T> Failure(T value, Error error)
    {
        this.IsSuccess = false;
        this.Value = value;
        this.Error = error;
        return this;
    }

    public IOutcome<T> Failure(T value, Action<Error> error)
    {
        Error err = new();
        error?.Invoke(err);

        this.IsSuccess = false;
        this.Value = value;
        this.Error = err;
        return this;
    }

    public new ISuccess<T> SuccessIf(bool expectation)
    {
        this.IsSuccess = expectation;
        return this;
    }

    public new IFailure<T> FailureIf(bool expectation)
    {
        this.IsSuccess = !expectation;
        return this;
    }

    public new IReturn<T> Otherwise()
    {
        if(IsSuccess)
            return this;

        this.Error = new();
        return this;
    }

    public new IReturn<T> Otherwise(Error error)
    {
        this.Error = new();
        return this;
    }

    public new IReturn<T> Otherwise(Action<Error> error)
    {
        Error err = new();
        error?.Invoke(err);

        this.Error = err;
        return this;
    }

    public new IOtherwise<T> WithError(Error error)
    {
        if(IsSuccess)
            return this;

        this.Error = new();
        return this;
    }

    public new IOtherwise<T> WithError(Action<Error> error)
    {
        if(IsSuccess)
            return this;

        Error err = new();
        error?.Invoke(err);
        this.Error = err;

        return this;
    }

    public IOutcome<T> Return(T value)
    {
        this.Value = value;
        return this;
    }

    ISuccess<T> ILogic<ISuccess<T>>.Or(bool condition)
    {
        this.IsSuccess = IsSuccess || condition;
        return this;
    }

    ISuccess<T> ILogic<ISuccess<T>>.And(bool condition)
    {
        this.IsSuccess = IsSuccess && condition;
        return this;
    }

    IFailure<T> ILogic<IFailure<T>>.Or(bool condition)
    {
        this.IsSuccess = !(IsFailure || condition);
        return this;
    }

    IFailure<T> ILogic<IFailure<T>>.And(bool condition)
    {
        this.IsSuccess = !(IsFailure && condition);
        return this;
    }
}