using CommandLine;

namespace DataTool.CommandLineOptions
{
    public abstract class Options
    {
        [Option('i', "input", Required = true, HelpText = "Path to data file")]
        public string? DataFile { get; set; }

        [Option('l', "language", Default = "en-US", HelpText = "Language selection (if and when other languages are added to the data files). If a language is unrecognized, the first language given in the data file is used instead.")]
        public string Language { get; set; } = "en-US";
    }
}
