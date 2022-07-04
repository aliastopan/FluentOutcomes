namespace FluentOutcomes.Contracts;

public interface ILogic<I>
{
    I Or(bool expectation);
    I OrNot(bool expectation);
    I And(bool expectation);
    I AndNot(bool expectation);
}