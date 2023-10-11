namespace ConsolePdfChecker
{
    internal static class Program
    {        
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            string path = @"C:\Temp";
            string[] files = Directory.GetFiles(path, "*.pdf");
            
            foreach (string file in files)
            {
                Console.WriteLine("Start checking: {0}", file);

                CheckPdfSyntaxWithSyncfusion.CheckPdfSyntax(file);

                CheckPdfFileWithGhostscript.CheckPdfFileWithGs(file);                                               

            }
        }
    }
}