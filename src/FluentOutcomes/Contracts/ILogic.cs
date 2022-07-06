namespace FluentOutcomes.Contracts;

public interface ILogic<I>
{
    I Or(bool condition);
    I OrNot(bool condition);
    I And(bool condition);
    I AndNot(bool condition);
}