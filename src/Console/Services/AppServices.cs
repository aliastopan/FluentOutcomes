using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using FluentOutcomes;
using FluentOutcomes.Metadata;
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
        var mock = new Mock();
        // var x = new OutcomeSettingOptions();

        _logger.LogWarning("Starting...");

        Outcome.ConfigureSettings(config =>
        {
            config.SetAllCorrectMessage("Yay!");
            config.SetDefaultErrorMessage("Oops...");
            config.Metadata(stack => {
                stack.AddStatusResult();
                stack.AddVerdict();
                stack.AddGlobalMetadata("Preface", "Global Metadata");
            });
        });

        var result = Outcome
            .Expect<Mock>()
            .FailureIf(true)
            .WithError(error => {
                string message = "Something went wrong.";
                error.Exception = new Exception(message);
            })
            .Otherwise()
            .Return(mock)
                .WithMetadata("Expected", mock)
                .WithMetadata("Timestamp", DateTime.Now)
                .WithMetadata("OnlyFailure", "Fail?", AssertLevel.FailureOnly)
                .WithMetadata("OnlySuccess", "Success?", AssertLevel.SuccessOnly);

        var str = result.IsSuccess ? "Success" : "Failure";
        _logger.LogWarning($"Result: {str}");
        _logger.LogWarning($"Verdict: {result.ResultTrace.Verdict}");
        // _logger.LogWarning($"Mock: {x.Value.Message}");

        if(result.HasMetadata)
        {
            for (int i = 0; i < result.ResultTrace.Metadata.Count; i++)
            {
                var metadata = result.ResultTrace.Metadata.ElementAt(i);
                _logger.LogInformation($"[{i+1}]: " + "{0}", metadata);
            }
        }

    }
}