using System.Text.Json.Serialization;

namespace Model.Model.Quests
{
    /// <summary>
    /// Position and orientation data for monster starting position
    /// </summary>
    public class MonsterPlacement
    {
        /// <summary>
        /// Canonical monster id
        /// </summary>
        [JsonPropertyName("monster-id")]
        public string? MonsterId { get; set; }

        /// <summary>
        /// X Position on the grid, 1 = leftmost column
        /// </summary>
        [JsonPropertyName("x")]
        public int? X { get; set; }

        /// <summary>
        /// Y Position on the grid, 1 = topmost row 
        /// </summary>
        [JsonPropertyName("y")]
        public int? Y { get; set; }

        /// <summary>
        /// Monster facing using compass directions
        /// 1 = North, 2 = North East, etc.
        /// </summary>
        [JsonPropertyName("facing")]
        public int? Facing { get; set; }
    }
}
