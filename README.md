# cubepdf2png

PDF to PNG converter using CubePDF Lib.

## Download

This is a dotnet-tool.

```pwsh
dotnet tool install --global convertpdf2png
```

Nuget page this.

[NuGet Gallery | convertpdf2png 1.0.0](https://www.nuget.org/packages/convertpdf2png/)

## Usage

```pwsh
Usage: convertpdf2png <PdfFilePath> <OutputDirPath>
```

Single-page PDFs are only Supported.

If you specify a multi-page PDF, only the first page will be converted to a PNG image.

The file name of the output PNG image is same to the PDF file name, only difference extensions.

## LICENSE

Copyright © 2024 neko3cs.

This project uses the following open source software:

- [cube-soft/cube.pdf: CubePDF, CubePDF Utility, CubePDF Page, and CubePDF SDK for .NET](https://github.com/cube-soft/cube.pdf)
  - License: Apache License 2.0
  - Copyright: CubeSoft, Inc. (2010)
