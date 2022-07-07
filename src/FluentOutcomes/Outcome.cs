using System;
using FluentOutcomes.Contracts;

namespace FluentOutcomes
{
    public class Outcome : IOutcome, IExpect, ISuccess, IFailure, IOtherwise, IReturn
    {
        public bool IsSuccess { get; protected set; }
        public bool IsFailure => !IsSuccess;
        public Error? Error { get; protected set; }
        public string Verdict => Error is null ? "OK" : Error.Exception.Message;

        protected Outcome()
        {

        }

        public static IOutcome Ok()
        {
            return new Outcome(){
                IsSuccess = true
            };
        }

        public static IOutcome<T> Ok<T>(T value)
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
            Value = IsSuccess ? value : default!;
            return this;
        }

        public IOutcome<T> Return(Func<T> value)
        {
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