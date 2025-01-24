using CubePdf2Png;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

if (!CommandLineArgs.TryParse(args, out CommandLineArgs? commandLineArgs, out var errorMessage))
{
    Console.WriteLine(errorMessage);
    return;
}

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostContext, config) =>
    {
        config.AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true);
    })
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddTransient(_ => commandLineArgs!);
    })
    .ConfigureLogging((hostContext, logging) =>
    {
        logging.AddConsole();
    })
    .Build();

await host.RunAsync();
