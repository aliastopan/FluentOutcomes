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

        var mock = new Mock();

        IOutcome<string> foo = Outcome
            .Expect<string>()
            .SuccessIf(() => {
                bool condition = true && (false || false);
                return condition;
            })
                .And(() => {
                    return true || true || false;
                })
            .Otherwise()
            .Return("Hello, World", overwrite: true);

        var z = Outcome.Fail<int>(10);

        var str = z.IsSuccess ? "Success" : "Failure";
        _logger.LogWarning($"Result: {str}");
        _logger.LogWarning($"Mock: {z.Value}");

    }
}