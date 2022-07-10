using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Console.Services;

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

sw.Start();
app.Run();
sw.Stop();


Log.Information("Elapsed: {0} ms", sw.ElapsedMilliseconds);