using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Console.Services;
using FluentOutcomes;
using FluentOutcomes.Metadata;

IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) => {
        services.AddTransient<IAppService, AppService>();
    })
    .UseSerilog()
    .Build();

var app = ActivatorUtilities.CreateInstance<AppService>(host.Services);
var sw = new Stopwatch();

Outcome.ConfigureSettings(config =>
{
    config.SetAllCorrectMessage("Yay!");
    config.SetDefaultErrorMessage("Oops...");
    config.Metadata(x =>
    {
        x.AssertStatusResult();
        x.AssertVerdict();
        x.AssertGlobalMetadata("Success", "200", AssertLevel.SuccessOnly);
        x.AssertGlobalMetadata("Failure", "400", AssertLevel.FailureOnly);
    });
});


// sw.Start();
for (int i = 0; i < 10; i++)
{
    sw.Restart();
    app.Run();
    sw.Stop();

    // string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
    //         sw.Elapsed.Hours, sw.Elapsed.Minutes, sw.Elapsed.Seconds,
    //         sw.Elapsed.Milliseconds / 10);
    // Log.Information(elapsedTime);
    // System.Console.WriteLine("Elapsed: {0}", sw.Elapsed);

    Log.Information("Elapsed: {0} ms", sw.ElapsedMilliseconds);
}