namespace FluentOutcomes.Contracts;

public interface ISuccess : ILogic<ISuccess>
{
    IReturn Otherwise();
    IReturn Otherwise(Error error);
    IReturn Otherwise(Action<Error> error);
}

public interface ISuccess<T> : ISuccess, ILogic<ISuccess<T>>
{
    new IReturn<T> Otherwise();
    new IReturn<T> Otherwise(Error error);
    new IReturn<T> Otherwise(Action<Error> error);
}