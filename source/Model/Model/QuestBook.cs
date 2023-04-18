using System.Text.Json.Serialization;
using Model.Utility;

namespace Model.Model
{
    /// <summary>
    /// Representation of a single published quest book
    /// </summary>
    /// <remarks>
    /// Quest books can be published as a stand-alone document or as part of an expansion's rulebook.
    /// </remarks>
    public class QuestBook
    {
        /// <summary>
        /// Human-friendly title
        /// </summary>
        [JsonPropertyName("title")]
        public i18nString? Title { get; set; }

        /// <summary>
        /// Abbreviated title to be used in small-print
        /// </summary>
        [JsonPropertyName("short-title")]
        public i18nString? ShortTitle { get; set; }

        /// <summary>
        /// Version number
        /// </summary>
        [JsonPropertyName("version")]
        public string? Version { get; set; }

        /// <summary>
        /// Printed quests
        /// </summary>
        /// <remarks>
        /// These are used to generate the quest cards
        /// </remarks>
        [JsonPropertyName("quests")]
        public List<Quest>? Quests { get; set; }

        /// <summary>
        /// Individual story cards
        /// </summary>
        [JsonPropertyName("cards")]
        public List<Card>? Cards { get; set; }
    }
}
