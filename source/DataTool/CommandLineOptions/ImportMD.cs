using CommandLine;

namespace DataTool.CommandLineOptions
{
    [Verb("md-import", HelpText = "Import data from prepared markdown file and convert to JSON")]
    public class ImportMD : Options
    {
        [Option('o', "output", Required = false, HelpText = "Path to output directory. File names are auto-generated from the datafile name and the export type. If left empty, current working directory is used.")]
        public string? Output { get; set; }
    }
}
