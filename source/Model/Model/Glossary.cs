using Model.Utility;
using System.Text.Json.Serialization;

namespace Model.Model
{
    /// <summary>
    /// Common terms dictionary
    /// </summary>
    public class Glossary
    {
        /// <summary>
        /// Translation for "or"
        /// </summary>
        [JsonPropertyName("rule-box-concat")]
        public i18nString? RuleBoxConcat { get; set; }

        /// <summary>
        /// Translation for P.
        /// </summary>
        [JsonPropertyName("abbreviation-page")]
        public i18nString? AbbreviationPage { get; set; }

        /// <summary>
        /// Translation for Scoutfly Level
        /// </summary>
        [JsonPropertyName("scoutfly-level")]
        public i18nString? ScoutflyLevel { get; set; }

        /// <summary>
        /// Translation for Starting Points
        /// </summary>
        [JsonPropertyName("starting-points")]
        public i18nString? StartingPoints { get; set; }

        /// <summary>
        /// Translation for Time Limit
        /// </summary>
        [JsonPropertyName("time-limit")]
        public i18nString? TimeLimit { get; set; }

        /// <summary>
        /// Translation for Time Cards
        /// </summary>
        [JsonPropertyName("time-cards")]
        public i18nString? TimeCards { get; set; }

    }
}
