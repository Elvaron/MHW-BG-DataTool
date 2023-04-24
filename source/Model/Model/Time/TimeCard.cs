using Model.Utility;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Model.Model.Time
{
    /// <summary>
    /// Each TimeCard object represents one or more identical time cards
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class TimeCard
    {
        /// <summary>
        /// The type of card
        /// </summary>
        /// <remarks>
        /// Values are blue|red
        /// </remarks>
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        /// <summary>
        /// Localizable name of the card
        /// </summary>
        [JsonPropertyName("name")]
        public i18nString? Title { get; set; }

        /// <summary>
        /// Collection of localizable rules
        /// </summary>
        [JsonPropertyName("rules")]
        public i18nString? Rules { get; set; }

        /// <summary>
        /// Individual card numbers of copies of this card
        /// </summary>
        [JsonPropertyName("instances")]
        public List<int>? CardNumbers { get; set; }

        [JsonIgnore]
        private string DebuggerDisplay
        {
            get { return string.Format("{0}", Title?.Default); }
        }
    }
}
