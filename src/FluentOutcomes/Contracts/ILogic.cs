using System;

namespace FluentOutcomes.Contracts
{
    public interface ILogic<I>
    {
        I And(bool condition);
        I And(Func<bool> evaluate);
        I AndNot(bool condition);
        I AndNot(Func<bool> evaluate);
        I Or(bool condition);
        I Or(Func<bool> evaluate);
        I OrNot(bool condition);
        I OrNot(Func<bool> evaluate);
    }
}
