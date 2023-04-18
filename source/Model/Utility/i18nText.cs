using System.Text.Json.Serialization;

namespace Model.Utility
{
    /// <summary>
    /// Localizable string
    /// </summary>
    public class i18nText
    {
        /// <summary>
        /// Language name
        /// </summary>
        [JsonPropertyName("language")]
        public string? Language { get; set; }

        /// <summary>
        /// Text
        /// </summary>
        [JsonPropertyName("text")]
        public string? Text { get; set; }
    }
}