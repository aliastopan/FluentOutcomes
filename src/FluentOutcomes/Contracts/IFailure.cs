using System;

namespace FluentOutcomes.Contracts
{
    public interface IFailure : ILogic<IFailure>
    {
        IReturn Otherwise();
        IOtherwise WithError(Error error);
        IOtherwise WithError(Action<Error> error);
    }

    public interface IFailure<T> : ILogic<IFailure<T>>
    {
        IReturn<T> Otherwise();
        IOtherwise<T> WithError(Error error);
        IOtherwise<T> WithError(Action<Error> error);
    }
}
