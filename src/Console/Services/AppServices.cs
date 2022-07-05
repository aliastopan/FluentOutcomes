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

        var actual = foo == "X" && bar == "X" || qux == "X" || led == "" || dim == "X";

        var x = Outcome
            .Expect()
            .SuccessIf(foo == "X")
                .And(bar == "X")
                .Or(qux == "X")
                .Or(led == "")
                .Or(dim == "X")
            .Otherwise()
            .Return();

        _logger.LogInformation($"Actual: {actual}");
        _logger.LogInformation($"Outcome: {x.IsSuccess}");


















        string surpress = $"{foo} {bar} {baz} {qux} {led} {dim} {bam} {cok}";
        surpress = "";
    }
}