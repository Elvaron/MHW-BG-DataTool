using System.Text.Json.Serialization;

namespace Model.Model.Quests
{
    /// <summary>
    /// Starting point nodes for players
    /// </summary>
    public class PlayerPlacement
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
    }
}
