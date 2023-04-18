using System.Text.Json.Serialization;

namespace Model.Model.Behavior
{
    /// <summary>
    /// The track deck is a triple of cards added to a monster's behavior cards depending on the Scoutfly tracker.
    /// </summary>
    /// <remarks>
    /// Players always add a specific behavior card to the deck if their Scoutfly track count is below or equal the minimum of the given quest's range, another one for below the maximum of the quest's range, and the last one for being equal or exceeding the maximum.
    /// </remarks>
    public class TrackDeck
    {
        /// <summary>
        /// Card used when you tracked little
        /// </summary>
        [JsonPropertyName("less-or-equal-minimum")]
        public BehaviorCard? LessEqualMinimum { get; set; }

        /// <summary>
        /// Card used when you tracked an average amount
        /// </summary>
        [JsonPropertyName("above-minimum-below-maximum")]
        public BehaviorCard? MidRange { get; set; }

        /// <summary>
        /// Card used when you tracked a lot
        /// </summary>
        [JsonPropertyName("greater-or-equal-maximum")]
        public BehaviorCard? GreaterEqualMaximum { get; set; }

    }
}
