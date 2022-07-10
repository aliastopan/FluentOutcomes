using System;
using FluentOutcomes.Metadata;

namespace FluentOutcomes.Contracts
{
    public interface ISuccess : ILogic<ISuccess>
    {
        IReturn Otherwise();
        IReturn Otherwise(Error error);
        IReturn Otherwise(Action<Error> error);
    }

    public interface ISuccess<T> : ILogic<ISuccess<T>>
    {
        IReturn<T> Otherwise();
        IReturn<T> Otherwise(Error error);
        IReturn<T> Otherwise(Action<Error> error);
    }
}