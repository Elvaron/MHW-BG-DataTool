using Model.Utility;
using System.Text.Json.Serialization;

namespace Model.Model
{
    /// <summary>
    /// Root node
    /// </summary>
    public class DataFile
    {
        /// <summary>
        /// The Quest Book contained in this file
        /// </summary>
        /// <remarks>
        /// Having a neutral root node is purely future-proofing
        /// </remarks>
        [JsonPropertyName("quest-books")]
        public List<QuestBook>? QuestBook { get; set; }

        /// <summary>
        /// Copyright info
        /// </summary>
        [JsonPropertyName("copyright")]
        public i18nString? Copyright { get; set; }

        /// <summary>
        /// Reused words made localizable
        /// </summary>
        [JsonPropertyName("glossary")]
        public Glossary? Glossary { get; set; }
    }
}
