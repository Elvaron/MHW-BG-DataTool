using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Model.Model.Quests
{
    /// <summary>
    /// Position and orientation data for monster starting position
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
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

        [JsonIgnore]
        public string CompassFacing
        {
            get
            {
                switch (Facing)
                {
                    case 1: return "N";
                    case 2: return "NE";
                    case 3: return "E";
                    case 4: return "SE";
                    case 5: return "S";
                    case 6: return "SW";
                    case 7: return "W";
                    case 8: return "NW";
                }
                return "N";
            }
        }

        [JsonIgnore]
        private string DebuggerDisplay
        {
            get { return string.Format("{0} at {1}|{2} facing {3}", MonsterId, X, Y, CompassFacing); }
        }
    }
}
