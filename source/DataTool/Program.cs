using CommandLine;
using DataTool.CommandLineOptions;
using DataTool.IO;

namespace DataTool
{
    internal class Program
    {
        static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<ExportCSV, ImportMD>(args).MapResult(
                (ExportCSV options) => CSV.WriteCSV(options),
                (ImportMD options) => MD.ReadMD(options),
                _ => 1);
        }
    }
}