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

    public static IOutcome OK()
    {
        return new Outcome(){
            IsSuccess = true
        };
    }

    public static IOutcome<T> OK<T>(T value)
    {
        return new Outcome<T>(){
            IsSuccess = true,
            Value = value
        };
    }

    public static IOutcome Fail()
    {
        return new Outcome(){
            IsSuccess = false,
            Error = new Error()
        };
    }

    public static IOutcome Fail(Error error)
    {
        return new Outcome(){
            IsSuccess = false,
            Error = error
        };
    }

    public static IOutcome Fail(Action<Error> error)
    {
        Error err = new();
        error?.Invoke(err);

        return new Outcome(){
            IsSuccess = false,
            Error = err
        };
    }

    public static IOutcome<T> Fail<T>(T value)
    {
        return new Outcome<T>(){
            IsSuccess = false,
            Value = value,
            Error = new Error()
        };
    }

    public static IOutcome<T> Fail<T>(T value, Error error)
    {
        return new Outcome<T>(){
            IsSuccess = false,
            Value = value,
            Error = error
        };
    }

    public static IOutcome<T> Fail<T>(T value, Action<Error> error)
    {
        Error err = new();
        error?.Invoke(err);

        return new Outcome<T>(){
            IsSuccess = false,
            Value = value,
            Error = err
        };
    }

    public static IExpect Expect()
    {
        return new Outcome();
    }

    public static IExpect<T> Expect<T>()
    {
        return new Outcome<T>();
    }

    public ISuccess SuccessIf(bool expectation)
    {
        IsSuccess = expectation;
        return this;
    }

    public ISuccess SuccessIfNot(bool expectation)
    {
        IsSuccess = !expectation;
        return this;
    }

    public IFailure FailureIf(bool expectation)
    {
        IsSuccess = !expectation;
        return this;
    }

    public IFailure FailureIfNot(bool expectation)
    {
        IsSuccess = expectation;
        return this;
    }

    public IReturn Otherwise()
    {
        if(IsSuccess)
            return this;

        Error = new();
        return this;
    }

    public IReturn Otherwise(Error error)
    {
        Error = error;
        return this;
    }

    public IReturn Otherwise(Action<Error> error)
    {
        Error err = new();
        error?.Invoke(err);

        Error = err;
        return this;
    }

    public IOtherwise WithError(Error error)
    {
        Error = error;
        return this;
    }

    public IOtherwise WithError(Action<Error> error)
    {
        Error err = new();
        error?.Invoke(err);

        Error = err;
        return this;
    }

    public IOutcome Return()
    {
        return this;
    }

    ISuccess ILogic<ISuccess>.Or(bool expectation)
    {
        IsSuccess = IsSuccess || expectation;
        return this;
    }

    ISuccess ILogic<ISuccess>.And(bool expectation)
    {
        IsSuccess = IsSuccess && expectation;
        return this;
    }

    ISuccess ILogic<ISuccess>.OrNot(bool expectation)
    {
        IsSuccess = IsSuccess || !expectation;
        return this;
    }

    ISuccess ILogic<ISuccess>.AndNot(bool expectation)
    {
        IsSuccess = IsSuccess && !expectation;
        return this;
    }

    IFailure ILogic<IFailure>.Or(bool expectation)
    {
        IsSuccess = !(IsFailure || expectation);
        return this;
    }

    IFailure ILogic<IFailure>.And(bool expectation)
    {
        IsSuccess = !(IsFailure && expectation);
        return this;
    }

    IFailure ILogic<IFailure>.OrNot(bool expectation)
    {
        IsSuccess = !(IsFailure || !expectation);
        return this;
    }

    IFailure ILogic<IFailure>.AndNot(bool expectation)
    {
        IsSuccess = !(IsFailure && !expectation);
        return this;
    }
}

internal class Outcome<T> : Outcome, IOutcome<T>, IExpect<T>, ISuccess<T>, IFailure<T>, IOtherwise<T>, IReturn<T>
{
    public T Value { get; set; } = default!;

    protected internal Outcome()
        : base()
    {

    }

    public new ISuccess<T> SuccessIf(bool expectation)
    {
        IsSuccess = expectation;
        return this;
    }

    public new ISuccess<T> SuccessIfNot(bool expectation)
    {
        IsSuccess = !expectation;
        return this;
    }

    public new IFailure<T> FailureIf(bool expectation)
    {
        IsSuccess = !expectation;
        return this;
    }

    public new IFailure<T> FailureIfNot(bool expectation)
    {
        IsSuccess = expectation;
        return this;
    }

    public new IReturn<T> Otherwise()
    {
        if(IsSuccess)
            return this;

        Error = new();
        return this;
    }

    public new IReturn<T> Otherwise(Error error)
    {
        Error = new();
        return this;
    }

    public new IReturn<T> Otherwise(Action<Error> error)
    {
        Error err = new();
        error?.Invoke(err);

        Error = err;
        return this;
    }

    public new IOtherwise<T> WithError(Error error)
    {
        if(IsSuccess)
            return this;

        Error = new();
        return this;
    }

    public new IOtherwise<T> WithError(Action<Error> error)
    {
        if(IsSuccess)
            return this;

        Error err = new();
        error?.Invoke(err);

        Error = err;
        return this;
    }

    public IOutcome<T> Return(T value)
    {
        Value = value;
        return this;
    }

    ISuccess<T> ILogic<ISuccess<T>>.Or(bool expectation)
    {
        IsSuccess = IsSuccess || expectation;
        return this;
    }

    ISuccess<T> ILogic<ISuccess<T>>.And(bool expectation)
    {
        IsSuccess = IsSuccess && expectation;
        return this;
    }

    ISuccess<T> ILogic<ISuccess<T>>.OrNot(bool expectation)
    {
        IsSuccess = IsSuccess || !expectation;
        return this;
    }

    ISuccess<T> ILogic<ISuccess<T>>.AndNot(bool expectation)
    {
        IsSuccess = IsSuccess && !expectation;
        return this;
    }

    IFailure<T> ILogic<IFailure<T>>.Or(bool expectation)
    {
        IsSuccess = !(IsFailure || expectation);
        return this;
    }

    IFailure<T> ILogic<IFailure<T>>.And(bool expectation)
    {
        IsSuccess = !(IsFailure && expectation);
        return this;
    }

    IFailure<T> ILogic<IFailure<T>>.OrNot(bool expectation)
    {
        IsSuccess = !(IsFailure || !expectation);
        return this;
    }

    IFailure<T> ILogic<IFailure<T>>.AndNot(bool expectation)
    {
        IsSuccess = !(IsFailure && !expectation);
        return this;
    }
}