using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using FluentOutcomes;

namespace Console.Services;

public class AppService : IAppService
{
    private readonly ILogger<AppService> _logger;
    private readonly IConfiguration _config;

    public AppService(ILogger<AppService> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }

    public void Run()
    {
        _logger.LogInformation("Starting...");

        string? foo = "";
        string? bar = "";
        string? baz = "";
        string? qux = "";
        string? led = "A";
        string? bam = "";
        string? dim = "";
        string? cok = "";

        Func<bool> xFunc = () => foo == "";

        var x = Outcome
            .Expect<string>()
            .SuccessIf(() => {
                var evaluate = qux != "" || dim != "";
                return evaluate;
            })
            .Otherwise()
            .Return("");

        var result = x.IsSuccess ? "Success" : "Failure";
        _logger.LogInformation($"Outcome: {result}");












        // var actual = foo == "X" && bar == "X" || qux == "X" || led == "" || dim == "X";
        // _logger.LogInformation($"Actual: {actual}");
        // bool disabled = true;
        // bool overwritten = true;
        // bool actual = !(foo == "" && !disabled);



        string surpress = $"{foo} {bar} {baz} {qux} {led} {dim} {bam} {cok}";
        surpress = "";
    }
}