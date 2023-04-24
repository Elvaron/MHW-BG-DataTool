using System.Diagnostics;
using System.Text.Json.Serialization;
using Model.Utility;

namespace Model.Model.Behavior
{
    [DebuggerDisplay("{ActionType,nq}")]
    public class MonsterAction
    {
        /// <summary>
        /// What kind of action is being performed
        /// </summary>
        /// <value>move|attack</value>
        [JsonPropertyName("type")]
        public string? ActionType { get; set; }

        /// <summary>
        /// The monster movement
        /// </summary>
        [JsonPropertyName("movement")]
        public MonsterMovement? Movement { get; set; }

        /// <summary>
        /// Targeting mode
        /// </summary>
        /// <value>arc|node</value>
        [JsonPropertyName("targeting")]
        public string? Targeting { get; set; }

        /// <summary>
        /// Targeting arc, null if targeting a node
        /// </summary>
        [JsonPropertyName("arc")]
        public Arc4? ArcDirection { get; set; }

        /// <summary>
        /// Range in number of nodes for the attack
        /// </summary>
        [JsonPropertyName("range")]
        public int? Range { get; set; } = 0;

        /// <summary>
        /// Dodge value, i.e. how difficult the attack is for the hunters to dodge
        /// </summary>
        [JsonPropertyName("dodge")]
        public int? Dodge { get; set; } = 0;

        /// <summary>
        /// Amount of damage dealt by the attack
        /// </summary>
        [JsonPropertyName("damage")]
        public int? Damage { get; set; } = 0;

        /// <summary>
        /// Damage element (physical vs. elemental)
        /// </summary>
        /// <value>physical|fire|water|ice|thunder|dragon</value>
        [JsonPropertyName("element")]
        public string? Element { get; set; }

        /// <summary>
        /// Status ailment caused by attack
        /// </summary>
        /// <value>stun|poison|sleep|paralysis|blastblight</value>
        [JsonPropertyName("status-ailment")]
        public string? StatusAilment { get; set; }
    }
}
