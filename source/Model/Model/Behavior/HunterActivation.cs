using System.Text.Json.Serialization;

namespace Model.Model.Behavior
{
    /// <summary>
    /// Contains hunter activation information
    /// </summary>
    public class HunterActivation
    {
        /// <summary>
        /// Number of turns the hunting party collectively gets before the monster acts again
        /// </summary>
        [JsonPropertyName("hunters")]
        public int? HunterTurns { get; set; }

        /// <summary>
        /// Number of attack cards each hunter can play during their turn
        /// </summary>
        [JsonPropertyName("cards")]
        public int? AttackCards { get; set; }
    }
}
