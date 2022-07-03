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

        string? msg = "";
        int number = 100;

        var foo = Outcome
            .Expect<string>()
            .FailureIf(number < 1)
            .WithError(error => {
                error.Exception = new Exception();
            })
            .Otherwise()
            .Return(msg!);

        _logger.LogWarning($"Failure : {foo.IsFailure}");
        _logger.LogWarning($"Verdict : {foo.Verdict}");
        _logger.LogWarning($"Value : {foo.Value}");

    }
}