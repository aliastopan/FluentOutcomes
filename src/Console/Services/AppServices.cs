using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using FluentOutcomes;
using FluentOutcomes.Metadata;
using FluentOutcomes.Settings;
using Console.Models;

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
        // var x = new OutcomeSettingOptions();

        _logger.LogWarning("Starting...");

        Outcome.ConfigureSettings(config =>
        {
            config.SetAllCorrectMessage("Yay!");
            config.SetDefaultErrorMessage("Oops...");
            config.Metadata(stack =>
            {
                stack.AddStatusResult();
                stack.AddVerdict();
                stack.AddGlobalMetadata("Preface", "Global Metadata");
            });
        });

        var mock = new Mock();

        var x = Outcome
            .Expect<Mock>()
            .FailureIf(false)
            .WithError(error => {
                string message = "Something went wrong.";
                error.Exception = new Exception(message);
            })
            .Otherwise()
            .Return(mock, overwrite: true)
                .WithMetadata("Expected", mock)
                .WithMetadata("Timestamp", DateTime.Now)
                .WithMetadata("OnlyFailure", "Fail?", AssertLevel.OnlyFailure)
                .WithMetadata("OnlySuccess", "Success?", AssertLevel.OnlySuccess);

        var str = x.IsSuccess ? "Success" : "Failure";
        _logger.LogWarning($"Result: {str}");
        _logger.LogWarning($"Verdict: {x.ResultTrace.Verdict}");
        _logger.LogWarning($"Mock: {x.Value}");

        if(x.HasMetadata)
        {
            for (int i = 0; i < x.ResultTrace.Metadata.Count; i++)
            {
                var metadata = x.ResultTrace.Metadata.ElementAt(i);
                _logger.LogCritical($"[{i+1}]: {metadata}");
            }
        }

    }
}