using Model.Utility;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Model.Model.Quests
{
    /// <summary>
    /// Represents a single Gathering Phase card
    /// </summary>
    [DebuggerDisplay("{Number,nq}")]
    public class GatheringCard
    {
        /// <summary>
        /// The number written on top of the card
        /// </summary>
        [JsonPropertyName("number")]
        public int? Number { get; set; }

        /// <summary>
        ///  The quest book page this card is found on
        /// </summary>
        [JsonPropertyName("page")]
        public int? Page { get; set; }

        /// <summary>
        /// The title text of the card
        /// </summary>
        /// <remarks>
        /// Usually something like "Assigned Quest Starting Point"
        /// </remarks>
        [JsonPropertyName("title")]
        public i18nString? Title { get; set; }

        /// <summary>
        /// The consequence of using a given starting point, e.g. getting a potion
        /// </summary>
        [JsonPropertyName("title-rule")]
        public i18nString? TitleRule { get; set; }

        /// <summary>
        /// The flavor text on the card that tells the story
        /// </summary>
        [JsonPropertyName("flavor")]
        public i18nString? Flavor { get; set; }

        /// <summary>
        /// Potential consequences (rewards and/or penalties) for this card no matter which rule is chosen
        /// </summary>
        [JsonPropertyName("consequences")]
        public i18nString? Consequences { get; set; }

        /// <summary>
        /// Rules to chose from
        /// </summary>
        [JsonPropertyName("rules")]
        public List<GatheringRule>? Rules { get; set; }

        /// <summary>
        /// Whether to print the tracking deck info
        /// </summary>
        [JsonPropertyName("track-deck-info")]
        public bool? TrackDeckInfo { get; set; }
    }
}
