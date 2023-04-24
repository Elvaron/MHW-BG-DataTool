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
        
    }
}
