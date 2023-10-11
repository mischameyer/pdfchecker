using System.Diagnostics;

namespace ConsolePdfChecker
{
    public static class CheckPdfFileWithGhostscript
    {        
        public static void CheckPdfFileWithGs(string tempPDF)
        {
            try
            {
                string gsPath = @"C:\Program Files\gs\gs10.02.0\bin\gswin64c.exe";

                List<string> gsArgsList = new()
                {
                    " -o " + tempPDF,
                    " -dNODISPLAY",                    
                    " -f " + tempPDF
                };
                var gsArgs = string.Join(null, gsArgsList);

                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = gsPath,
                        Arguments = gsArgs,
                        UseShellExecute = false,
                        RedirectStandardError = true,
                        CreateNoWindow = true
                    }
                };

                process.Start();

                bool fileNamePrinted = false;

                while (!process.StandardError.EndOfStream)
                {

                    if (!fileNamePrinted)
                    {                        
                        Console.WriteLine("corrupt file: {0}", tempPDF);
                        string[] lines = { tempPDF };
                        File.AppendAllLines(Path.Combine(@"c:\temp", "corrupt.log"), lines);
                    }
                    fileNamePrinted = true;

                    var line = process.StandardError.ReadLine();
                    Console.WriteLine(line);
                }

                process.WaitForExit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
