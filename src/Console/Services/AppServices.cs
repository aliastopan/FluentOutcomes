using System.Diagnostics;
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
        _logger.LogWarning("Starting...");

        // // string? foo = "";
        // // string? bar = "";
        // // string? baz = "";
        // // string? qux = "";
        // // string? led = "A";
        // // string? bam = "";
        // // string? dim = "";
        // // string? cok = "";

        var qux = Outcome
            .Expect()
            .SuccessIf(true)
                .Or(true)
                .And(true)
                .And(false)
                .Or(true)
            .Otherwise()
            .Return();

        _logger.LogInformation($"qux: {qux.IsSuccess}");


        // var qqq = (true && false) || true; // false
        // var fff = true && (false || true); // true

        var foo = Outcome
            .Expect()
            .SuccessIf(true)
                .Or(true)
                .And(() => {
                    return (true && false) || true;
                })
            .Otherwise()
            .Return();

        _logger.LogInformation($"foo: {foo.IsSuccess}");










        // var actual = foo == "X" && bar == "X" || qux == "X" || led == "" || dim == "X";
        // _logger.LogInformation($"Actual: {actual}");
        // bool disabled = true;
        // bool overwritten = true;
        // bool actual = !(foo == "" && !disabled);



        // string surpress = $"{foo} {bar} {baz} {qux} {led} {dim} {bam} {cok}";
        // surpress = "";
    }
}