using System.Text.Json.Serialization;

namespace Model.Model.Behavior
{
    /// <summary>
    /// Represents a monster's movement direction/speed
    /// </summary>
    public class MonsterMovement
    {
        /// <summary>
        /// Movement speed towards target
        /// </summary>
        [JsonPropertyName("front")]
        public int? Front { get; set; } = 0;

        /// <summary>
        /// Movement speed away from target
        /// </summary>
        [JsonPropertyName("back")]
        public int? Back { get; set; } = 0;

        /// <summary>
        /// Left strafe movement
        /// </summary>
        [JsonPropertyName("left")]
        public int? Left { get; set; } = 0;

        /// <summary>
        /// Right strafe movement
        /// </summary>
        [JsonPropertyName("right")]
        public int? Right { get; set; } = 0;
    }
}
