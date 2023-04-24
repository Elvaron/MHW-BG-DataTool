using System.Text.Json.Serialization;

namespace Model.Model.Time
{
    /// <summary>
    /// Time card decks contain the blue and red time cards included with each core set and expansion.
    /// In play, you would only use one blue deck due to duplicates.
    /// </summary>
    public class TimeCardDeckContainer
    {
        /// <summary>
        /// Common rule text sets
        /// </summary>
        /// <remarks>
        /// There's really only one element in this array at this point, but with Icebore that might be different (we will see and adapt).
        /// </remarks>
        [JsonPropertyName("common-rule-sets")]
        public List<CommonTextContainer>? CommonRuleSets { get; set; }

        /// <summary>
        /// Individual decks
        /// </summary>
        [JsonPropertyName("decks")]
        public List<TimeCardDeck>? Decks { get; set; }
    }
}
