using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System.Text;

namespace ConsolePdfChecker
{
    public static class CheckPdfSyntaxWithSyncfusion
    {
        public static void CheckPdfSyntax(string filename)
        {
            using (FileStream pdfStream = new(filename, FileMode.Open, FileAccess.Read))
            {
                PdfDocumentAnalyzer analyzer = new PdfDocumentAnalyzer(pdfStream);

                SyntaxAnalyzerResult analyzerResult = analyzer.AnalyzeSyntax();

                if (analyzerResult.IsCorrupted)
                {
                    StringBuilder strBuilder = new();
                    strBuilder.AppendLine("The PDF document is corrupted.");
                    int count = 1;
                    foreach (PdfException exception in analyzerResult.Errors)
                    {
                        strBuilder.AppendLine(count++.ToString() + ": " + exception.Message);
                    }
                    Console.WriteLine(strBuilder);
                }
                else
                {
                    Console.WriteLine("No syntax error found in the provided PDF document");
                }
                analyzer.Close();
            }
        }
    }
}
