using System.Text.RegularExpressions;
using DataTool.CommandLineOptions;
using Model.Model;
using Model.Model.Quests;
using Model.Utility;

namespace DataTool.IO
{
    /// <summary>
    /// Parser for custom MD format to quickly get some data
    /// </summary>
    /// <remarks>This is not a proper parser, just a finite state machine.</remarks>
    // ReSharper disable once InconsistentNaming
    internal class MD
    {
        internal static readonly Lazy<Regex> NumberRegex = new(() => new Regex(@"\s*(?:\[)\s*(?<number>\d+)\s*(?:\])\s*"));

        internal static readonly Lazy<Regex> RuleSplitRegex = new(() => new Regex(@"^\s*(or)\s*$"));

        internal static readonly Lazy<Regex> ConditionSplitRegex = new(() => new Regex(@"^\s*(----)\s*$"));

        internal static readonly Lazy<Regex> IrrelevantRegex = new(() => new Regex(@"\s*(\[)\s*(Scoutfly)\s*(\])\s*", RegexOptions.IgnoreCase));

        // ReSharper disable once InconsistentNaming
        internal static int ReadMD(ImportMD options)
        {
            if (string.IsNullOrEmpty(options.InputFile) || !File.Exists(options.InputFile))
            {
                Console.WriteLine($"Failed to read input file {options.InputFile}");

                return 1;
            }

            // Null-value handling
            if (string.IsNullOrEmpty(options.Output))
            {
                options.Output = Environment.CurrentDirectory;
            }

            try
            {
                var lines = File.ReadAllLines(options.InputFile);

                var cardDeck = new GatheringCardDeck
                {
                    GatheringCards = new List<GatheringCard>()
                };

                var dataFile = new DataFile
                {
                    QuestBooks = new List<QuestBook>
                    {
                        new()
                        {
                            Title = new i18nString(options.InputFile),
                            CardDecks = new List<GatheringCardDeck>
                            {
                                cardDeck
                            }
                        }
                    }
                };

                for (var index = 0; index < lines.Length; index++)
                {
                    if (!NumberRegex.Value.IsMatch(lines[index]))
                    {
                        continue;
                    }

                    if (ReadCard(index, lines, out GatheringCard? card) && card != null)
                    {
                        cardDeck.GatheringCards.Add(card);
                    }
                }

                var outputFile = Path.Combine(options.Output, $"{Path.GetFileNameWithoutExtension(options.InputFile)}.json");

                return JSON.WriteDataFile(outputFile, dataFile) ? 0 : 3;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception reading MD file: {ex.Message}");

                return 2;
            }
        }

        private static bool ReadCard(int index, string[] lines, out GatheringCard? card)
        {
            if (lines.Length == 0)
            {
                card = null;
                return false;
            }

            var numberParsed = false;
            card = new GatheringCard
            {
                Rules = new List<GatheringRule>()
            };

            var section = 0;

            var titles = new List<string>();
            var consequences = new List<string>();
            var rules = new List<string>();

            // Separate lines into 3 segments - number, title and rules
            for (int iterator = index; iterator < lines.Length; iterator++)
            {
                var line = lines[iterator];

                if (NumberRegex.Value.IsMatch(line))
                {
                    if (numberParsed)
                    {
                        // We found the next card, stop the nested loop
                        break;
                    }

                    var match = NumberRegex.Value.Match(line);
                    
                    if (int.TryParse(match.Groups["number"].Value, out var result))
                    {
                        card.Number = result;
                    }

                    // Move from card number section to title section
                    section++;
                    numberParsed = true;

                    continue;
                }

                if (IrrelevantRegex.Value.IsMatch(line))
                {
                    break;
                }

                if (line.Contains("*****"))
                {
                    // Move from title section to consequences section
                    section = 2;

                    continue;
                }

                if (line.Contains("===="))
                {
                    // Move from title/consequences section to rules section
                    section = 3;

                    continue;
                }

                if (section == 1)
                {
                    // Don't add empty text
                    if (!string.IsNullOrEmpty(line))
                    {
                        titles.Add(line);
                    }

                    continue;
                }

                if (section == 2)
                {
                    // Don't add empty text
                    if (!string.IsNullOrEmpty(line))
                    {
                        consequences.Add(line);
                    }

                    continue;
                }

                if (section == 3)
                {
                    // Add text, empty or not
                    rules.Add(line);
                }
            }

            // Does it have a title?
            if (titles.Count > 2)
            {
                card.Title = titles[0].Trim();
                card.TitleRule = titles[1].Trim();
                titles.RemoveAt(0);
                titles.RemoveAt(0);
            }

            card.Page = 1;

            var cardFlavor = "";

            foreach (var flavor in titles)
            {
                if (!string.IsNullOrEmpty(cardFlavor))
                {
                    cardFlavor = cardFlavor + " ";
                }

                cardFlavor = cardFlavor + flavor.Trim();
            }

            card.Flavor = cardFlavor;

            foreach (var consequence in consequences)
            {
                if (card.Consequences == null)
                {
                    card.Consequences = new i18nString();
                }
                card.Consequences.Add(consequence);
            }

            var rule = new GatheringRule();

            var flavorFound = false;

            var flavorText = new List<string>();
            var rulesText = new List<string>();

            for (int ruleLineIndex = 0; ruleLineIndex < rules.Count; ruleLineIndex++)
            {
                var ruleLine = rules[ruleLineIndex];

                if (ruleLine.Contains("++++"))
                {
                    card.TrackDeckInfo = true;
                    continue;
                }

                // Does it have a condition?
                if (ruleLineIndex + 1 < rules.Count && ConditionSplitRegex.Value.IsMatch(rules[ruleLineIndex + 1]))
                {
                    rule.Condition = ruleLine;
                    ruleLineIndex++;

                    continue;
                }

                // Rules are split by "or"
                if (RuleSplitRegex.Value.IsMatch(ruleLine))
                {
                    rule.Prompt = string.Join("\r\n", flavorText);
                    rule.Rules = string.Join("\r\n", rulesText);
                    card.Rules.Add(rule);
                    flavorText.Clear();
                    rulesText.Clear();
                    rule = new GatheringRule();
                    flavorFound = false;

                    continue;
                }

                // Rule and flavor are split by "###"
                if (ruleLine.Contains("###"))
                {
                    flavorFound = true;

                    continue;
                }

                if (flavorFound)
                {
                    rulesText.Add(ruleLine.Trim());
                }
                else
                {
                    flavorText.Add(ruleLine.Trim());
                }
            }

            if (flavorText.Any())
            {
                rule.Prompt = string.Join("\r\n", flavorText);
            }

            if (rulesText.Any())
            {
                rule.Rules = string.Join("\r\n", rulesText);
            }

            card.Rules.Add(rule);

            return true;
        }
    }
}
