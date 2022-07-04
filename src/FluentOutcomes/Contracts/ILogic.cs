namespace FluentOutcomes.Contracts;

public interface ILogic<I>
{
    I Or(bool condition);
    I And(bool condition);
}