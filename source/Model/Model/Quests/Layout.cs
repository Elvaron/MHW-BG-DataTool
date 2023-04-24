using System.Text.Json.Serialization;

namespace Model.Model.Quests
{
    /// <summary>
    /// Represents a board game grid layout
    /// </summary>
    public class Layout
    {
        /// <summary>
        /// Monster starting position
        /// </summary>
        [JsonPropertyName("monsters")]
        public List<MonsterPlacement>? Monsters { get; set; }

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
