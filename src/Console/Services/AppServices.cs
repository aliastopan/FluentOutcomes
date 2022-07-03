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

        IOutcome foo = Outcome
            .Expect()
            .Failure(error => {
                error.Exception = new Exception("Forced error");
            });

        _logger.LogInformation($"isFailure: {foo.IsFailure}");
        if(foo.IsFailure)
            _logger.LogError($"verdict: {foo.Verdict}");
        else
            _logger.LogInformation($"verdict: {foo.Verdict}");

        _logger.LogWarning($"==============================");

        IOutcome<string> bar = Outcome
            .Expect<string>()
            .Success("Bar");

        _logger.LogInformation($"isFailure: {bar.IsFailure}");
        _logger.LogInformation($"verdict: {bar.Verdict}");
        _logger.LogInformation($"value: {bar.Value}");

        _logger.LogWarning($"==============================");

        var _value = "";

        IOutcome<string> baz = Outcome
            .Expect<string>()
            .Failure(_value, error => {
                error.Exception = new Exception("WTF!");
            });

        _logger.LogInformation($"isFailure: {baz.IsFailure}");
        _logger.LogInformation($"verdict: {baz.Verdict}");
        if(baz.IsFailure)
        {
            _logger.LogCritical($"value: {baz.Value}");
        }
    }
}