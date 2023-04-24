using Model.Utility;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Model.Model.Quests
{
    /// <summary>
    /// Represents a single quest as published in a quest book
    /// </summary>
    [DebuggerDisplay("{QuestId,nq}")]
    public class Quest
    {
        /// <summary>
        /// Canonical Monster ID
        /// </summary>
        [JsonPropertyName("monster-id")]
        public string? MonsterId { get; set; }

        /// <summary>
        /// Canonical Quest ID
        /// </summary>
        [JsonPropertyName("quest-id")]
        public string? QuestId { get; set; }

        /// <summary>
        /// Quest name, usually the name of the monster to be fought
        /// </summary>
        [JsonPropertyName("quest-name")]
        public i18nString? QuestName { get; set; }

        /// <summary>
        /// What kind of quest is it?
        /// </summary>
        [JsonPropertyName("quest-category")]
        public i18nString? Category { get; set; }

        /// <summary>
        /// What is the numeric difficulty?
        /// </summary>
        [JsonPropertyName("difficulty")]
        public int? Difficulty { get; set; }

        /// <summary>
        /// How many time cards to pull?
        /// </summary>
        [JsonPropertyName("time-limit")]
        public int? TimeLimit { get; set; }

        /// <summary>
        /// What Scoutfly level is required?
        /// </summary>
        [JsonPropertyName("scoutfly-level")]
        public ScoutflyLevel? ScoutflyLevel { get; set; }

        /// <summary>
        /// Which quest cards form the starting point(s) for attempts at this quest?
        /// </summary>
        [JsonPropertyName("starting")]
        public List<int?>? Starting { get; set; }

        /// <summary>
        /// The map layout to use for this quest
        /// </summary>
        [JsonPropertyName("layout")]
        public Layout? Layout { get; set; }
    }
}
