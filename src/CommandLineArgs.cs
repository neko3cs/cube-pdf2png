namespace CubePdf2Png;

public record CommandLineArgs
{
    public string PdfFilePath { get; private set; }
    public string OutputDirPath { get; private set; }

    private CommandLineArgs(string[] args)
    {
        PdfFilePath = args[0];
        OutputDirPath = args[1];
    }

    public static bool TryParse(string[] args, out CommandLineArgs? commandLineArgs, out string errorMessage)
    {
        commandLineArgs = null;
        errorMessage = string.Empty;
        const string usage = "Usage: convertpdf2png <PdfFilePath> <OutputDirPath>";

        if (args.Length != 2)
        {
            errorMessage = usage;
            return false;
        }
        if (!System.IO.File.Exists(args[0]))
        {
            errorMessage = "PDF file does not exist.";
            return false;
        }
        if (!args[0].EndsWith(".pdf"))
        {
            errorMessage = usage;
            return false;
        }
        if (!System.IO.Directory.Exists(args[1]))
        {
            errorMessage = "Output directory does not exist.";
            return false;
        }
        commandLineArgs = new CommandLineArgs(args);
        return true;
    }
}