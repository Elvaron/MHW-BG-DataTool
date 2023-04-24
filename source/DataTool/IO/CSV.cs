using DataTool.CommandLineOptions;
using Model.Model;

namespace DataTool.IO
{
    internal class CSV
    {

        private const string BlankImage = @"E:\P\MHW-BG-QuestCards\source\images\compass\blank.png";
        private const string North = @"E:\P\MHW-BG-QuestCards\source\images\compass\north.png";
        private const string East = @"E:\P\MHW-BG-QuestCards\source\images\compass\east.png";
        private const string South = @"E:\P\MHW-BG-QuestCards\source\images\compass\south.png";
        private const string West = @"E:\P\MHW-BG-QuestCards\source\images\compass\west.png";
        private const string NorthEast = @"E:\P\MHW-BG-QuestCards\source\images\compass\north-east.png";
        private const string SouthEast = @"E:\P\MHW-BG-QuestCards\source\images\compass\south-east.png";
        private const string NorthWest = @"E:\P\MHW-BG-QuestCards\source\images\compass\north-west.png";
        private const string SouthWest = @"E:\P\MHW-BG-QuestCards\source\images\compass\south-west.png";

        private const string One = @"E:\P\MHW-BG-QuestCards\source\images\difficulty\1-star.png";
        private const string Two = @"E:\P\MHW-BG-QuestCards\source\images\difficulty\2-stars.png";
        private const string Three = @"E:\P\MHW-BG-QuestCards\source\images\difficulty\3-stars.png";
        private const string Four = @"E:\P\MHW-BG-QuestCards\source\images\difficulty\4-stars.png";
        private const string Five = @"E:\P\MHW-BG-QuestCards\source\images\difficulty\5-stars.png";

        private const string EmptyNode = @"E:\P\MHW-BG-QuestCards\source\images\terrain-nodes\blank-node-350.png";
        private const string BushNode = @"E:\P\MHW-BG-QuestCards\source\images\terrain-nodes\bush-button.png";
        private const string PondNode = @"E:\P\MHW-BG-QuestCards\source\images\terrain-nodes\pond-button.png";
        private const string RockNode = @"E:\P\MHW-BG-QuestCards\source\images\terrain-nodes\rock-button.png";
        private const string SnowNode = @"E:\P\MHW-BG-QuestCards\source\images\terrain-nodes\snow-button.png";
        private const string PlayerNode = @"E:\P\MHW-BG-QuestCards\source\images\terrain-nodes\hunter-button.png";

        private const string MonsterIconFolder = @"E:\P\MHW-BG-QuestCards\source\images\monster-icons";

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

            if (options.ExportMaps)
            {
                worstResult = int.Min(worstResult, WriteMaps(dataFile, options.Output, options.Language));
            }

            return worstResult;
        }

        internal static int WriteCards(DataFile dataFile, string outputDirectory, string language)
        {
            return 0;
        }

        internal static int WriteQuests(DataFile dataFile, string outputDirectory, string language)
        {
            if (dataFile == null || dataFile.QuestBooks == null)
            {
                return 1;
            }

            // Write backsides
            var outputFileBacks = Path.Combine(outputDirectory, $"quests-backs-{dataFile.Filename}.csv");

            // Images
            var buttons = Directory.GetFiles(MonsterIconFolder, "*.png");

            var monsters = new Dictionary<string, string>();
            foreach (var button in buttons)
            {
                var key = Path.GetFileNameWithoutExtension(button);
                if (key.EndsWith("-button"))
                {
                    continue;
                }
                monsters[key] = button;
            }

            // Header
            var headerLine = "CardReference\tDifficultyIcon\tMonsterIcon";
            var outputLines = new List<string>
            {
                headerLine
            };

            foreach (var questbook in dataFile.QuestBooks)
            {
                if (questbook.Quests == null)
                {
                    continue;
                }

                foreach (var quest in questbook.Quests)
                {
                    if (quest.MonsterId == null)
                    {
                        continue;
                    }

                    var outputArray = new string[3];

                    // Dataset Name
                    //outputArray[0] = quest.QuestId ?? $"{quest.MonsterId}-{quest.Difficulty}";

                    // Card Reference
                    var shortTitle = questbook.ShortTitle?.Get(language);
                    var page = dataFile.Glossary?.AbbreviationPage?.Get(language);
                    var pageNumber = quest.Page.HasValue ? (string.IsNullOrEmpty(page) ? $"{quest.Page}" : $"{page} {quest.Page}") : "";
                    outputArray[0] = string.IsNullOrEmpty(shortTitle) ? pageNumber : $"{shortTitle}-{pageNumber}";

                    outputArray[1] = getDifficultyImage(quest.Difficulty);

                    if (monsters.TryGetValue(quest.MonsterId, out var monsterImage))
                    {
                        outputArray[2] = monsterImage;
                    }

                    outputLines.Add(string.Join("\t", outputArray));
                }
            }

            File.WriteAllLines(outputFileBacks, outputLines, System.Text.Encoding.UTF8);

            return 0;
        }

        internal static int WriteMaps(DataFile dataFile, string outputDirectory, string language)
        {
            if (dataFile == null || dataFile.QuestBooks == null)
            {
                return 1;
            }

            var outputFile = Path.Combine(outputDirectory, $"maps-{dataFile.Filename}.csv");

            // Images
            var buttons = Directory.GetFiles(MonsterIconFolder, "*-button.png");

            var monsters = new Dictionary<string, string>();
            foreach (var button in buttons)
            {
                var key = Path.GetFileNameWithoutExtension(button).Replace("-button", "");
                monsters[key] = button;
            }

            var gridOffset = 1;
            var compassOffset = gridOffset + 36;

            // Maps-Line
            var headers = new string[73];
            headers[0] = "dataset";
            for (int x = 1; x < 7; x++)
            {
                for (int y = 1; y < 7; y++)
                {
                    var index = calculateIndex(x, y);
                    headers[gridOffset + index] = $"Node{x}-{y}";
                    headers[compassOffset + index] = $"C{x}-{y}";
                }
            }

            string headerLine = string.Join(",", headers);
            var outputLines = new List<string>
            {
                headerLine
            };

            foreach (var questbook in dataFile.QuestBooks)
            {
                if (questbook.Quests == null)
                {
                    continue;
                }

                foreach (var quest in questbook.Quests)
                {
                    if (quest.Layout == null || quest.Layout.Monsters == null || quest.Layout.Players == null)
                    {
                        continue;
                    }

                    // 1 string for dataset id, 36 for nodes, 36 for compass overlays
                    var outputArray = new string[73];
                    outputArray[0] = quest.QuestId ?? $"{quest.MonsterId}-{quest.Difficulty}";

                    for (int i = 0; i < 36; i++)
                    {
                        outputArray[gridOffset + i] = EmptyNode;
                        outputArray[compassOffset + i] = BlankImage;
                    }

                    // Place terrain node(s)
                    if (quest.Layout.Terrain != null)
                    {
                        foreach (var terrainNode in quest.Layout.Terrain)
                        {
                            var index = calculateIndex(terrainNode.X, terrainNode.Y);
                            var terrain = getTerrainImage(terrainNode.Type);

                            if (terrain != null)
                            {
                                outputArray[index + gridOffset] = terrain;
                            }
                        }
                    }

                    // Place monster(s)
                    foreach (var monsterNode in quest.Layout.Monsters)
                    {
                        if (monsterNode.MonsterId == null || !monsters.ContainsKey(monsterNode.MonsterId))
                        {
                            continue;
                        }

                        var monsterIcon = monsters[monsterNode.MonsterId];

                        var index = calculateIndex(monsterNode.X, monsterNode.Y);

                        var facing = getFacingImage(monsterNode.Facing);

                        outputArray[index + gridOffset] = monsterIcon;

                        outputArray[index + compassOffset] = facing;
                    }

                    // Place player(s)
                    foreach (var playerNode in quest.Layout.Players)
                    {
                        var index = calculateIndex(playerNode.X, playerNode.Y);
                        outputArray[index + gridOffset] = PlayerNode;
                    }

                    outputLines.Add(string.Join(",", outputArray));
                }                
            }

            File.WriteAllLines(outputFile, outputLines, System.Text.Encoding.UTF8);

            return 0;
        }

        private static string? getTerrainImage(string? type)
        {
            switch (type)
            {
                case "bush": return BushNode;
                case "pond": return PondNode;
                case "rock": return RockNode;
                case "snow": return SnowNode;
            }

            return null;
        }

        private static string getFacingImage(int? facing)
        {
            int monsterFacing = (facing == null || facing < 1) ? 1 : facing.Value;

            switch (monsterFacing)
            {
                case 2: return NorthEast;
                case 3: return East;
                case 4: return SouthEast;
                case 5: return South;
                case 6: return SouthWest;
                case 7: return West;
                case 8: return NorthWest;
                default: return North;
            }
        }

        private static string getDifficultyImage(int? difficulty)
        {
            if (difficulty == null) { return ""; }
            switch (difficulty)
            {
                case 2: return Two;
                case 3: return Three;
                case 4: return Four;
                case 5: return Five;
                default: return One;
            }
        }

        private static int calculateIndex(int? x, int? y)
        {
            // All indices need to be shifted left by one to account for human-friendly index 1-6 instead of 0-5
            var row = (y ?? 1) - 1;
            var column = (x ?? 1) - 1;

            return row * 6 + column;
        }
    }
}
