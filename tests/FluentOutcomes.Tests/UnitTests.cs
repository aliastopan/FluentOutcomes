
namespace FluentOutcomes.Tests;

public class UnitTests
{
    [Fact]
    public void ExpectSuccessTest()
    {
        var x = Outcome
            .Expect()
            .Success();

        Assert.Equal(true, x.IsSuccess);
    }

    [Fact]
    public void ExpectFailureTest()
    {
        var x = Outcome
            .Expect()
            .Failure(error => {
                error.Exception = new Exception();
            });

        Assert.Equal(false, x.IsSuccess);
    }
}