using FluentOutcomes.Contracts;

namespace FluentOutcomes;

public class Outcome :
    IOutcome,
    IExpect,
    ISuccess,
    IFailure,
    IOtherwise,
    IReturn
{
    public bool IsSuccess { get; protected set; }
    public bool IsFailure => !IsSuccess;
    public Error? Error { get; protected set; }
    public string Verdict => Error is null ? "Ok" : Error.Exception.Message;

    protected Outcome()
    {

    }

    public static IExpect Expect()
    {
        return new Outcome();
    }

    public static IExpect<TValue> Expect<TValue>()
    {
        return new Outcome<TValue>();
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
        this.IsSuccess = expectation;
        return this;
    }

    public IReturn Otherwise()
    {
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
}

internal class Outcome<TValue> : Outcome,
    IOutcome<TValue>,
    IExpect<TValue> ,
    ISuccess<TValue>,
    IFailure<TValue>,
    IOtherwise<TValue>,
    IReturn<TValue>
{
    public TValue Value { get; private set; } = default!;

    protected internal Outcome()
    {

    }

    public IOutcome<TValue> Success(TValue value)
    {
        this.IsSuccess = true;
        this.Value = value;
        return this;
    }

    public IOutcome<TValue> Failure(TValue value, Error error)
    {
        this.IsSuccess = false;
        this.Value = value;
        this.Error = error;
        return this;
    }

    public IOutcome<TValue> Failure(TValue value, Action<Error> error)
    {
        Error err = new();
        error?.Invoke(err);

        this.IsSuccess = false;
        this.Value = value;
        this.Error = err;
        return this;
    }

    public new ISuccess<TValue> SuccessIf(bool expectation)
    {
        this.IsSuccess = expectation;
        return this;
    }

    public new IFailure<TValue> FailureIf(bool expectation)
    {
        this.IsSuccess = !expectation;
        return this;
    }

    public new IReturn<TValue> Otherwise()
    {
        this.Error = new();
        return this;
    }

    public new IReturn<TValue> Otherwise(Error error)
    {
        this.Error = error;
        return this;
    }

    public new IReturn<TValue> Otherwise(Action<Error> error)
    {
        Error err = new();
        error?.Invoke(err);

        this.Error = err;
        return this;
    }

    public new IOtherwise<TValue> WithError(Error error)
    {
        this.Error = error;
        return this;
    }

    public new IOtherwise<TValue> WithError(Action<Error> error)
    {
        Error err = new();
        error?.Invoke(err);

        this.Error = err;
        return this;
    }

    public IOutcome<TValue> Return(TValue value)
    {
        this.Value = value;
        return this;
    }
}