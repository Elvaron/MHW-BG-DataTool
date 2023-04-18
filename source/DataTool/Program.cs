using CommandLine;
using DataTool.CommandLineOptions;
using DataTool.IO;

namespace DataTool
{
    internal class Program
    {
        static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<ExportCSV>(args).MapResult(CSV.WriteCSV, _ => 1);
        }
    }
}