using System.Text.Json;
using System.Text.Json.Serialization;
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

        internal static bool WriteDataFile(string path, DataFile dataFile)
        {
            try
            {
                var options = new JsonSerializerOptions {WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull};
                var text = JsonSerializer.Serialize(dataFile, options);

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                File.WriteAllText(path, text);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing data file {path}: {ex.Message}");

                return false;
            }
        }
    }
}
