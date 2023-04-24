using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Model.Model.Quests
{
    /// <summary>
    /// Starting point nodes for players
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
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

        [JsonIgnore]
        private string DebuggerDisplay
        {
            get { return string.Format("Player at {0}|{1}", X, Y); }
        }
    }
}
