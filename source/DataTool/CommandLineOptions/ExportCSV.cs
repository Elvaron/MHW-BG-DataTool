using CommandLine;

namespace DataTool.CommandLineOptions
{
    [Verb("csv-export", HelpText = "Export data file to CSV file")]
    public class ExportCSV : Options
    {
        [Option('o', "output", Required = false, HelpText = "Path to output directory. File names are auto-generated from the datafile name and the export type. If left empty, current working directory is used.")]
        public string? Output { get; set; }

        [Option('q', "quests", Default = false, HelpText = "Set this option to export quest cards. Multiple exports can be done simultaneously.")]
        public bool ExportQuests { get; set; } = false;

        [Option('c', "cards", Default = false, HelpText = "Set this option to export gathering phase cards. Multiple exports can be done simultaneously.")]
        public bool ExportCards { get; set; } = false;

        [Option('s', "separator", Default = "Tab", HelpText = "What separator character to use in CSV format.")]
        public string? Separator { get; set; } = "\t";
    }
}
