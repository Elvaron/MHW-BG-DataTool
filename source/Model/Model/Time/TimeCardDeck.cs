using Model.Utility;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Model.Model.Time
{
    /// <summary>
    /// Each time card deck contains the blue and red time cards for a given core set/expansion.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class TimeCardDeck
    {
        /// <summary>
        /// Localizable name of the expansion
        /// </summary>
        [JsonPropertyName("name")]
        public i18nString? Title { get; set; }

        /// <summary>
        /// Localizable name of the expansion
        /// </summary>
        [JsonPropertyName("short-name")]
        public i18nString? ShortTitle { get; set; }

        /// <summary>
        /// References the CommonTextContainer to use
        /// </summary>
        [JsonPropertyName("common")]
        public string? CommonRulesTextSet { get; set; }

        /// <summary>
        /// The amount of cards in that expansion
        /// </summary>
        /// <remarks>
        /// To print on the bottom of cards e.g. MHW:AF 222/632, with 632 being the card-limit
        /// </remarks>
        [JsonPropertyName("card-limit")]
        public int? CardLimit { get; set; }

        /// <summary>
        /// The contained time cards
        /// </summary>
        [JsonPropertyName("cards")]
        public List<TimeCard>? TimeCards { get; set; }

        [JsonIgnore]
        private string DebuggerDisplay
        {
            get { return string.Format("{0}", Title?.Default); }
        }
    }
}
