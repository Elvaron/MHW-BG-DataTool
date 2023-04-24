using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Model.Model.Quests
{
    /// <summary>
    /// Gathering card deck for a specific monster
    /// </summary>
    [DebuggerDisplay("{MonsterId,nq}")]
    public class GatheringCardDeck
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
        /// Individual gathering cards for a monster
        /// </summary>
        [JsonPropertyName("gathering-cards")]
        public List<GatheringCard>? GatheringCards { get; set; }
    }
}
