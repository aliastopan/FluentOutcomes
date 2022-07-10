using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using FluentOutcomes;
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
        _logger.LogWarning("Starting...");

        Outcome.ConfigureSettings(options =>
        {
            options.SetAllCorrectMessage("All Correct");
            options.SetDefaultErrorMessage("Critical Error");
            options.DisablePrefaceMetadata();

            // setting.AddPrefaceMetadata("Custom1", 5);
            // setting.AddPrefaceMetadata("Custom2", "This is Preface");
        });

        var mock = new Mock();

        var x = Outcome
            .Expect<Mock>()
            .FailureIf(true)
                .Or(true)
            .WithError(error => {
                string message = "Something went wrong.";
                error.Exception = new Exception(message);
            })
            .Otherwise()
            .Return(mock, overwrite: true)
                .WithMetadata("Expected", mock)
                .WithMetadata("Timestamp", DateTime.Now);

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