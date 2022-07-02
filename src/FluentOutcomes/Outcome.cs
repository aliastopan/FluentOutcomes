namespace FluentOutcomes;

public class Outcome :
    IOutcome,
    IExpect,
    ISuccess,
    IFailure,
    IReturn
{
    public bool Success { get; protected set; }
    public bool Failure => !Success;
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

    public ISuccess SuccessIf(bool expectation)
    {
        this.Success = expectation;
        return this;
    }

    public IFailure FailureIf(bool expectation)
    {
        this.Success = expectation;
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

    public IReturn WithError(Error error)
    {
        this.Error = error;
        return this;
    }

    public IReturn WithError(Action<Error> error)
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
    IReturn<TValue>
{
    public TValue Value { get; private set; } = default!;

    protected internal Outcome()
    {

    }

    public new ISuccess<TValue> SuccessIf(bool expectation)
    {
        this.Success = expectation;
        return this;
    }

    public new IFailure<TValue> FailureIf(bool expectation)
    {
        this.Success = expectation;
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

    public new IReturn<TValue> WithError(Error error)
    {
        this.Error = error;
        return this;
    }

    IReturn<TValue> IFailure<TValue>.WithError(Action<Error> error)
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