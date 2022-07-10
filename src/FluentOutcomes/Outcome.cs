using System;
using FluentOutcomes.Contracts;
using FluentOutcomes.Metadata;

namespace FluentOutcomes
{
    public class Outcome : IOutcome, IExpect, ISuccess, IFailure, IOtherwise, IReturn
    {
        public bool IsSuccess { get; protected set; }
        public bool IsFailure => !IsSuccess;
        public ResultTrace ResultTrace { get; protected set; }

        // public Error? Error { get; protected set; }
        // public string Verdict => Error is null ? "OK" : Error.Exception.Message;

        protected Outcome()
        {
            ResultTrace = new ResultTrace();
        }

        public static IOutcome Ok()
        {
            var result = new Outcome();
            result.IsSuccess = true;
            return result;
        }

        public static IOutcome<T> Ok<T>(T value)
        {
            var result = new Outcome<T>();
            result.IsSuccess = true;
            result.Value = value;
            return result;
        }

        public static IOutcome Fail()
        {
            var result = new Outcome();
            result.IsSuccess = false;
            result.ResultTrace.Error = new Error();
            return result;
        }

        public static IOutcome Fail(Error error)
        {
            var result = new Outcome();
            result.IsSuccess = false;
            result.ResultTrace.Error = error;
            return result;
        }

        public static IOutcome Fail(Action<Error> error)
        {
            Error err = new Error();
            error?.Invoke(err);

            var result = new Outcome();
            result.IsSuccess = false;
            result.ResultTrace.Error = err;
            return result;
        }

        public static IOutcome<T> Fail<T>()
        {
            var result = new Outcome<T>();
            result.IsSuccess = false;
            result.Value = default!;
            result.ResultTrace.Error = new Error();
            return result;
        }

        public static IOutcome<T> Fail<T>(T value, bool overwrite = false)
        {
            var result = new Outcome<T>();
            result.IsSuccess = false;
            result.Value = overwrite ? value : default!;
            result.ResultTrace.Error = new Error();
            return result;
        }

        public static IOutcome<T> Fail<T>(T value, Error error, bool overwrite = false)
        {
            var result = new Outcome<T>();
            result.IsSuccess = false;
            result.Value = overwrite ? value : default!;
            result.ResultTrace.Error = error;
            return result;
        }

        public static IOutcome<T> Fail<T>(T value, Action<Error> error, bool overwrite = false)
        {
            Error err = new Error();
            error?.Invoke(err);

            var result = new Outcome<T>();
            result.IsSuccess = false;
            result.Value = overwrite ? value : default!;
            result.ResultTrace.Error = err;
            return result;
        }

        public static IExpect Expect()
        {
            return new Outcome();
        }

        public static IExpect<T> Expect<T>()
        {
            return new Outcome<T>();
        }

        public ISuccess SuccessIf(bool condition)
        {
            IsSuccess = condition;
            return this;
        }

        public ISuccess SuccessIf(Func<bool> evaluate)
        {
            IsSuccess = evaluate.Invoke();
            return this;
        }

        public ISuccess SuccessIfNot(bool condition)
        {
            IsSuccess = !condition;
            return this;
        }

        public ISuccess SuccessIfNot(Func<bool> evaluate)
        {
            IsSuccess = !evaluate.Invoke();
            return this;
        }

        public IFailure FailureIf(bool condition)
        {
            IsSuccess = !condition;
            return this;
        }

        public IFailure FailureIf(Func<bool> evaluate)
        {
            IsSuccess = !evaluate.Invoke();
            return this;
        }

        public IFailure FailureIfNot(bool condition)
        {
            IsSuccess = condition;
            return this;
        }

        public IFailure FailureIfNot(Func<bool> evaluate)
        {
            IsSuccess = evaluate.Invoke();
            return this;
        }

        public IReturn Otherwise()
        {
            if(IsSuccess)
            {
                return this;
            }

            ResultTrace.Error = new Error();
            return this;
        }

        public IReturn Otherwise(Error error)
        {
            ResultTrace.Error = error;
            return this;
        }

        public IReturn Otherwise(Action<Error> error)
        {
            Error err = new Error();
            error?.Invoke(err);

            ResultTrace.Error = err;
            return this;
        }

        public IOtherwise WithError(Error error)
        {
            ResultTrace.Error = error;
            return this;
        }

        public IOtherwise WithError(Action<Error> error)
        {
            Error err = new Error();
            error?.Invoke(err);

            ResultTrace.Error = err;
            return this;
        }

        public IOutcome Return()
        {
            return this;
        }

        ISuccess ILogic<ISuccess>.And(bool condition)
        {
            IsSuccess = IsSuccess && condition;
            return this;
        }

        ISuccess ILogic<ISuccess>.And(Func<bool> evaluate)
        {
            IsSuccess = IsSuccess && evaluate.Invoke();
            return this;
        }

        ISuccess ILogic<ISuccess>.AndNot(bool condition)
        {
            IsSuccess = IsSuccess && !condition;
            return this;
        }

        ISuccess ILogic<ISuccess>.AndNot(Func<bool> evaluate)
        {
            IsSuccess = IsSuccess && !evaluate.Invoke();
            return this;
        }

        ISuccess ILogic<ISuccess>.Or(bool condition)
        {
            IsSuccess = IsSuccess || condition;
            return this;
        }

        ISuccess ILogic<ISuccess>.Or(Func<bool> evaluate)
        {
            IsSuccess = IsSuccess || evaluate.Invoke();
            return this;
        }

        ISuccess ILogic<ISuccess>.OrNot(bool condition)
        {
            IsSuccess = IsSuccess || !condition;
            return this;
        }

        ISuccess ILogic<ISuccess>.OrNot(Func<bool> evaluate)
        {
            IsSuccess = IsSuccess || !evaluate.Invoke();
            return this;
        }

        IFailure ILogic<IFailure>.And(bool condition)
        {
            IsSuccess = !(IsFailure && condition);
            return this;
        }

        IFailure ILogic<IFailure>.And(Func<bool> evaluate)
        {
            IsSuccess = !(IsFailure && evaluate.Invoke());
            return this;
        }

        IFailure ILogic<IFailure>.AndNot(bool condition)
        {
            IsSuccess = !(IsFailure && !condition);
            return this;
        }

        IFailure ILogic<IFailure>.AndNot(Func<bool> evaluate)
        {
            IsSuccess = !(IsFailure && !evaluate.Invoke());
            return this;
        }

        IFailure ILogic<IFailure>.Or(bool condition)
        {
            IsSuccess = !(IsFailure || condition);
            return this;
        }

        IFailure ILogic<IFailure>.Or(Func<bool> evaluate)
        {
            IsSuccess = !(IsFailure || evaluate.Invoke());
            return this;
        }

        IFailure ILogic<IFailure>.OrNot(bool condition)
        {
            IsSuccess = !(IsFailure || !condition);
            return this;
        }

        IFailure ILogic<IFailure>.OrNot(Func<bool> evaluate)
        {
            IsSuccess = !(IsFailure || !evaluate.Invoke());
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

        public new ISuccess<T> SuccessIf(bool condition)
        {
            IsSuccess = condition;
            return this;
        }

        public new ISuccess<T> SuccessIf(Func<bool> evaluate)
        {
            IsSuccess = evaluate.Invoke();
            return this;
        }

        public new ISuccess<T> SuccessIfNot(Func<bool> evaluate)
        {
            IsSuccess = !evaluate.Invoke();
            return this;
        }

        public new ISuccess<T> SuccessIfNot(bool condition)
        {
            IsSuccess = !condition;
            return this;
        }

        public new IFailure<T> FailureIf(bool condition)
        {
            IsSuccess = !condition;
            return this;
        }

        public new IFailure<T> FailureIf(Func<bool> evaluate)
        {
            IsSuccess = !evaluate.Invoke();
            return this;
        }

        public new IFailure<T> FailureIfNot(bool condition)
        {
            IsSuccess = condition;
            return this;
        }

        public new IFailure<T> FailureIfNot(Func<bool> evaluate)
        {
            IsSuccess = evaluate.Invoke();
            return this;
        }

        public new IReturn<T> Otherwise()
        {
            if(IsSuccess)
            {
                return this;
            }

            ResultTrace.Error = new Error();
            return this;
        }

        public new IReturn<T> Otherwise(Error error)
        {
            ResultTrace.Error = new Error();
            return this;
        }

        public new IReturn<T> Otherwise(Action<Error> error)
        {
            Error err = new Error();
            error?.Invoke(err);

            ResultTrace.Error = err;
            return this;
        }

        public new IOtherwise<T> WithError(Error error)
        {
            if(IsSuccess)
            {
                return this;
            }

            ResultTrace.Error = new Error();
            return this;
        }

        public new IOtherwise<T> WithError(Action<Error> error)
        {
            if(IsSuccess)
            {
                return this;
            }

            Error err = new Error();
            error?.Invoke(err);

            ResultTrace.Error = err;
            return this;
        }

        public IOutcome<T> Return(T value, bool overwrite = false)
        {
            if(overwrite)
            {
                Value = value;
                return this;
            }

            Value = IsSuccess ? value : default!;
            return this;
        }

        public IOutcome<T> Return(Func<T> value, bool overwrite = false)
        {
            if(overwrite)
            {
                Value = value.Invoke();
                return this;
            }

            Value = IsSuccess ? value.Invoke() : default!;
            return this;
        }

        ISuccess<T> ILogic<ISuccess<T>>.And(bool condition)
        {
            IsSuccess = IsSuccess && condition;
            return this;
        }

        ISuccess<T> ILogic<ISuccess<T>>.And(Func<bool> evaluate)
        {
            IsSuccess = IsSuccess && evaluate.Invoke();
            return this;
        }

        ISuccess<T> ILogic<ISuccess<T>>.AndNot(bool condition)
        {
            IsSuccess = IsSuccess && !condition;
            return this;
        }

        ISuccess<T> ILogic<ISuccess<T>>.AndNot(Func<bool> evaluate)
        {
            IsSuccess = IsSuccess && !evaluate.Invoke();
            return this;
        }

        ISuccess<T> ILogic<ISuccess<T>>.Or(bool condition)
        {
            IsSuccess = IsSuccess || condition;
            return this;
        }

        ISuccess<T> ILogic<ISuccess<T>>.Or(Func<bool> evaluate)
        {
            IsSuccess = IsSuccess || evaluate.Invoke();
            return this;
        }

        ISuccess<T> ILogic<ISuccess<T>>.OrNot(bool condition)
        {
            IsSuccess = IsSuccess || !condition;
            return this;
        }

        ISuccess<T> ILogic<ISuccess<T>>.OrNot(Func<bool> evaluate)
        {
            IsSuccess = IsSuccess || !evaluate.Invoke();
            return this;
        }

        IFailure<T> ILogic<IFailure<T>>.And(bool condition)
        {
            IsSuccess = !(IsFailure && condition);
            return this;
        }

        IFailure<T> ILogic<IFailure<T>>.And(Func<bool> evaluate)
        {
            IsSuccess = !(IsFailure && evaluate.Invoke());
            return this;
        }

        IFailure<T> ILogic<IFailure<T>>.AndNot(bool condition)
        {
            IsSuccess = !(IsFailure && !condition);
            return this;
        }

        IFailure<T> ILogic<IFailure<T>>.AndNot(Func<bool> evaluate)
        {
            IsSuccess = !(IsFailure && !evaluate.Invoke());
            return this;
        }

        IFailure<T> ILogic<IFailure<T>>.Or(bool condition)
        {
            IsSuccess = !(IsFailure || condition);
            return this;
        }

        IFailure<T> ILogic<IFailure<T>>.Or(Func<bool> evaluate)
        {
            IsSuccess = !(IsFailure || evaluate.Invoke());
            return this;
        }

        IFailure<T> ILogic<IFailure<T>>.OrNot(bool condition)
        {
            IsSuccess = !(IsFailure || !condition);
            return this;
        }

        IFailure<T> ILogic<IFailure<T>>.OrNot(Func<bool> evaluate)
        {
            IsSuccess = !(IsFailure || !evaluate.Invoke());
            return this;
        }
    }
}