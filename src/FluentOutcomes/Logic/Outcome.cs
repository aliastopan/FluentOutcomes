using System;
using FluentOutcomes.Contracts;

namespace FluentOutcomes
{
    public partial class Outcome
    {
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

    internal partial class Outcome<T> : Outcome
    {
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