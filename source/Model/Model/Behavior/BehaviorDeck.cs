using System.Text.Json.Serialization;

namespace Model.Model.Behavior
{
    /// <summary>
    /// Represents a single monster's behavior deck
    /// </summary>
    public class BehaviorDeck
    {
        /// <summary>
        /// The canonical id of the target monster, e.g. `great-jagras`
        /// </summary>
        /// <remarks>
        /// The intention is to allow the cross-referencing information within the data file without i18n getting in the way
        /// </remarks>
        [JsonPropertyName("monster-id")]
        public string? MonsterId { get; set; }

        /// <summary>
        /// A collection of behavior cards the monster always comes equipped with
        /// </summary>
        [JsonPropertyName("base-deck")]
        public List<BehaviorCard>? BaseDeck { get; set; }

        /// <summary>
        /// A collection of special behavior cards specific to a monster
        /// </summary>
        [JsonPropertyName("special")]
        public List<SpecialBehaviorCard>? SpecialCards { get; set; }

        /// <summary>
        /// Tracking / Scoutfly based behavior card selection
        /// </summary>
        [JsonPropertyName("track-deck")]
        public TrackDeck? TrackDeck { get; set; }

        /// <summary>
        /// A collection of behavior cards the monster uses once enraged
        /// </summary>
        /// <remarks>
        /// Future-proofing for Iceborne
        /// </remarks>
        [JsonPropertyName("rage-deck")]
        public List<BehaviorCard>? RageDeck { get; set; }
    }
}
