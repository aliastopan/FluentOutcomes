using System;
using FluentOutcomes.Contracts;
using FluentOutcomes.Metadata;

namespace FluentOutcomes
{
    public partial class Outcome : IOutcome, IExpect, ISuccess, IFailure, IOtherwise, IReturn
    {
        public bool IsSuccess { get; protected set; }
        public bool IsFailure => !IsSuccess;
        public ResultTrace ResultTrace { get; protected set; }
        public bool HasMetadata => ResultTrace.Metadata.Count > 0;

        protected Outcome()
        {
            ResultTrace = new ResultTrace();
        }

        protected Outcome(bool condition)
        {
            ResultTrace = new ResultTrace();
            IsSuccess = condition;
        }

        protected Outcome(bool condition, Error error)
        {
            ResultTrace = new ResultTrace();
            IsSuccess = condition;
            ResultTrace.Error = error;
        }

        protected Outcome(bool condition, Action<Error> error)
        {
            var err = new Error();
            error?.Invoke(err);

            ResultTrace = new ResultTrace();
            IsSuccess = condition;
            ResultTrace.Error = err;
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
            ResultTrace.ApplyMetadataSetting(IsSuccess);
            return this;
        }

        public IOutcome WithMetadata(string metadataName, object metadataValue, AssertLevel assertLevel = AssertLevel.Default)
        {
            ResultTrace.AssertMetadata(metadataName, metadataValue, IsSuccess, assertLevel);
            return this;
        }

    }

    internal partial class Outcome<T> : Outcome, IOutcome<T>, IExpect<T>, ISuccess<T>, IFailure<T>, IOtherwise<T>, IReturn<T>
    {
        public T Value { get; set; } = default;

        protected internal Outcome()
            : base()
        {

        }

        protected internal Outcome(T value, bool condition)
            : base(condition)
        {
            Value = value;
        }

        protected internal Outcome(T value, bool condition, Error error)
            : base(condition, error)
        {
            Value = value;
        }

        protected internal Outcome(T value, bool condition, Action<Error> error)
            : base(condition, error)
        {
            Value = value;
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
            ResultTrace.ApplyMetadataSetting(IsSuccess);

            if(overwrite)
            {
                Value = value;
                return this;
            }

            Value = IsSuccess ? value : default;
            return this;
        }

        public IOutcome<T> Return(Func<T> value, bool overwrite = false)
        {
            ResultTrace.ApplyMetadataSetting(IsSuccess);

            if(overwrite)
            {
                Value = value.Invoke();
                return this;
            }

            Value = IsSuccess ? value.Invoke() : default;
            return this;
        }

        public new IOutcome<T> WithMetadata(string metadataName, object metadataValue, AssertLevel assertLevel = AssertLevel.Default)
        {
            ResultTrace.AssertMetadata(metadataName, metadataValue, IsSuccess, assertLevel);
            return this;
        }
    }
}