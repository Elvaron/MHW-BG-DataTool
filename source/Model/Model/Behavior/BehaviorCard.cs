using System.Text.Json.Serialization;
using Model.Utility;

namespace Model.Model.Behavior
{
    /// <summary>
    /// A behavior card describes a monster's turn
    /// </summary>
    public class BehaviorCard
    {
        /// <summary>
        /// Localizable card name
        /// </summary>
        [JsonPropertyName("name")]
        public i18nString? Name { get; set; }

        /// <summary>
        /// A card's index reference, e.g. "4/10"
        /// </summary>
        [JsonPropertyName("index")]
        public i18nString? Index { get; set; }

        /// <summary>
        /// Indicates which target the monster will pick
        /// </summary>
        /// <value>far|close</value>
        [JsonPropertyName("target")]
        public string? Target { get; set; }

        /// <summary>
        /// The card's associated monster body part
        /// </summary>
        /// <value>head|body|tail|legs|claws|wings</value>
        [JsonPropertyName("part")]
        public string? Part { get; set; }

        /// <summary>
        /// Hunter activation information
        /// </summary>
        [JsonPropertyName("activation")]
        public HunterActivation? Activation { get; set; }

        /// <summary>
        /// Collection of monster actions
        /// </summary>
        [JsonPropertyName("actions")]
        public List<MonsterAction>? Actions { get; set; }
    }
}
