using Cube.Pdf.Ghostscript;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CubePdf2Png;

public class Worker(
    ILogger<Worker> logger,
    IHostApplicationLifetime applicationLifetime,
    CommandLineArgs commandLineArgs
) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var converter = new ImageConverter(Format.Png)
        {
            Paper = Paper.Auto,
            Orientation = Orientation.Auto,
            Resolution = 600,
        };

        var pngFilePath = Path.ChangeExtension(
            Path.Join(
                commandLineArgs.OutputDirPath,
                Path.GetFileName(commandLineArgs.PdfFilePath)),
            ".png");
        converter.Invoke(commandLineArgs.PdfFilePath, pngFilePath);

        logger.LogInformation($"Convert to png: {pngFilePath}");

        applicationLifetime.StopApplication();
        return Task.CompletedTask;
    }
}