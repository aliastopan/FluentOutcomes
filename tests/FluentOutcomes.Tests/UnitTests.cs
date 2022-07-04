
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

    [Fact]
    public void ExpectSucessIfTest()
    {
        string? message = "this is a message";

        var x = Outcome
            .Expect()
            .SuccessIf(!string.IsNullOrEmpty(message))
            .Otherwise()
            .Return();

        Assert.Equal(true, x.IsSuccess);
    }

    [Fact]
    public void ExpectFailureIfTest()
    {
        string? message = "";

        var x = Outcome
            .Expect()
            .FailureIf(string.IsNullOrEmpty(message))
            .Otherwise()
            .Return();

        Assert.Equal(false, x.IsSuccess);
    }

    [Fact]
    public void GenericExpectSuccessIfTest()
    {
        string? message = "this is a message";

        IOutcome<string> x = Outcome
            .Expect<string>()
            .SuccessIf(!string.IsNullOrEmpty(message))
            .Otherwise()
            .Return(message);

        Assert.Equal(true, x.IsSuccess);
        Assert.Equal(message, x.Value);
    }

    [Fact]
    public void GenericExpectFailureIfTest()
    {
        string? message = "";

        IOutcome<string> x = Outcome
            .Expect<string>()
            .FailureIf(string.IsNullOrEmpty(message))
            .WithError(new Error())
            .Otherwise()
            .Return(message);

        Assert.Equal(false, x.IsSuccess);
        Assert.Equal(string.Empty, x.Value);
    }

    [Fact]
    public void GenericReturnTypeTest()
    {
        string? message = "this is a message";

        IOutcome<string> x = Outcome
            .Expect<string>()
            .SuccessIf(!string.IsNullOrEmpty(message))
            .Otherwise()
            .Return(message);

        Assert.Equal(typeof(string), message.GetType());
    }
}