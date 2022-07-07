using System;
namespace FluentOutcomes.Contracts
{
    public interface IReturn
    {
        IOutcome Return();
    }

    public interface IReturn<T>
    {
        IOutcome<T> Return(T value, bool overwrite = false);
        IOutcome<T> Return(Func<T> value, bool overwrite = false);
    }
}
