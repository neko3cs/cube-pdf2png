using Cube.Pdf.Ghostscript;

const string usage = "Usage: convertpdf2png <PdfFilePath> <OutputDirPath>";
if (args.Length != 2)
{
    Console.WriteLine(usage);
    return;
}

var pdfFilePath = args[0];
var outputDirPath = args[1];

if (!System.IO.File.Exists(pdfFilePath))
{
    Console.WriteLine("Pdf file does not exist.");
    return;
}
if (!pdfFilePath.EndsWith(".pdf"))
{
    Console.WriteLine(usage);
    return;
}
if (!System.IO.Directory.Exists(outputDirPath))
{
    Console.WriteLine("Output directory does not exist.");
    return;
}

var converter = new ImageConverter(Format.Png)
{
    Paper = Paper.Auto,
    Orientation = Orientation.Auto,
    Resolution = 600,
};

var pngFilePath = Path.ChangeExtension(
    Path.Join(
        outputDirPath,
        Path.GetFileName(pdfFilePath)),
    ".png");
converter.Invoke(pdfFilePath, pngFilePath);
