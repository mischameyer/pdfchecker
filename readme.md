# Simple .NET console app to check a pdf-file with Ghostscript and validate the syntax with Syncfusion

# Use Case
You need to do some checks on pdf-files to verify if the files are valid and not corrupt.

# .NET console app
This simple app is a dotnet console app which uses ghostscript to check pdf-files and uses Syncfusion' PdfDocumentAnalyzer to validate the syntax of the pdf-file. The output is logged to the console and into a local logfile as well.

# Source
- https://www.ghostscript.com/
- https://help.syncfusion.com/cr/file-formats/Syncfusion.Pdf.Parsing.PdfDocumentAnalyzer.html

# Preconditions
1. Download and install ghostscript to your windows client: https://ghostscript.com/releases/gsdnld.html
2. change the location of the ghostscript-file in CheckPdfFileWithGhostscript.cs:
```
string gsPath = @"C:\Program Files\gs\gs10.02.0\bin\gswin64c.exe";
```
3. dotnet restore
4. dotnet build
5. dotnet run

# Example output
```
Start checking: C:\Temp\bad.pdf
No syntax error found in the provided PDF document
corrupt file: C:\Temp\bad.pdf

The following warnings were encountered at least once while processing this file:

   **** This file had errors that were repaired or ignored.
   **** Please notify the author of the software that produced this
   **** file that it does not conform to Adobe's published PDF
   **** specification.

Start checking: C:\Temp\good.pdf
No syntax error found in the provided PDF document

Press any key to close this window . . .
```
