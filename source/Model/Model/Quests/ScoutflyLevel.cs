using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Model.Model.Quests
{
    /// <summary>
    /// Each quest has a minimum and maximum scoutfly level. They decide which specific behavior card will be added to a monster's deck.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class ScoutflyLevel
    {
        /// <summary>
        /// Minimum Scoutfly Level
        /// </summary>
        /// <remarks>
        /// Less or equal causes behavior card #1 to be used
        /// </remarks>
        [JsonPropertyName("min")]
        public int? Minimum { get; set; }

        /// <summary>
        /// Maximum Scoutfly Level
        /// </summary>
        /// <remarks>
        /// Greater or equal causes behavior card #3 to be used
        /// </remarks>
        [JsonPropertyName("max")]
        public int? Maximum { get; set; }

        [JsonIgnore]
        private string DebuggerDisplay
        {
            get { return string.Format("{0}-{1}", Minimum, Maximum); }
        }
    }
}
