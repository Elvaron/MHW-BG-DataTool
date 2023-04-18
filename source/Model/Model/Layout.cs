using System.Text.Json.Serialization;

namespace Model.Model
{
    /// <summary>
    /// Represents a board game grid layout
    /// </summary>
    public class Layout
    {
        /// <summary>
        /// Monster starting position
        /// </summary>
        [JsonPropertyName("monster")]
        public MonsterPlacement? Monster { get; set; }

        /// <summary>
        /// Player starting positions
        /// </summary>
        [JsonPropertyName("players")]
        public List<PlayerPlacement>? Players { get; set; }

        /// <summary>
        /// Terrain nodes
        /// </summary>
        [JsonPropertyName("terrain")]
        public List<Terrain>? Terrain { get; set; }
    }
}
