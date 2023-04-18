using System.Text.Json.Serialization;

namespace Model.Model
{
    /// <summary>
    /// Position and orientation data for monster starting position
    /// </summary>
    public class Monster
    {
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
        /// 0 = North, 1 = North East, etc.
        /// </summary>
        [JsonPropertyName("facing")]
        public int? Facing { get; set; }
    }
}
