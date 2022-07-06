namespace FluentOutcomes.Contracts;

public interface ILogic<I>
{
    I Or(bool condition);
    I OrNot(bool condition);
    I And(bool condition);
    I AndNot(bool condition);
    I Or(Func<bool> evaluate);
    I OrNot(Func<bool> evaluate);
    I And(Func<bool> evaluate);
    I AndNot(Func<bool> evaluate);
}