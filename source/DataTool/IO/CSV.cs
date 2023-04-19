using DataTool.CommandLineOptions;
using Model.Model;

namespace DataTool.IO
{
    internal class CSV
    {
        internal static int WriteCSV(ExportCSV options)
        {
            // Null-value handling
            if (string.IsNullOrEmpty(options.Output))
            {
                options.Output = Environment.CurrentDirectory;
            }

            if (options.Separator == null || options.Separator.Equals("tab", StringComparison.OrdinalIgnoreCase))
            {
                options.Separator = "\t";
            }

            DataFile? dataFile = JSON.ReadDataFile(options.InputFile);

            if (dataFile == null)
            {
                Console.WriteLine($"Failed to read data file: {options.InputFile}");

                return 1;
            }

            var worstResult = 0;

            if (options.ExportCards)
            {
                worstResult = WriteCards(dataFile, options.Output, options.Language);
            }

            if (options.ExportQuests)
            {
                worstResult = int.Min( worstResult, WriteQuests(dataFile, options.Output, options.Language) );
            }

            return worstResult;
        }

        internal static int WriteCards(DataFile dataFile, string outputDirectory, string language)
        {
            return 0;
        }

        internal static int WriteQuests(DataFile dataFile, string outputDirectory, string language)
        {
            return 0;
        }
    }
}
