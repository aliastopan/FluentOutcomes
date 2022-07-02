namespace FluentOutcomes.Contracts;

public interface ISuccess
{
    IReturn Otherwise();
    IReturn Otherwise(Error error);
    IReturn Otherwise(Action<Error> error);
}

public interface ISuccess<TValue> : ISuccess
{
    new IReturn<TValue> Otherwise();
    new IReturn<TValue> Otherwise(Error error);
    new IReturn<TValue> Otherwise(Action<Error> error);
}