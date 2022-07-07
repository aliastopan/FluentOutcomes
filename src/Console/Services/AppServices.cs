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

        var x = Outcome
            .Expect<Mock>()
            .SuccessIf(() => {
                bool condition = true && (false || false);
                return condition;
            })
                .And(() => {
                    return true || true || false;
                })
            .Otherwise()
            .Return(mock, overwrite: true);

        var str = x.IsSuccess ? "Success" : "Failure";
        _logger.LogWarning($"???: {str}");
        _logger.LogWarning($"Mock: {x.Value.Message}");

    }
}