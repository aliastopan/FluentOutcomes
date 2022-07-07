using FluentOutcomes;

namespace FluentOutcomes.Tests;

public class DelegateTests
{
    [Fact]
    public void SucessIfTests()
    {
        var qux = Outcome
            .Expect()
            .SuccessIf(true)
                .And(false)
                .Or(true)
            .Otherwise()
            .Return();

        // var qqq = (true && false) || true; // false
        // var fff = true && (false || true); // true

        var foo = Outcome
            .Expect()
            .SuccessIf(() => {
                return true;
            })
                .And(() => {
                    return false || true;
                })
            .Otherwise()
            .Return();

        // var bar = false && (false || true);

        Assert.Equal(qux.IsSuccess, foo.IsSuccess);
    }

    [Fact]
    public void TestName()
    {
        var foo = Outcome
            .Expect()
            .SuccessIf(() => {
                var evaluate = true && false && (false || true);
                return evaluate;
            })
            .Otherwise()
            .Return();

        var x = true && false && (false || true);

        Assert.Equal(x, foo.IsSuccess);
    }
}
