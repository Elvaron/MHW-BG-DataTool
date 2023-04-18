using Model.Model;

namespace DataTool.IO
{
    internal class JSON
    {
        internal static DataFile? ReadDataFile(string? path)
        {
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
            {
                return null;
            }

            try
            {
                string input = File.ReadAllText(path);

                var result = System.Text.Json.JsonSerializer.Deserialize<DataFile>(input);

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading data file {path}: {ex.Message}");

                return null;
            }
        }
    }
}
