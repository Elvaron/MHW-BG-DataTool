using Model.Utility;
using System.Text.Json.Serialization;

namespace Model.Model
{
    /// <summary>
    /// Represents a single quest as published in a quest book
    /// </summary>
    public class Quest
    {
        /// <summary>
        /// Which monster will be fought?
        /// </summary>
        [JsonPropertyName("target")]
        public i18nString? Target { get; set; }

        /// <summary>
        /// What kind of quest is it?
        /// </summary>
        [JsonPropertyName("kind")]
        public i18nString? Kind { get; set; }

        /// <summary>
        /// What is the numeric difficulty?
        /// </summary>
        [JsonPropertyName("difficulty")]
        public int? Difficulty { get; set; }

        /// <summary>
        /// How many time cards to pull?
        /// </summary>
        [JsonPropertyName("time limit")]
        public int? TimeLimit { get; set; }

        /// <summary>
        /// What Scoutfly level is required?
        /// </summary>
        [JsonPropertyName("scoutfly level")]
        public string? ScoutflyLevel { get; set; }

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
