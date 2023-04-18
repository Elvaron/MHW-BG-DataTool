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
        /// The story-like instruction for the players
        /// </summary>
        [JsonPropertyName("rule-box-concat")]
        public i18nString? RuleBoxConcat { get; set; }
    }
}
