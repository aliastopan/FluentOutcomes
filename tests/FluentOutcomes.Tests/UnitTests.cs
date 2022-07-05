
namespace FluentOutcomes.Tests;

public class UnitTests
{
    [Fact]
    public void _SuccessChaining()
    {
        var x = Outcome
            .Expect()
            .SuccessIf(true)
                .And(true)
                .And(true)
                .And(true)
            .Otherwise()
            .Return();

        Assert.True(x.IsSuccess);
    }

    [Fact]
    public void _FailureChaining()
    {
        var x = Outcome
            .Expect()
            .FailureIf(false)
                .Or(false)
                .Or(false)
                .Or(false)
            .Otherwise()
            .Return();

        Assert.True(x.IsSuccess);
    }

    [Fact]
    public void OutcomeInstantTest()
    {
        var foo = Outcome.OK();
        var bar = Outcome.OK<string>("OK");
        var baz = Outcome.Fail();
        var qux = Outcome.Fail(new Error());
        var led = Outcome.Fail(error => { error.Exception = new Exception(); });
        var bam = Outcome.Fail<string>("Fail");
        var dim = Outcome.Fail<string>("Fail", new Error());
        var cok = Outcome.Fail<string>("Fail", error => { error.Exception = new Exception(); });

        Assert.True(foo.IsSuccess);
        Assert.True(bar.IsSuccess);
        Assert.True(baz.IsFailure);
        Assert.True(qux.IsFailure);
        Assert.True(led.IsFailure);
        Assert.True(bam.IsFailure);
        Assert.True(dim.IsFailure);
        Assert.True(cok.IsFailure);
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

    [Fact]
    public void SuccessLogicChainTest()
    {
        string? foo = "";
        string? bar = "";
        string? baz = "";
        string? qux = "";

        var x = Outcome
            .Expect<string>()
            .SuccessIf(foo == "")
                .And(bar == "")
                .And(baz == "")
                .And(qux == "")
            .Otherwise()
            .Return("");

        Assert.True(x.IsSuccess);
    }

    [Fact]
    public void FailureLogicChainTest()
    {
        string? foo = "";
        string? bar = "";
        string? baz = "";
        string? qux = "";

        var x = Outcome
            .Expect<string>()
            .FailureIf(foo == "")
                .Or(bar == "")
                .Or(baz == "")
                .Or(qux == "")
            .WithError(error => {
                string message = "error";
                error.Exception = new Exception(message);
            })
            .Otherwise()
            .Return("Hello, World");

        Assert.True(x.IsFailure);
    }

    [Fact]
    public void SuccessAndNotTest()
    {
        string? foo = "";
        string? bar = "";

        var x = Outcome
            .Expect<string>()
            .SuccessIf(foo == "")
                .AndNot(bar == "")
            .Otherwise()
            .Return("");

        Assert.True(x.IsFailure);
    }

    [Fact]
    public void SuccessOrNotTest()
    {
        string? foo = "";
        string? bar = "";

        var x = Outcome
            .Expect<string>()
            .SuccessIf(foo == "")
                .AndNot(bar == "")
            .Otherwise()
            .Return("");

        Assert.True(x.IsFailure);
    }

    [Fact]
    public void LongChainingTest()
    {
        string? foo = "X";
        string? bar = "";
        string? baz = "O";
        string? qux = "";
        string? led = "Y";
        string? bur = "";
        // string? bam = "";

        bool args = foo == "" || bar == "" || baz == "" || qux == "" && !(led == "X");

        var x = Outcome
            .Expect<string>()
            .FailureIf(foo == "")
                .AndNot(foo == "Z")
                .Or(led == "X")
                .And(bar == "D")
                .OrNot(bar == bur)
            .Otherwise()
            .Return("");

        Assert.True(x.IsSuccess);

    var xx = Outcome
        .Expect<int>()
        .SuccessIf(true)
        .Otherwise()
        .Return(10);
    }
}